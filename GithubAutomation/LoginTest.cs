using Fujitsu.WebDriverKeywords.Base;
using OpenQA.Selenium;

namespace GithubAutomation
{
    public class LoginTest : AutomationWrapper
    {
    
        [Test]
        public void InvalidLoginTest()
        {
            driver.FindElement(By.PartialLinkText("Sign in")).Click();
        }
    }
}