using DocumentFormat.OpenXml.Bibliography;
using Fujitsu.WebDriverKeywords.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation.Pages
{
    public class MainPage : AutomationKeywords
    {
        private By _pimLocator = By.XPath("//span[text()='PIM']");

        private IWebDriver _driver;

        public MainPage(IWebDriver driver):base(driver)
        {
            _driver = driver;
        }

        public string GetMainPageURL()
        {
            return _driver.Url;
        }

        public void ClickOnPIMMenu()
        {
            ClickByLocator(_pimLocator);
        }
    }
}
