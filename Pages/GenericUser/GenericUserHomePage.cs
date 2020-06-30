using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitProject.Pages.GenericUser
{
    class GenericUserHomePage : BaseTest
    {
        IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "menu_txtBox_home1")]
        public IWebElement GCityTextBox;
        [FindsBy(How = How.Id, Using = "txtArea")]
        public IWebElement GAreatbox;
        [FindsBy(How = How.XPath, Using = "(//div[@id='divAllArea'])//span[2]")]
        public IWebElement GAreadropdown;

        [Obsolete]
        public GenericUserHomePage(IWebDriver driver)
        {
            
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GCityTextbox()
        {
            String GCityTB = GCityTextBox.GetAttribute("value");            
            return GCityTB;
        }

        public void GAreaDropDwon()
        {
            GAreatbox.Click();
            GAreadropdown.Click();
        }
    }
}
