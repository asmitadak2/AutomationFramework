using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Resources
{
    internal class ReportLog
    {
        public static void Pass(string message, MediaEntityModelProvider media = null)
        {
            ExtentManager.getTest().Pass(message,media);
        }
        public static void Fail(string message, MediaEntityModelProvider media=null)
        {
            ExtentManager.getTest().Fail(message,media);
        }
        public static void Skip(string message)
        {
            ExtentManager.getTest().Skip(message);
        }
    }
}
