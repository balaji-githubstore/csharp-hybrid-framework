using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            this._driver=driver;
        }


        public void EnterUsername(string username)
        {
            _driver.FindElement(By.Name("username")).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(By.CssSelector("[name='password']")).SendKeys(password);
        }

        public void ClickOnLogin()
        {
            _driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();
        }

        public string GetInvalidLoginErrorMessage()
        {
            return _driver.FindElement(By.XPath("//p[contains(@class,'oxd-alert')]")).Text;
        }
       
    }
}
