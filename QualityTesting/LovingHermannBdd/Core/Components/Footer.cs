using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace LovingHermannBdd.Core.Components
{
    public class Footer
    {
        private static readonly string facebookButtonPath = "/html/body/div[14]/div/div[1]/ul/li[1]/a";
        private static readonly string flickrButtonPostPath = "/html/body/div[14]/div/div[2]/div/div[3]/ul/li[1]/a";
        private static readonly string copyrightTextPath = "/html/body/div[14]/div/p";

        public static IWebElement GetFacebookButton()
        {
            return Driver.Instance.WebDriver.FindElement(By.XPath(facebookButtonPath));
        }

        public static IWebElement GetFirstFlickrPost()
        {
            return Driver.Instance.WebDriver.FindElement(By.XPath(flickrButtonPostPath));
        }

        public static IWebElement GetCopyrightText()
        {
            return Driver.Instance.WebDriver.FindElement(By.XPath(copyrightTextPath));
        }

        public static void MoveTo()
        {
            var actions = new Actions(Driver.Instance.WebDriver);
            var bottomElement = Driver.Instance.WebDriver.FindElement(By.XPath(copyrightTextPath));
            actions.MoveToElement(bottomElement).Perform();
        }
    }
}
