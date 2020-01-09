using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using SianControlGlobal.Abstract;
using SianControlGlobal.Concrete.TeamWork;

namespace SianControlGlobal.Concrete
{
    public class Files : Constant, IFiles 
    {
        Folders Folder = new Folders();
        StepMove StepMove = new StepMove();
        public void FileCopy(string targetPath, FileInfo item)
        {
            Folder.DirectoryMake(targetPath);
            string fileName = item.Name;
            DirectoryInfo targetDirectory = new DirectoryInfo(targetPath);
            string targerFileName = string.Format("{0}\\{1}", targetDirectory, fileName);

            File.Copy(item.FullName, targerFileName, true);
           
        }        
        public string FileExtensionDelete(FileInfo item)
        {
            return item.Name.Replace(item.Extension, "").Replace("_b","").Replace("_B","");
        }

        public IEnumerable<FileInfo> GetFileList(string sourcePath, DirectoryInfo item, string fileExtension)
        {
            IEnumerable<FileInfo> files = new DirectoryInfo(string.Format("{0}\\{1}", sourcePath, item.Name)).GetFiles("*." + fileExtension, SearchOption.AllDirectories);

            var fileName = from p in files
                           select p;

            return fileName;
        }

        public void SianFileCopy(string sourcePath, DirectoryInfo item, DirectoryInfo targetDirectory, IEnumerable<FileInfo> fileName, string targetPath)
        {
           

            foreach (var fileitem in fileName.ToList())
            {

                try
                {
                    FileInfo sourceFile = new FileInfo(string.Format("{0}\\{1}\\{2}", sourcePath, item.Name, fileitem.Name.ToString()));
                    FileInfo targetFile = new FileInfo(string.Format("{0}\\{1}", targetDirectory, fileitem.Name.ToString().Replace("_001", "").Replace("_002", "_b")));

                    File.Copy(sourceFile.FullName, targetFile.FullName, true);

                }
                catch (Exception)
                {

                }

            }

            //StepMove.MAKE_ASSIGN(item.Name);
            //string sianFilePath = (string.Format("{0}\\{1}.jpg", targetDirectory.FullName.ToString().Replace(targetPath, ""), item.Name.ToString())).Replace("\\", "/");
            //db.USP_tblOrderItem_SianFilePath(item.Name, sianFilePath);
        
        }

        public FileInfo DataIntheFileNamePlus(FileInfo item)
        {            
            var newName = db.funDataIntheFileNamePlus(FileExtensionDelete(item)).ToString();           
            FileInfo destFileName  = new FileInfo( string.Format ("{0}\\{1}{2}", item.DirectoryName , newName , item.Extension)) ;
            File.Copy(item.FullName, destFileName.FullName, true);
            return destFileName;
        }

        public string OrderItemCode(FileInfo item)
        {
            try
            {
                return FileExtensionDelete(item).Split(' ')[1].ToString();
            }
            catch (Exception)
            {

                return "0";
            }

            
        }

        public string OrderFileInFolder(string OrderItemCode)
        {
            var tblOrderItem = from p in db.tblOrderItem
                                   where p.strOrderItemCode == OrderItemCode
                                   select p.strCateGoryCodePath;

            var folder = tblOrderItem.Single().ToString();

            return folder.Substring(0, 2).ToString() == "ST" || folder.Substring(2, 2).ToString() == "ST" || folder.Substring(2, 2).ToString() == "WT" ? "ST" : folder.Substring(0, 4).ToString() == "PNDG" ? "DG" : "";
        }
    }
}
