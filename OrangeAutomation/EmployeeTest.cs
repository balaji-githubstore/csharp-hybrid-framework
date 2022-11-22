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

        public static object[] AddValidEmployeeData()
        {
            string[] dataSet1 = new string[6];
            dataSet1[0] = "admin";
            dataSet1[1] = "admin123";
            dataSet1[2] = "John";
            dataSet1[3] = "L";
            dataSet1[4] = "Wick";
            dataSet1[5] = "John Wick";

            string[] dataSet2 = new string[6];
            dataSet2[0] = "admin";
            dataSet2[1] = "admin123";
            dataSet2[2] = "Paul";
            dataSet2[3] = "k";
            dataSet2[4] = "Peter";
            dataSet2[5] = "Paul Peter";

            object[] allDataSet = new object[2];
            allDataSet[0] = dataSet1;
            allDataSet[1] = dataSet2;

            return allDataSet;
        }

        [Test,TestCaseSource(typeof(EmployeeTest),nameof(AddValidEmployeeData))]
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
            Assert.That(actualAddedName, Is.EqualTo(expectedName));
        }
    }
}
