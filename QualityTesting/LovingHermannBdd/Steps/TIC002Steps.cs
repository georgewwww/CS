using LovingHermannBdd.Core;
using LovingHermannBdd.Core.Components;
using Xunit;
using Xunit.Gherkin.Quick;

namespace LovingHermannBdd
{
    [FeatureFile("./Features/TIC-002.feature")]
    public class TIC002Steps : Feature
    {
        [Given(@"I launch Chrome browser")]
        public void I_launch_Chrome_browser()
        {
            Driver.Instance.Init();
        }

        [And(@"I open (.*) page")]
        public void I_open_page(string website)
        {
            Driver.Instance.Navigate(website);
        }

        [When(@"I press Sign In button")]
        public void I_press_Sign_In_button()
        {
            SignIn.GetSignInElement().Click();
        }

        [Then(@"Sign In popup is displayed")]
        public void Sign_In_popup_is_displayed()
        {
            var popup = SignIn.GetSignInElement();
            Assert.True(popup.Displayed);
        }

        [When(@"I fill the name input with '(.*)'")]
        public void I_fill_the_name_input_with(string name)
        {
            SignIn.SendNameInputText(name);
        }

        [And(@"I fill the email input with '(.*)'")]
        public void I_fill_the_email_input_with(string email)
        {
            SignIn.SendEmailInputText(email);
        }

        [And(@"I press Submit button")]
        public void I_press_Submit_button()
        {
            SignIn.PressSubmit();
        }

        [Then(@"The main page with logged data is displayed")]
        public void The_main_page_with_logged_data_is_displayed()
        {
            var logo = Header.GetWebsiteLogo();
            Assert.True(logo.Displayed);
        }

        [And(@"I close the browser")]
        public void I_close_the_browser()
        {
            Driver.Instance.WebDriver.Close();
        }
    }
}
