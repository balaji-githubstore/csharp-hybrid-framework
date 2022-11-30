using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fujitsu.WebDriverKeywords.Base;
using OpenQA.Selenium.Edge;
using Fujitsu.OrangeAutomation.Pages;

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
            LoginPage loginPage = new LoginPage(driver);

            string actualUsernamePlaceholder = loginPage.GetUsernamePlaceholder();
            //string actualPasswordPlaceholder = driver.FindElement(By.CssSelector("[name='password']")).GetAttribute("placeholder");

            Assert.Multiple(() =>
            {
                Assert.That(actualUsernamePlaceholder, Is.EqualTo("Username"));
                Assert.That(loginPage.GetPasswordPlaceholder(), Is.EqualTo("Password"));
            }
            );
        }
    }
}
