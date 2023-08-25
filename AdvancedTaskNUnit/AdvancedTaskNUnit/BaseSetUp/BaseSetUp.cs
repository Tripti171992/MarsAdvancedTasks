using AdvancedTaskNUnit.Pages;
using AdvancedTaskNUnit.Utilities;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTaskNUnit.Model;

namespace AdvancedTaskNUnit.BaseSetUp
{
    [TestFixture]
    public class BaseSetUp : CommonDriver
    {
        HomePage HomePageObj;
        public ExtentReports extent;
        public ExtentTest test;
        public BaseSetUp()
        {
            HomePageObj = new HomePage();
        }
        [OneTimeSetUp]
        public void TestSuitSetUp()
        {
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(ConstantUtils.ReportsPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReport);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Tripti");

            htmlReport.Config.DocumentTitle = "Automation Report";
            htmlReport.Config.ReportName = "Test Report";
            htmlReport.Config.Theme = Theme.Dark;
        }

        [SetUp]
        public virtual void SetActions()
        {
            Initialize();
            NavigateUrl();

            //Login into Mars
            List<UserInformation> userList = JsonReader.GetData<UserInformation>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\CompetitiveTask\\CompetitiveTask\\CompetitiveTask\\Mars\\JsonObject\\UserInformation.json");
            HomePageObj.SignIn(userList[0]);
        }
        [TearDown]
        public void TearDownActions()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Passed)
            {
                test.Pass("Test Case Passed!!");
            }
            else if (status == TestStatus.Failed)
            {
                test.Fail("Test Case Failed!!");

            }

            Close();
        }

        [OneTimeTearDown]
        public void testsuitteardown()
        {
            extent.Flush();
        }
    }
}
