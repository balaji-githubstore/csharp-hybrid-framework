using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fujitsu.OrangeAutomation.Base;

namespace Fujitsu.OrangeAutomation
{
    public class LoginUITest : AutomationWrapper
    {
        [Test]
        public void VerifyTitleTest()
        {
            Assert.That(driver.Title, Is.EqualTo("OrangeHRM"));
        }
    }
}
