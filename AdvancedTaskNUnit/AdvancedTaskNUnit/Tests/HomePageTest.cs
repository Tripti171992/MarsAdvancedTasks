using AdvancedTaskNUnit.Model;
using AdvancedTaskNUnit.Pages;
using AdvancedTaskNUnit.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskNUnit.Tests
{
    [TestFixture, Order(1)]
    public class HomePageTest : BaseSetUp.BaseSetUp
    {
        HomePage HomePageObj;
        public HomePageTest()
        {
            HomePageObj = new HomePage();
        }

        [SetUp]
        public override void SetActions()
        {
            Initialize();
            NavigateUrl();
        }

        [Test, Order(1)]
        public void SignIn_Test()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

                List<UserInformation> userList = JsonReader.GetData<UserInformation>("C:\\Users\\Tripti Mehta\\Desktop\\Industry Connect\\GitHubRepository\\CompetitiveTask\\CompetitiveTask\\CompetitiveTask\\Mars\\JsonObject\\UserInformation.json");

                foreach (var user in userList)
                {
                    HomePageObj.SignIn(user);
                    //Attaching screenshot with report
                    test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SignIn"), "successful sign in");
                    //Verify if user is taken to their home page upon login in to Mars 
                    string expectedUserName = "Hi " + user.firstName;
                    string actualUserName = HomePageObj.GetFirstName();
                    Assert.AreEqual(expectedUserName, actualUserName, "Actual and expected username do not match.User not logged in successfully !!");
                }
            }
            catch (Exception ex)
            {
                test.AddScreenCaptureFromPath(CommonMethods.SaveScreenshot(driver, "SignIn"), "Exception in Signin");
                test.Fail(ex.Message);
                Assert.Fail();

            }
        }
    }
}
