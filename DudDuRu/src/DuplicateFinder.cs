using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DudDuRu
{
    public class DuplicateFinder
    {
        private BackgroundWorker worker;

        public DuplicateFinder(BackgroundWorker worker)
        {
            this.worker = worker;
        }

        public ScanResult FindDuplicateFiles(String dirPath)
        {
            worker.ReportProgress(0, "Preparing files to scan ...");
            FileInfo[] files = new DirectoryInfo(dirPath).GetFiles("*", SearchOption.AllDirectories);
            Array.Sort(files, Comparer<FileInfo>.Create((a,b) => b.FullName.CompareTo(a.FullName)));
            
            int total = files.Length;
            double progress = 0;
            IDictionary<long, IDictionary<FileInfo, IList<FileInfo>>> byteTable = new Dictionary<long, IDictionary<FileInfo, IList<FileInfo>>>();
            foreach (FileInfo file in files) {
                worker.ReportProgress((int)(++progress/total*100), String.Format("Scanning files... ({0}/{1})", progress, total));

                // Compare size
                long fileSize = file.Length;
                if (!byteTable.ContainsKey(fileSize))
                    byteTable.Add(fileSize, new Dictionary<FileInfo, IList<FileInfo>>());
                
                // Compare contents of the files with same size
                IDictionary<FileInfo, IList<FileInfo>> fileTable = byteTable[fileSize]; // All files in fileMap have the same size
                if (fileTable.Count == 0) {
                    fileTable.Add(file, new List<FileInfo>()); // The first file in fileTable
                } else {
                    bool foundDuplicate = false;
                    // Compare the current file to each file in fileTable
                    foreach (KeyValuePair<FileInfo, IList<FileInfo>> pair in fileTable) {
                        // If find a duplicate, add the file to the same-files-list and break the iteration
                        if (FilesAreEqual(pair.Key, file)) { 
                            foundDuplicate = true;
                            pair.Value.Add(file);
                            break; 
                        }
                    }
                    // No duplicate found, create a new entry in fileTable
                    if (!foundDuplicate)
                        fileTable.Add(file, new List<FileInfo>());
                }
            }

            // Build the result
            ScanResult result = new ScanResult();
            foreach (IDictionary<FileInfo, IList<FileInfo>> fileTable in byteTable.Values) {
                foreach (KeyValuePair<FileInfo, IList<FileInfo>> pair in fileTable) {
                    if (pair.Value.Count > 0) {
                        ISet<FileInfo> list = new SortedSet<FileInfo>(Comparer<FileInfo>.Create((a, b) => b.FullName.CompareTo(a.FullName)));
                        list.Add(pair.Key);
                        result.keepList.Add(pair.Key, true);
                        foreach (FileInfo file in pair.Value) { 
                            list.Add(file);
                            result.keepList.Add(file, false);
                        }
                        result.fileList.Add(pair.Key, list);
                    }
                }
            }
            return result;
        }

        // The method is from http://stackoverflow.com/a/1359947
        private bool FilesAreEqual(FileInfo file1, FileInfo file2)
        {
            Debug.Assert(file1.Length==file2.Length, "File length differs");

            const int BYTES_TO_READ = sizeof(Int64);
            int iterations = (int)Math.Ceiling((double)file1.Length / BYTES_TO_READ);
            try {
                using (FileStream fs1 = file1.OpenRead())
                using (FileStream fs2 = file2.OpenRead()) {
                    byte[] bytes1 = new byte[BYTES_TO_READ];
                    byte[] bytes2 = new byte[BYTES_TO_READ];

                    for (int i=0; i<iterations; i++) {
                        fs1.Read(bytes1, 0, BYTES_TO_READ);
                        fs2.Read(bytes2, 0, BYTES_TO_READ);
                        if (BitConverter.ToInt64(bytes1, 0) != BitConverter.ToInt64(bytes2, 0))
                            return false;
                    }
                }
                return true;
            } catch (IOException e) {
                MessageBox.Show(e.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); // TODO It may be annoying. Use log instead.
                return false;
            }
        }
    }
}
