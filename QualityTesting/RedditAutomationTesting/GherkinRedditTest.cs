using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;
using Xunit.Gherkin.Quick;

namespace RedditAutomationTesting
{
    [FeatureFile("./CalculatorSearch.feature")]
    public sealed class GherkinRedditTest : Feature
    {
        private IWebDriver driver;
        private IWebElement searchInput;

        public GherkinRedditTest()
        {
            var options = new ChromeOptions();
            options.AddArgument("--incognito");

            driver = new ChromeDriver(options);
        }

        [Given(@"I access (.*) website")]
        public void I_access_website(string website)
        {
            if (!website.Contains("http"))
            {
                website = "http://" + website;
            }

            driver.Navigate().GoToUrl(website);
        }

        [And(@"I insert (.*) keyword in the search-box")]
        public void I_insert_keyword_in_searchbox(string keyword)
        {
            searchInput = driver.FindElement(By.Id("header-search-bar"));
            searchInput.SendKeys(keyword);
        }

        [When(@"I press enter on keyboard")]
        public void I_press_enter_on_keyboard()
        {
            searchInput.SendKeys(Keys.Enter);
        }

        [Then(@"the page with posts about (.*) is shown")]
        public void The_page_with_posts_is_shown(string keyword)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(
                ExpectedConditions.ElementExists(By.ClassName("_3j9XjJayuKq7dJ8huVnCuS")));

            IWebElement resultElement = driver.FindElement(By.ClassName("_3j9XjJayuKq7dJ8huVnCuS"));
            Assert.Equal(keyword, resultElement.Text);
        }

        [And(@"I check the logo of the page")]
        public void I_check_the_logo_of_the_page()
        {
            IWebElement logoElement = driver.FindElement(By.ClassName("_30BbATRhFv3V83DHNDjJAO"));
            Assert.True(logoElement.Displayed);

            driver.Close();
        }
    }
}
