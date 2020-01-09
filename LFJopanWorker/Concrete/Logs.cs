using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SianControlGlobal.Abstract;
using System.IO;

namespace SianControlGlobal.Concrete
{
    class Logs :ILog
    {
        private Processs Process = new Processs() ;
        public void LogFileMake(string targetPath, string LogFileName, string Message)
        {
            try
            {
                string logFileName = string.Format("{0}\\{1}", targetPath, DateTime.Now.ToShortDateString() + LogFileName);
                FileInfo logFile = new FileInfo(logFileName);
                if (!logFile.Exists)
                    logFile.Create();


                FileStream fs = new FileStream(logFileName, FileMode.Append, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                sw.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString(), Message));
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
               Process.killps("SianControlGlobal");
            }
        }


        public void LogFileOrderItemCodeMake(string targetPath, string LogFileName, string Message)
        {
            try
            {
                string logFileName = string.Format("{0}\\{1}", targetPath, DateTime.Now.ToShortDateString() + LogFileName);
                FileInfo logFile = new FileInfo(logFileName);
                if (!logFile.Exists)
                    logFile.Create();


                FileStream fs = new FileStream(logFileName, FileMode.Append, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                sw.WriteLine(String.Format("{0}", Message));
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
                Process.killps("SianControlGlobal");
            }
        }
    }
}
