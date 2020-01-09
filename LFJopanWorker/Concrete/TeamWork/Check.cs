using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SianControlGlobal.Abstract;
using SianControlGlobal.Concrete;
using System.IO;

namespace SianControlGlobal.Concrete.TeamWork
{
   public class Check : DataContext
    {
       Folders Folders = new Folders();
       Files Files = new Files();
       Logs Logs = new Logs();
       StepMove StepMove = new StepMove();
       OrderItem OrderItem = new OrderItem();
        private string RemakePath = "";
        private string CleanupPath = "";

        public Check(string remakePath, string cleanupPath)
        {
            this.RemakePath = remakePath;
            this.CleanupPath = cleanupPath;
        }

       public void FromReMakeToCleanupExecute()
       {
           Console.Write("====== 재제작, 클레임 작업 ======");
           string sourcePath = this.RemakePath;
           string targetPath = this.CleanupPath;

           foreach (var item in Folders.FolderInGetFileInfo(sourcePath).ToList())
           {
               try
               {

                       db.JopanLog_Insert(10, Files.FileExtensionDelete(item));
                       FileInfo MoveItem = Files.DataIntheFileNamePlus(item);
                       Files.FileCopy(Folders.Target_TradeCpy_Path(targetPath, item), MoveItem);
                       MoveItem.Delete();
                       item.Delete();

                       var intOrderItemNum = db.GetReqReMake(Files.FileExtensionDelete(item)).Single().intOrderItemNum ;
                       var intReqRemakeNum = db.GetReqReMake(Files.FileExtensionDelete(item)).Single().intReqRemakeNum ;

                       db.USP_tblReqRemake_RESULTUPDATE(intReqRemakeNum, intOrderItemNum, "REMAKE");


                       db.JopanLog_Insert(7, Files.FileExtensionDelete(item));
                   
               }
               catch (Exception ex)
               {
                   //Logs.LogFileMake(logPath, "LogFileName.txt", "Err " + item.FullName + " : " + ex.Message);
               }
           }
       }
             
      
    }
}
