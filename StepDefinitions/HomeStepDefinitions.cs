using AykarusWebsiteTest.Pages;
using AykarusWebsiteTest.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace AykarusWebsiteTest.StepDefinitions
{
    [Binding]
    public class HomeStepDefinitions
    {
        private readonly TestContext _testContext;
        private readonly DriverHelper _driverHelper;
        private readonly HomePage _homePage;

        public HomeStepDefinitions(TestContext testContext, DriverHelper driverHelper)
        {
            _testContext = testContext;
            _driverHelper = driverHelper;
            _homePage = new HomePage(_driverHelper.Driver);
        }

        [Given(@"I access the Aykarus website")]
        public void GivenIAccessTheAykarusWebsite()
        {
            _homePage.GoTo(_testContext.Properties["AykarusURL"]?.ToString() ?? string.Empty);
        }

        [When(@"I click the Home navigation link")]
        public void WhenIClickTheHomeNavigationLink()
        {
            _homePage.ClickHomeNavigationLink();
        }

        [When(@"I click the About navigation link")]
        public void WhenIClickTheAboutNavigationLink()
        {
            _homePage.ClickAboutNavigationLink();
        }

        [When(@"I click the Projects navigation link")]
        public void WhenIClickTheProjectsNavigationLink()
        {
            _homePage.ClickProjectsNavigationLink();
        }

        [Then(@"I will see a GitHub link")]
        public void ThenIWillSeeAGitHubLink()
        {
            Assert.IsTrue(_homePage.VerifyGitHubProfileLink());
        }

        [Then(@"I will see a LinkedIn link")]
        public void ThenIWillSeeALinkedInLink()
        {
            Assert.IsTrue(_homePage.VerifyLinkedInProfileLink());
        }

        [Then(@"I will see a profile picture")]
        public void ThenIWillSeeAProfilePicture()
        {
            _homePage.VerifyProfilePicture();
        }

        [Then(@"I will see a description")]
        public void ThenIWillSeeADescription()
        {
            Assert.IsTrue(_homePage.VerifyDescriptionIsNotEmpty());
        }

        [Then(@"I will see (.*) project cards")]
        public void ThenIWillSeeProjectCards(int projectCardCount)
        {
            Assert.AreEqual(projectCardCount, _homePage.GetProjectCardsCount());
        }

    }
}

