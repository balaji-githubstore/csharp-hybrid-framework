using Fujitsu.OrangeAutomation.Base;
using Fujitsu.OrangeAutomation.Utilities;
using OpenQA.Selenium;
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
            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.CssSelector("[name='password']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();
            
            driver.FindElement(By.XPath("//span[text()='PIM']")).Click();
            driver.FindElement(By.LinkText("Add Employee")).Click();

            driver.FindElement(By.Name("firstName")).SendKeys(firstname);
            driver.FindElement(By.Name("middleName")).SendKeys(middlename);
            driver.FindElement(By.Name("lastName")).SendKeys(lastname);

            driver.FindElement(By.XPath("//button[normalize-space()='Save']")).Click();

            //not recommeded//need to update with fluent wait
            Thread.Sleep(8000);

            string actualAddedName = driver.FindElement(By.XPath("//div[@class='orangehrm-edit-employee-name']//h6")).Text;
            Assert.That(actualAddedName.ToLower(), Is.EqualTo(expectedName.ToLower()));
        }
    }
}
