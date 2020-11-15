using OpenQA.Selenium;

namespace LovingHermannBdd.Core.Components
{
    public class Header
    {
        private static readonly string logoPath = "/html/body/div[2]/div[1]/div[2]";

        public static IWebElement GetWebsiteLogo()
        {
            return Driver.Instance.WebDriver.FindElement(By.XPath(logoPath));
        }
    }
}
