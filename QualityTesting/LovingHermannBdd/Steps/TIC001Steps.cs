using LovingHermannBdd.Core;
using LovingHermannBdd.Core.Components;
using Xunit;
using Xunit.Gherkin.Quick;

namespace LovingHermannBdd
{
    [FeatureFile("./Features/TIC-001.feature")]
    public class TIC001Steps : Feature
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

        [Then(@"A warning message is displayed under email input")]
        public void A_warning_message_is_displayed_under_email_input()
        {
            var warningPopup = SignIn.GetInvalidEmailInput();
            Assert.True(warningPopup.Displayed);
        }

        [And(@"I close the browser")]
        public void I_close_the_browser()
        {
            Driver.Instance.WebDriver.Close();
        }
    }
}
