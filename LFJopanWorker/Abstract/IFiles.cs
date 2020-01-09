using System;
using System.IO;
using System.Collections.Generic;

namespace SianControlGlobal.Abstract
{
    public interface IFiles
    {
        void FileCopy(string targetPath, FileInfo item);        
        string FileExtensionDelete(FileInfo item);
        IEnumerable<FileInfo> GetFileList(string sourcePath, DirectoryInfo item, string fileExtension);
        void SianFileCopy(string sourcePath, DirectoryInfo item, DirectoryInfo targetDirectory, IEnumerable<FileInfo> fileName, string targetPath);
        
    }
}
