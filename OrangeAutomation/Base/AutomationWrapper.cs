using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Fujitsu.OrangeAutomation.Base
{
    public class AutomationWrapper
    {
        protected IWebDriver driver;

       // protected IWebDriver Driver { get { return _driver; } }
        
        [SetUp]
        public void BeforeTest()
        {
            string browserName = "ch";

            if(browserName.ToLower().Equals("edge"))
            {
                driver = new EdgeDriver();
            }
            else if(browserName.ToLower().Equals("ff"))
            {
                driver = new FirefoxDriver();
            }
            else
            {
                driver = new ChromeDriver();
            }
            
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/");
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}
