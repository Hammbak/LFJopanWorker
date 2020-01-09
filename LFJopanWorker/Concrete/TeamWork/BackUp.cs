using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SianControlGlobal.Abstract;
using SianControlGlobal.Concrete;
using System.IO;

namespace SianControlGlobal.Concrete.TeamWork
{
    public class BackUp : Constant
    {
        //Folders Folders = new Folders();
        //Files Files = new Files();
        //Logs Logs = new Logs();
        //CleanUp CleanUp = new CleanUp();
        //public void BackUpExecute()
        //{
        //    string sourcePath = backupPath + "\\" + Folders.TodayFolder_Path() + pdfdatabackupPath;
        //    foreach (var item in Folders.FolderInGetFolderInfo(sourcePath).ToList())
        //    {
        //        try
        //        {
        //            var fileName = Files.GetFileList(sourcePath, item, "*");

        //            foreach (var fileitem in fileName.ToList())
        //            {
        //                CleanUp.CleanUpBackupExecute(fileitem);
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
