using System;
using System.IO;

namespace GlobalLogic_Solution
{
    public class FileInfoSerializable
    {

        #region Constructors

        public FileInfoSerializable() { }

        public FileInfoSerializable(FileInfo fileInfo)
        {
            Name = fileInfo.Name;
            Size = GetFileSize(fileInfo.Length);
            Path = fileInfo.FullName;
        }

        public FileInfoSerializable(string name, string size, string path)
        {
            this.Name = name;
            this.Size = size;
            this.Path = path;
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public string Size { get; set; }

        public string Path { get; set; }

        #endregion

        #region Helpers
        /// <summary>
        /// Convert a byte count into a readable file size 
        /// </summary>
        /// <param name="byteCount">File size in bites</param>
        /// <returns></returns>
        private string GetFileSize(long byteCount)
        {
            string size = "0 Bytes";
            if (byteCount >= 1073741824.0)
                size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
            else if (byteCount >= 1048576.0)
                size = String.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
            else if (byteCount >= 1024.0)
                size = String.Format("{0:##.##}", byteCount / 1024.0) + " KB";
            else if (byteCount > 0 && byteCount < 1024.0)
                size = byteCount.ToString() + " B";

            return size;
        }

        #endregion
    }
}
