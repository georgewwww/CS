using BrowserStackHolder.Pages;
using BrowserStackHolder.Support;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace BrowserStackHolder.Steps
{
    [Binding]
    public class Task001Steps
    {
        private Website website;
        private readonly ITestOutputHelper output;

        public Task001Steps(Website website, ITestOutputHelper output)
        {
            this.website = website;
            this.output = output;
        }

        [Given(@"the link (.*)")]
        public void GivenTheLink(string link)
        {
            website.GoTo(link);
        }
        
        [When(@"enter the link provided")]
        public void WhenEnterTheLinkProvided()
        {
            website.PageLoaded();
        }
        
        [When(@"fill the search input with (.*)")]
        public void WhenFillTheSearchInputWithCalculator(string text)
        {
            website.EnterTextIntoInputField(PageName.Home, Element.SearchInput, text);
        }
        
        [When(@"press the search button")]
        public void WhenPressTheSearchButton()
        {
            website.ClickElementOnPage(PageName.Home, Element.SearchInput);
        }
        
        [When(@"leave the search input with empty string")]
        public void WhenLeaveTheSearchInputWithEmptyString()
        {
            website.EnterTextIntoInputField(PageName.Home, Element.SearchInput, string.Empty);
        }
        
        [Then(@"the google page is shown")]
        public void ThenTheGooglePageIsShown()
        {
            Assert.True(website.DoesElementExistOnPage(PageName.Home, Element.SearchLogo));
        }
        
        [Then(@"count how many results are on page")]
        public void ThenCountHowManyResultsAreOnPage()
        {
            website.PageLoaded();
            var count = website.GetElementsCountOnPage(PageName.Result, Element.ResultElementOnPage);
            output.WriteLine($"Results: {count}");
            Assert.True(count > 0);
        }
        
        [Then(@"page remains the same")]
        public void ThenPageRemainsTheSame()
        {
            Assert.True(website.DoesElementExistOnPage(PageName.Home, Element.SearchLogo));
        }
        
        [Then(@"result page is shown")]
        public void ThenResultPageIsShown()
        {
            website.PageLoaded();
        }
        
        [Then(@"do you mean link is present")]
        public void ThenDoYouMeanLinkIsPresent()
        {
            Assert.True(website.DoesElementExistOnPage(PageName.Result, Element.ResultYouMeanLink));
        }
    }
}
