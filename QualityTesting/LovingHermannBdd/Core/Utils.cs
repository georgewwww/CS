using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace LovingHermannBdd.Core
{
    public class Utils
    {
        public static void WaitForClickable(By bySomething)
        {
            new WebDriverWait(Driver.Instance.WebDriver, TimeSpan.FromSeconds(3)).Until(
                ExpectedConditions.ElementToBeClickable(bySomething));
        }
    }
}
