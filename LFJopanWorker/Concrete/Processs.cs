using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using SianControlGlobal.Abstract;

namespace SianControlGlobal.Concrete
{
    class Processs : IProcess
    {
        public void killps(string processName)
        {
            Process[] process = Process.GetProcessesByName(processName);
            Process currentProcess = Process.GetCurrentProcess();
            foreach (Process p in process)
            {
                if (p.Id != currentProcess.Id)
                    p.Kill();
            }
        }
        public void Open(string processName)
        {
            
            Process.Start(processName); 
        }
    }
}
