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
            driver.FindElement(By.CssSelector("[name='password']")).SendKeys("Admin123");
            driver.FindElement(By.XPath("//button[normalize-space()='Login']")).Click();
            //click on PIM 
            //click on Add Employee
            //enter firstname as John
            //enter middlename as K 
            //enter lastame as wick
            //click on save

            //assert the added name shown in header
        }
    }
}
