using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Resources
{
    internal class ReportLog
    {
        public static void Pass(string message)
        {
            ExtentManager.getTest().Pass(message);
        }
        public static void Fail(string message, MediaEntityModelProvider media=null)
        {
            ExtentManager.getTest().Fail(message);
        }
        public static void SKip(string message)
        {
            ExtentManager.getTest().Skip(message);
        }
    }
}
