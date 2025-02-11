﻿using OpenQA.Selenium.Chrome;
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
using System.Diagnostics;
using OpenQA.Selenium.Support.Extensions;
using System.Buffers.Text;
using NUnit.Framework;
using Fujitsu.AutomationWrapperProject.Utilities;

namespace Fujitsu.WebDriverKeywords.Base
{
    public class AutomationWrapper
    {
        protected IWebDriver driver;
        private static ExtentReports extent;
        protected static ExtentTest test;
        protected static string projectPath;

        // protected IWebDriver Driver { get { return _driver; } }

        [OneTimeSetUp]
        public void Init()
        {

            if (extent == null)
            {

                projectPath = Directory.GetCurrentDirectory();
                projectPath = projectPath.Remove(projectPath.IndexOf("bin"));

                ExtentHtmlReporter reporter = new ExtentHtmlReporter(projectPath + @"Reports\index.html");
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

            string browserName = JsonUtils.GetValue(projectPath+@"TestData\data.json", "browser");



            if (browserName.ToLower().Equals("edge"))
            {
                driver = new EdgeDriver();
            }
            else if (browserName.ToLower().Equals("ff"))
            {
                driver = new FirefoxDriver();
            }
            else
            {
                driver = new ChromeDriver();
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            string baseUrl = JsonUtils.GetValue(projectPath + @"TestData\data.json", "url");

            driver.Navigate().GoToUrl(baseUrl);
        }

        [TearDown]
        public void AfterTest()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;

            if (testStatus == TestStatus.Failed)
            {
                string stackTrace = TestContext.CurrentContext.Result.StackTrace;
                string message = TestContext.CurrentContext.Result.Message;


                test.Log(Status.Fail, "Failed " + stackTrace + "</pre>" + message);
            }
            else if (testStatus == TestStatus.Passed)
            {
                test.Log(Status.Pass, "Passed - Snapshot Below");
            }
            else
            {
                test.Log(Status.Skip, "MyFirstTestCasePassed");
            }

            //Screenshot screenshot = driver.TakeScreenshot();
            //string base64=screenshot.AsBase64EncodedString;
            //test.AddScreenCaptureFromBase64String(base64);

            test.AddScreenCaptureFromBase64String(driver.TakeScreenshot().AsBase64EncodedString);

            //SaveScreenShot(TestContext.CurrentContext.Test.MethodName);
            driver.Quit();
        }

        public void SaveScreenShot(string screenshotName)
        {
            screenshotName = screenshotName + "_" + DateTime.Now.ToString().Replace(":", "-") + ".png";

            Screenshot screenshot = driver.TakeScreenshot();
            screenshot.SaveAsFile(projectPath + @"Screenshots\" + screenshotName);
        }
    }
}
