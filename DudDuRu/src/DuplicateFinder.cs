using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DudDuRu
{
    public class DuplicateFinder
    {
        private BackgroundWorker worker;
        private IDictionary<FileInfo, byte[]> dataTable = new Dictionary<FileInfo, byte[]>();

        public DuplicateFinder(BackgroundWorker worker)
        {
            this.worker = worker;
        }

        public ScanResult FindDuplicateFiles(String dirPath)
        {
            worker.ReportProgress(0, "Preparing files ...");
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
                
                // Compare contents of the files with the same size
                IDictionary<FileInfo, IList<FileInfo>> fileTable = byteTable[fileSize]; // All files in fileMap have the same size
                bool foundDuplicate = false;
                // Compare the current file to each file in fileTable
                foreach (KeyValuePair<FileInfo, IList<FileInfo>> pair in fileTable) {
                    // If find a duplicate, add the file to the duplicate-files-list and break the iteration
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

            // Build the result
            worker.ReportProgress(100, "Build the result ...");
            ScanResult result = new ScanResult();
            int sum = 0;
            foreach (IDictionary<FileInfo, IList<FileInfo>> fileTable in byteTable.Values) {
                foreach (KeyValuePair<FileInfo, IList<FileInfo>> pair in fileTable) {
                    if (pair.Value.Count > 0) {
                        ISet<FileInfo> list = new SortedSet<FileInfo>(Comparer<FileInfo>.Create((a, b) => b.FullName.CompareTo(a.FullName)));
                        list.Add(pair.Key);
                        result.RemoveList.Add(pair.Key, false);
                        foreach (FileInfo file in pair.Value) { 
                            list.Add(file);
                            result.RemoveList.Add(file, true);
                        }
                        result.FileList.Add(pair.Key, list);
                        sum += pair.Value.Count;
                    }
                }
            }
            result.NumDuplicates = sum;
            return result;
        }

        private bool FilesAreEqual(FileInfo file1, FileInfo file2)
        {
            Debug.Assert(file1.Length==file2.Length, "File length differs");
            Debug.Assert(file1.Length > Int32.MaxValue, "File is too large"); // TODO Make it more elegant

            // TODO Empty files are considered duplicate
            try {
                byte[] data1, data2;

                // Compute file1's MD5
                if (!dataTable.ContainsKey(file1)) {
                    using (var md5 = MD5.Create())
                    using (var stream = File.OpenRead(file1.FullName)) {
                        dataTable.Add(file1, md5.ComputeHash(stream));
                    }
                }
                data1 = dataTable[file1];

                // Compute file2's MD5
                using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(file2.FullName)) {
                    data2 = md5.ComputeHash(stream);
                }

                return StructuralComparisons.StructuralEqualityComparer.Equals(data1, data2);
            } catch (Exception e) {
                MessageBox.Show(e.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); // TODO It may be annoying. Use logger instead.
                return false;
            }
        }
    }
}
