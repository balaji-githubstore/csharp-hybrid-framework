using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.WebDriverKeywords.Base
{
    public class AutomationKeywords
    {
        private readonly IWebDriver _driver;
        private readonly DefaultWait<IWebDriver> _wait;

        public AutomationKeywords(IWebDriver driver)
        {
            this._driver = driver;
            
            _wait = new DefaultWait<IWebDriver>(driver);
            _wait.IgnoreExceptionTypes(typeof(Exception));
            _wait.Timeout = TimeSpan.FromSeconds(20);
        }

        public void SendTextByLocator(By locator,string text)
        {
            //_driver.FindElement(locator).SendKeys(text);
            _wait.Until(x => x.FindElement(locator)).SendKeys(text);
        }

        public void ClickByLocator(By locator)
        {
            //_driver.FindElement(locator).Click();
            _wait.Until(x => x.FindElement(locator)).Click();
        }

        public string GetTextByLocator(By locator)
        {
            return _wait.Until(x => x.FindElement(locator)).Text;
        }

        public void SwitchToTabByTitle(string title)
        {
            ReadOnlyCollection<string> windows = _driver.WindowHandles;

            foreach (string win in windows)
            {
                _driver.SwitchTo().Window(win);
                if (_driver.Title.Equals(title))
                {
                    break;
                }
            }
        }
    }
}
