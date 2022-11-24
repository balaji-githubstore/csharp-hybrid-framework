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

        public static void EnterUsername(IWebDriver driver,string username)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
        }

        public static void EnterPassword(IWebDriver driver, string password)
        {
            driver.FindElement(By.CssSelector("[name='password']")).SendKeys(password);
        }

        public static void ClickOnLogin(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();
        }
    }
}
