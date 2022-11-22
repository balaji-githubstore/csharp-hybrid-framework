using Fujitsu.OrangeAutomation.Base;
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
        [Test]
        public void AddValidEmployeeTest()
        {
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.CssSelector("[name='password']")).SendKeys("admin123");
            driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();
            
            driver.FindElement(By.XPath("//span[text()='PIM']")).Click();
            driver.FindElement(By.LinkText("Add Employee")).Click();

            driver.FindElement(By.Name("firstName")).SendKeys("John");
            driver.FindElement(By.Name("middleName")).SendKeys("W");
            driver.FindElement(By.Name("lastName")).SendKeys("Wick");

            driver.FindElement(By.XPath("//button[normalize-space()='Save']")).Click();

            //not recommeded//need to update with fluent wait
            Thread.Sleep(8000);

            string actualAddedName = driver.FindElement(By.XPath("//div[@class='orangehrm-edit-employee-name']//h6")).Text;
            Assert.That(actualAddedName, Is.EqualTo("John Wick"));
        }
    }
}
