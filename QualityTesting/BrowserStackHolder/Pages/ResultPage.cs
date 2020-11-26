using BrowserStackHolder.Support;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace BrowserStackHolder.Pages
{
    public class ResultPage : TestPage
    {
        public ResultPage(IWebDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.Result;
        }

        protected override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator> {
                new Locator(Element.ResultElementOnPage, By.XPath("//*[@id=\"rso\"]/div")),
                new Locator(Element.ResultYouMeanLink, By.XPath("//*[@id=\"fprsl\"]"))
            };
        }
    }
}
