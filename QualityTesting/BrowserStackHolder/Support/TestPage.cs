using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace BrowserStackHolder.Support
{
    public abstract class TestPage
    {
        public PageName Name { get; protected set; }
        protected IWebDriver WebDriver;
        protected Collection<Locator> Locators;

        protected void Setup(IWebDriver webDriver)
        {
            WebDriver = webDriver;
            Locators = InitializeLocators();
        }

        protected abstract Collection<Locator> InitializeLocators();

        public Locator GetLocator(Element element)
        {
            return Locators.FirstOrDefault(locator => locator.Element.Equals(element));
        }
    }
}
