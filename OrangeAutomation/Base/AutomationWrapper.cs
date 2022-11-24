using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using DocumentFormat.OpenXml.InkML;
using System.Diagnostics;

namespace Fujitsu.OrangeAutomation.Base
{
    public class AutomationWrapper
    {
        protected IWebDriver driver;
        private static ExtentReports extent;
        protected static ExtentTest test;

        // protected IWebDriver Driver { get { return _driver; } }

        [OneTimeSetUp]
        public void Init()
        {
        
           if (extent == null) {

                string projectPath = Directory.GetCurrentDirectory();
                projectPath = projectPath.Remove(projectPath.IndexOf("bin"));

                ExtentHtmlReporter reporter = new ExtentHtmlReporter(projectPath+@"Reports\index.html");
                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }
        }

        [OneTimeTearDown]
        public void End()
        {
            extent.Flush();
        }
        
        [SetUp]
        public void BeforeTest()
        {

            //  test = extent.CreateTest(TestContext.CurrentContext.Test.ClassName+"."+ TestContext.CurrentContext.Test.Name);
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

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
           string testName= TestContext.CurrentContext.Test.Name;
           TestStatus testStatus= TestContext.CurrentContext.Result.Outcome.Status;

            if(testStatus==TestStatus.Failed)
            {
                string stackTrace = TestContext.CurrentContext.Result.StackTrace;
                string message = TestContext.CurrentContext.Result.Message;


                test.Log(Status.Fail, "Failed "+stackTrace+"</pre>"+message);
            }
            else if(testStatus==TestStatus.Passed)
            {
                test.Log(Status.Pass, "Passed - Snapshot Below");
            }
            else
            {
                test.Log(Status.Skip, "MyFirstTestCasePassed");
            }
            

            driver.Quit();
        }
    }
}
