using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SianControlGlobal.Abstract;
using SianControlGlobal.Concrete;
using System.IO;

namespace SianControlGlobal.Concrete.TeamWork
{
   public  class CleanUp :Constant
   {
       //Folders Folders = new Folders();
       //Files Files = new Files();
       //Logs Logs = new Logs();
       //Check Check = new Check();
     

       //public void CleanUpBackupExecute(FileInfo serverpdfItem)
       //{
       //    string sourcePath = cleanupPath;
       //    string targetPath = backupPath + "\\" + Folders.TodayFolder_Path() + cleanupdatabackupPath;
       //    foreach (var item in Folders.FolderInGetFolderInfo(sourcePath).ToList())           
       //    {
       //        try
       //        {
       //             var fileName = Files.GetFileList(sourcePath, item, "*");

       //            foreach (var fileitem in fileName.ToList())
       //            {
       //                try
       //                {
       //                    var OrderItemCode = Files.OrderItemCode(fileitem);
       //                    if (db.funIsMoneyInput(OrderItemCode) == true && OrderItemCode == Files.FileExtensionDelete(serverpdfItem))
       //                    {
       //                        Files.FileCopy(Folders.Target_TradeCpy_Path(targetPath, OrderItemCode), fileitem);
       //                        fileitem.Delete();
       //                        break;
       //                    }
       //                }
       //                catch (Exception)
       //                {
                           
       //                    throw;
       //                }
       //            }
       //        }
       //        catch (Exception ex)
       //        {
       //            Logs.LogFileMake(logPath, "LogFileName.txt", "Err " + item.FullName + " : " + ex.Message);
       //        }
       //    }
       //}

       
   }
}
