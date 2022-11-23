using Fujitsu.OrangeAutomation.Base;
using Fujitsu.OrangeAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation
{
    public class LoginTest : AutomationWrapper
    {
        /// <summary>
        /// Test the valid login 
        /// </summary>
        /// <param name="username">pass valid username</param>
        /// <param name="password">pass valid password</param>
        /// <param name="expectedUrl">expected url after successful login</param>
        [Test, TestCaseSource(typeof(DataUtils), nameof(DataUtils.ValidLoginData))]
        // [TestCase("Admin","admin123", "https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index")]
        public void ValidLoginTest(string username,string password,string expectedUrl)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.CssSelector("[name='password']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();

            //wait for page load 

            //get the url and assert it
            string actualUrl = driver.Url;
            Assert.That(actualUrl,
                Is.EqualTo(expectedUrl));
        }

        [Test, TestCaseSource(typeof(DataUtils), nameof(DataUtils.InvalidLoginData))]
        //[TestCase("saul","saul123","Invalid credentials")]
        //[TestCase("kim", "kim123", "Invalid credentials")]
        //[TestCase("bala", "bala123", "Invalid credentials")]
        public void InvalidLoginTest(string username,string password,string expectedError)
        {
            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.CssSelector("[name='password']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();

            string actualError = driver.FindElement(By.XPath("//p[contains(@class,'oxd-alert')]")).Text;
            Assert.That(actualError, Is.EqualTo(expectedError));
        }
    }
}
