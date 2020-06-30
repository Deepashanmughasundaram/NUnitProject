using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitProject.Pages.GenericUser
{
    class GenericUserMenus : BaseTest
    {
        IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Home")]
        public IWebElement HomeMenu;
        [FindsBy(How = How.LinkText, Using = "About Us")]
        public IWebElement AboutUsMenu;
        [FindsBy(How = How.LinkText, Using = "Sign Up")]
        public IWebElement SignUpMenu;

        [Obsolete]
        public GenericUserMenus(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [Obsolete]
        public void GHomeMenu()
        {
            HomeMenu.Click();
            Console.WriteLine("Home Menu Got Clicked");                 
        }

        public void GAboutUsMenu()
        {
            AboutUsMenu.Click();
            Console.WriteLine("About Us Menu got Clicked");
        }        
        
        [Obsolete]
        public void GSignIn()
        {
            SignUpMenu.Click();
            Console.WriteLine("SignIn Menu got clicked");           
        }
    }
}
