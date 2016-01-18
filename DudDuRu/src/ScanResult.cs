using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DudDuRu
{
    public class ScanResult
    {
        public int NumDuplicates { get; set; }
        /** [Represented file, duplicate files of the key] */
        public IDictionary<FileInfo, ISet<FileInfo>> FileList { get; set; }
        /** [File, Keep or remove] */
        public IDictionary<FileInfo, bool> RemoveList { get; set; }

        public ScanResult()
        {
            this.FileList = new SortedDictionary<FileInfo, ISet<FileInfo>>(Comparer<FileInfo>.Create((a, b) => a.FullName.CompareTo(b.FullName)));
            this.RemoveList = new Dictionary<FileInfo, bool>();
        }
    }
}
