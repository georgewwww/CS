using OpenQA.Selenium;

namespace LovingHermannBdd.Core.Components
{
    public class SignIn
    {
        private static readonly string signInElementPath = "//*[@id=\"home\"]/div/ul/li[1]/a";
        private static readonly string signInPopupPath = "//*[@id=\"myModal\"]/div/div";
        private static readonly string nameInputPath = "//*[@id=\"myModal\"]/div/div/div[2]/div[1]/form/div[1]/input";
        private static readonly string emailInputPath = "//*[@id=\"myModal\"]/div/div/div[2]/div[1]/form/div[2]/input";
        private static readonly string emailInputErrorPath = ".styled-input input:invalid";
        private static readonly string submitButtonPath = "//*[@id=\"myModal\"]/div/div/div[2]/div[1]/form/input";

        public static IWebElement GetSignInElement()
        {
            return Driver.Instance.WebDriver.FindElement(By.XPath(signInElementPath));
        }

        public static IWebElement GetSignInPopupElement()
        {
            return Driver.Instance.WebDriver.FindElement(By.XPath(signInPopupPath));
        }

        public static IWebElement GetInvalidEmailInput()
        {
            return Driver.Instance.WebDriver.FindElement(By.CssSelector(emailInputErrorPath));
        }

        public static void SendNameInputText(string name)
        {
            Utils.WaitForClickable(By.XPath(nameInputPath));

            Driver.Instance.WebDriver.FindElement(By.XPath(nameInputPath)).SendKeys(name);
        }

        public static void SendEmailInputText(string email)
        {
            Driver.Instance.WebDriver.FindElement(By.XPath(emailInputPath)).SendKeys(email);
        }

        public static void PressSubmit()
        {
            Driver.Instance.WebDriver.FindElement(By.XPath(submitButtonPath)).Click();
        }
    }
}
