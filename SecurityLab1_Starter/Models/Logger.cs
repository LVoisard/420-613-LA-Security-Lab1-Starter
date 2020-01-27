using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace SecurityLab1_Starter.Models
{
    public class Logger
    {
        public static string LogDirectoryPath = Environment.CurrentDirectory;
        public static void Log(String messages)
        {
            try
            {
                //var x = LogDirectoryPath + "\\" + fileName;

                //StreamWriter strw = new StreamWriter(LogDirectoryPath + "\\"+fileName, true);
                StreamWriter strw = new StreamWriter("C:\\Temp\\log.txt", true);
                strw.WriteLine("{0}--->{1}", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), messages);
                strw.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void EventLog(string messages)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry( DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")+"--->"+ messages, EventLogEntryType.Error, 101, 1);
            }
        }

    }
}