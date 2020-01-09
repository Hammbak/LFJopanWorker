using System;
using System.IO;
using System.Collections.Generic;

namespace SianControlGlobal.Abstract
{
   public interface ILog
    {
        void LogFileMake(string targetPath, string LogFileName, string Message);
    }
}
