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
        public IDictionary<FileInfo, ISet<FileInfo>> fileList = new SortedDictionary<FileInfo, ISet<FileInfo>>(Comparer<FileInfo>.Create((a, b) => a.FullName.CompareTo(b.FullName)));
        public IDictionary<FileInfo, bool> keepList = new Dictionary<FileInfo, bool>();
    }
}
