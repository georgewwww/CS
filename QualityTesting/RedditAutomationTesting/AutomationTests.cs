using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace RedditAutomationTesting
{
    public class AutomationTests
    {
        private readonly IWebDriver driver;
        private readonly string searchingObject = "calculator";

        public AutomationTests()
        {
            var options = new ChromeOptions();
            options.AddArgument("--incognito");

            driver = new ChromeDriver(options);
        }

        [Fact]
        public void CalculatorSearchTest()
        {
            // navigate to reddit homepage
            driver.Navigate().GoToUrl("https://www.reddit.com/");

            // find search bar element
            IWebElement searchInput = driver.FindElement(By.Id("header-search-bar"));
            searchInput.SendKeys(searchingObject);
            searchInput.SendKeys(Keys.Enter);

            // wait for page to change
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(
                ExpectedConditions.ElementExists(By.ClassName("_3j9XjJayuKq7dJ8huVnCuS")));

            // get and assert the searched keyword
            IWebElement resultElement = driver.FindElement(By.ClassName("_3j9XjJayuKq7dJ8huVnCuS"));
            Assert.Equal(searchingObject, resultElement.Text);

            // get and check if is displayed
            IWebElement logoElement = driver.FindElement(By.ClassName("_30BbATRhFv3V83DHNDjJAO"));
            Assert.True(logoElement.Displayed);

            // cleanup
            driver.Close();
        }
    }
}
