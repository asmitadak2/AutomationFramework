using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace AutomationFramework.Resources
{
    public class ExtentManager
    {
        [ThreadStatic]
        private static ExtentTest parenttest;
        [ThreadStatic]
        private static ExtentTest childtest;
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest createParenttest(string Testname, String description = null)
        {
            parenttest=ExtentService.GetExtent().CreateTest(Testname, description);
            return parenttest;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest createtest(string Testname, String description = null)
        {
            childtest = parenttest.CreateNode(Testname, description);
            return childtest;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest getTest()
        {
            return childtest;
        }
    }
}
