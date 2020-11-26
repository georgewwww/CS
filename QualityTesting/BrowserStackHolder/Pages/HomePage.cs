using BrowserStackHolder.Support;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace BrowserStackHolder.Pages
{
    public class HomePage : TestPage
    {
        public HomePage(IWebDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.Home;
        }

        protected override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
                new Locator(Element.SearchLogo, By.XPath("//*[@id=\"hplogo\"]")),
                new Locator(Element.SearchInput, By.XPath("//*[@id=\"tsf\"]/div[2]/div[1]/div[1]/div/div[2]/input"))
            };
        }
    }
}
