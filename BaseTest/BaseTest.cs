using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnitProject.Pages.GenericUser;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitProject
{
    class BaseTest
    {
        public IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;
        public GenericUserMenus GUM;
        public GenericUserSignInPage GUSIP;
        public GenericUserHomePage GUHP;

        [OneTimeSetUp]
        [Obsolete]
        public void Setup()
        {
            //Append the html report file to current project path
            string reportPath = "C:\\Users\\deepa\\source\\repos\\NUnitProject\\Reports\\TestRunReport.html";
            //Boolean value for replacing exisisting report
            extent = new ExtentReports(reportPath, true);
            //Add QA system info to html report
            extent.AddSystemInfo("Host Name", "YourHostName").AddSystemInfo("Environment", "YourQAEnvironment").AddSystemInfo("Username", "YourUserName");
            //Adding config.xml file
            extent.LoadConfig("extent.config.xml"); //Get the config.xml file from http://extentreports.com

            driver = new ChromeDriver();
            driver.Url = "http://localhost/product/";

            GUM = new GenericUserMenus(driver);
            GUSIP = new GenericUserSignInPage(driver);
            GUHP = new GenericUserHomePage(driver);
        }

        [TearDown]
        public void AfterClass()
        {
            //StackTrace details for failed Testcases
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            if (status == TestStatus.Failed)
            {
                string currentDate = DateTime.Now.ToString("HHmmss");
                var image = ((ITakesScreenshot)driver).GetScreenshot();
                //Save the screenshot
                image.SaveAsFile("C:\\Users\\deepa\\source\\repos\\NUnitProjectRepo\\Failed SS\\" + currentDate + ".png", ImageFormat.Png);
                test.Log(LogStatus.Fail, status + errorMessage);
            }

            //End test report
            extent.EndTest(test);
            //driver.Quit();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
            
            //End Report
            extent.Flush();
            extent.Close();
        }
    }
}
