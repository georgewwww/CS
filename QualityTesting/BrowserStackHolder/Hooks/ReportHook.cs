using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;

namespace BrowserStackHolder.Hooks
{
    [Binding]
    public sealed class ReportHook
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenarioName;

        public ReportHook(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        private static ExtentTest featureName;
        private static ExtentReports extent;

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
            }
            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
            }
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(@".\");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            //Attach report to reporter
            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
        }

        [BeforeScenario]
        public void Initialize()
        {
            //Get feature Name
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);

            //Create dynamic scenario name
            _currentScenarioName = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void CleanUp()
        { }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }
    }
}
