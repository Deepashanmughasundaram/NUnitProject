using NUnit.Framework;
using NUnitProject.Pages.GenericUser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitProject.Test.GenericUserTestPage
{
    class GenericUserTestRun : BaseTest
    {
        [Test]
        [Obsolete]
        public void GHomePageTest()
        {
            test = extent.StartTest("GHomePageTest");
            
            //GenericUserMenus Methods
            GUM.GHomeMenu();
            
            //GenericUserHomePage Method
           GUHP.GCityTextbox();
           String actual = GUHP.GCityTextbox();
           Console.WriteLine(actual);
           Assert.AreEqual(actual, "City : Chennai");
           GUM.GAboutUsMenu();
           GUM.GSignIn();

           //GenericUserSignInPage Methods
           String actual1 = GUSIP.GSigninPageheading();
           Console.WriteLine(actual1);
           Assert.AreEqual(actual1, "Regissster");
           test.Log(LogStatus.Pass, "Test Passed");
       }


       static void Main(string[] args)
       {

       }

   }
}
