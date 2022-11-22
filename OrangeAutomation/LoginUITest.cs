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

        [Test]
        public void VerifyUsernameAndPasswordPlaceholderTest()
        {
            string actualUsernamePlaceholder = driver.FindElement(By.Name("username")).GetAttribute("placeholder");
            string actualPasswordPlaceholder = driver.FindElement(By.CssSelector("[name='password']")).GetAttribute("placeholder");

            Assert.Multiple(() =>
            {
                Assert.That(actualUsernamePlaceholder, Is.EqualTo("Username"));
                Assert.That(actualPasswordPlaceholder, Is.EqualTo("Password"));
            }
            );
        }
    }
}
