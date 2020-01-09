using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using SianControlGlobal.Abstract;

namespace SianControlGlobal.Concrete
{
   public class Folders : Constant, IFolders
   {
        
        public IEnumerable<FileInfo> FolderInGetFileInfo(string sourcePath)
        {
            var files = from p in new DirectoryInfo(sourcePath).GetFiles()
                        select p;
            return files;
        }
        public IEnumerable<FileInfo> FolderInGetFileInfo(string sourcePath, string fileExtension)
        {
            IEnumerable<FileInfo> files = new DirectoryInfo(sourcePath).GetFiles("*." + fileExtension, SearchOption.TopDirectoryOnly);

            var fileName = from p in files
                           select p;

            return fileName;
        }

        public IEnumerable<DirectoryInfo> FolderInGetFolderInfo(string sourcePath)
        {
            var dir = from p in new DirectoryInfo(sourcePath).GetDirectories()
                      select p;
            return dir;
        }

        public DirectoryInfo TargetDirectoryMake(string targetPath, DirectoryInfo item)
        {
            var fileRegDate = db.funFileRegDate(item.Name);

            string fileRefDateDirectory = fileRegDate.ToString().Replace("-", "\\");

            DirectoryInfo targetDirectory = new DirectoryInfo(string.Format("{0}\\{1}", targetPath, fileRefDateDirectory));
            if (!targetDirectory.Exists)
                targetDirectory.Create();
            return targetDirectory;
        }
        public DirectoryInfo DirectoryMake(string targetPath)
        {          
            DirectoryInfo targetDirectory = new DirectoryInfo(targetPath);
            if (!targetDirectory.Exists)
                targetDirectory.Create();
            return targetDirectory;
        }
        public string Target_TradeCpy_Path(string targetPath, FileInfo item)
        {
            Files Files = new Files();
            return string.Format("{0}\\{1}", targetPath, db.funGETstrTradeCpyCode(Files.FileExtensionDelete(item)));
        }
        public string Target_TradeCpy_Path(string targetPath, string OrderItemCode)
        {
            Files Files = new Files();
            return string.Format("{0}\\{1}", targetPath, db.funGETstrTradeCpyCode(OrderItemCode));
        }
        public string TodayFolder_Path()
        {
            return string.Format("{0}\\{1}\\{2}",DateTime.Today.Year,DateTime.Today.Month ,DateTime.Today.Day);
        }

       
   }
}
