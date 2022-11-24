using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation.Pages
{
    public class AddEmployeePage
    {
        private By _firstnameLocator = By.Name("firstName");

        private IWebDriver _driver;
        public AddEmployeePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void EnterFirstName(string firstname)
        {
            _driver.FindElement(_firstnameLocator).SendKeys(firstname);
        }
    }
}
