using System;
using TechTalk.SpecFlow;
using BrowserStackHolder.Pages;
using BoDi;

namespace BrowserStackHolder.Hooks
{
    [Binding]
    public sealed class WebDriverHook : IDisposable
    {
        private readonly IObjectContainer objectContainer;
        private Website website;

        public WebDriverHook(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            website = new Website();
            objectContainer.RegisterInstanceAs(website);
        }

        [AfterScenario]
        public void Dispose()
        {
            website?.Dispose();
        }
    }
}
