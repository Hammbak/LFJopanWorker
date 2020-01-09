using Adprint.ProductManager.Worker;
using ProductManager.Support;
using System;
using System.IO;
using Yusurun.Spring.Core;
using Yusurun.Util.Basic;
using Yusurun.Web.Util;

namespace LFJopanWorker
{
    public class Program
    {
        private static XmlDataManager xmlManager;

        public static void Main(string[] args)
        {
            string configFilePath = AppDomain.CurrentDomain.BaseDirectory.CombinePath("config/config.xml");
            string log4netconfigFilePath = AppDomain.CurrentDomain.BaseDirectory.CombinePath("config/log4net.xml");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(log4netconfigFilePath));
            xmlManager = new XmlDataManager(true);
            xmlManager.Load(configFilePath);

            DoProcess();
        }


        private static void DoProcess()
        {
            LogWriter logWriter = ContextManager.GetContextObject("LogWriter") as LogWriter;
            IWorker currentWorker = ContextManager.GetContextObject("LfJopanWorker") as IWorker;

            try
            {
                currentWorker.DoIt();
            }
            catch (DirectoryNotFoundException ex)
            {
                if (makeDirectoyForDirectoryNotFoundException(ex.Message))
                    logWriter.ExceptionLog(currentWorker.ToString() + " : 경로가 존재하지 않아 생성하였습니다.\n다음 작업 시 처리 됩니다.");
            }
            catch (Exception ex)
            {
                if (currentWorker == null)
                {
                    logWriter.ExceptionLog("Program Exception : " + ex.Message);
                }
                else
                {
                    logWriter.ExceptionLog(currentWorker.ToString() + " : " + ex.Message);
                }
            }
        }

        private static bool makeDirectoyForDirectoryNotFoundException(string errMsg)
        {
            bool isMakeDir = false;

            int stIdx = errMsg.IndexOf("'") + 1;
            int edIdx = errMsg.IndexOf("'", stIdx) - 1;
            string path = errMsg.Substring(stIdx, edIdx);

            if (FileUtil.CreateDirectory(path) != null) isMakeDir = true;

            return isMakeDir;
        }
    }
}