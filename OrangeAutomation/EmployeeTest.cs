using AventStack.ExtentReports;
using Fujitsu.OrangeAutomation.Base;
using Fujitsu.OrangeAutomation.Pages;
using Fujitsu.OrangeAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation
{
    public class EmployeeTest : AutomationWrapper
    {

        [Test,TestCaseSource(typeof(DataUtils),nameof(DataUtils.AddValidEmployeeData))]
        public void AddValidEmployeeTest(string username,string password,string firstname,string middlename,string lastname
            ,string expectedName)
        {
            LoginPage loginPage = new LoginPage(driver);

            loginPage.EnterUsername(username);
            test.Log(Status.Info, "Enter Username: " + username);

            loginPage.EnterPassword(password);
            test.Log(Status.Info, "Enter Password: " + password);

            loginPage.ClickOnLogin();
            test.Log(Status.Info, "Clicked On login");

            driver.FindElement(By.XPath("//span[text()='PIM']")).Click();
            test.Log(Status.Info, "Clicked On PIM");

            driver.FindElement(By.LinkText("Add Employee")).Click();
            test.Log(Status.Info, "Clicked On Add Employee");

            driver.FindElement(By.Name("firstName")).SendKeys(firstname);
            test.Log(Status.Info, "Enter firstName: " + firstname);

            driver.FindElement(By.Name("middleName")).SendKeys(middlename);
            test.Log(Status.Info, "Enter middlename: " + middlename);

            driver.FindElement(By.Name("lastName")).SendKeys(lastname);
            test.Log(Status.Info, "Enter lastname: " + lastname);

            driver.FindElement(By.XPath("//button[normalize-space()='Save']")).Click();
            test.Log(Status.Info, "Clicked On Save");

            //not recommeded//need to update with fluent wait
            Thread.Sleep(8000);

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Timeout = TimeSpan.FromSeconds(20);

            //wait.Until(x => x.FindElement(By.XPath("//div[@class='orangehrm-edit-employee-name']//h6")).Text == "");

            string actualAddedName = driver.FindElement(By.XPath("//div[@class='orangehrm-edit-employee-name']//h6")).Text;
            test.Log(Status.Info, "Actual Name shown in the System: "+ actualAddedName);

            Assert.That(actualAddedName.ToLower(), Is.EqualTo(expectedName.ToLower()));
        }
    }
}
