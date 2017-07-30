﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ServiceProcess;
using Microsoft.Win32;


namespace SharePc
{

    class SharePc : ServiceBase
    {
        public Process proc=null;
        
        public SharePc()
        {

          

        }

        void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                destroy();
                Console.WriteLine("Locked");
                //I left my desk
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {

                Console.WriteLine("Unlocked");
                //I returned to my desk
            }
        }

        public String getControlString()
        {
            Microsoft.Win32.SystemEvents.SessionSwitch -= new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);

            Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);

            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "RDPServer\\RDPSessionManager.exe",
                    // Arguments = "command line arguments to your executable",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
             
            proc.Start();
            string line = proc.StandardOutput.ReadLine();
            //Console.WriteLine(line);
            return line;
        }

        public void destroy()
        {
            if (proc != null)
            {

                Microsoft.Win32.SystemEvents.SessionSwitch -= new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);
                

                proc.Kill();

                proc = null;
            }
            else {
                Console.WriteLine("process null.No process has been created.");
            }

           
        }

        public void disconnect()
        {
            destroy();
        
        }
    }
}
