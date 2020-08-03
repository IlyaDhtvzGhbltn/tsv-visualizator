using System;
using System.IO;
using ValidationInterfaces;

namespace TSVValidation.Implementation
{
    internal class FileValidation : IFileValidation
    {
        private readonly string path;
        public FileValidation(string path)
        {
            this.path = path;
        }

        public bool IsFileValid()
        {
            return 
                IsFileExist() && 
                IsFileNotEmpty();
        }

        public bool IsFileExist()
        {
            if (File.Exists(this.path))
                return true;
            throw new Exception("File doesn't exist.");
        }

        public bool IsFileNotEmpty()
        {
            FileInfo info = new FileInfo(this.path);
            if(info.Length > 0)
                return true;
            throw new Exception("Target file doesn't contain data.");
        }
    }
}
