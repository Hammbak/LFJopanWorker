using System;
using System.IO;
using System.Collections.Generic;

namespace SianControlGlobal.Abstract
{
   public interface IFolders
    {
        IEnumerable<FileInfo> FolderInGetFileInfo(string sourcePath);
        IEnumerable<DirectoryInfo> FolderInGetFolderInfo(string sourcePath);
        DirectoryInfo TargetDirectoryMake(string targetPath, DirectoryInfo item);
        DirectoryInfo DirectoryMake(string targetPath);
        string Target_TradeCpy_Path(string targetPath, FileInfo item);
        string TodayFolder_Path();
    }
}
