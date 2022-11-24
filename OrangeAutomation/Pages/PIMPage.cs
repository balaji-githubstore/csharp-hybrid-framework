using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation.Pages
{
    public class PIMPage
    {
        private IWebDriver _driver;

        public PIMPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickOnAddEmployee()
        {
            driver.FindElement(By.LinkText("Add Employee")).Click();
        }
    }
}
