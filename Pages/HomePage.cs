using AykarusWebsiteTest.Support;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace AykarusWebsiteTest.Pages
{
    public class HomePage : BasePage
    {
        private const string homeNavigationLinkCSS = "a[href='#welcome']";
        private const string aboutNavigationLinkCSS = "a[href='#about']";
        private const string projectsNavigationLinkCSS = "a[href='#projects']";
        private const string gitHubProfileLinkCSS = "a[href*='github'][href$='Aykarus']";
        private const string linkedInProfileLinkCSS = "a[href*='linkedin']";
        private const string profilePictureImageCSS = "section[id='about'] img";
        private const string aboutDescriptionTextCSS = "section[id='about'] p";
        private const string projectCardsCSS = "section[id='projects'] .card-holder .project-card";

        public HomePage(IWebDriver driver) : base(driver) { }

        private IWebElement HomeNavigationLink => Driver.WaitUntilClickable(By.CssSelector(homeNavigationLinkCSS));
        private IWebElement AboutNavigationLink => Driver.WaitUntilClickable(By.CssSelector(aboutNavigationLinkCSS));
        private IWebElement ProjectsNavigationLink => Driver.WaitUntilClickable(By.CssSelector(projectsNavigationLinkCSS));
        private IWebElement GitHubProfileLink => Driver.WaitUntilClickable(By.CssSelector(gitHubProfileLinkCSS));
        private IWebElement LinkedInProfileLink => Driver.WaitUntilClickable(By.CssSelector(linkedInProfileLinkCSS));
        private IWebElement AboutDescriptionText => Driver.FindElementExt(By.CssSelector(aboutDescriptionTextCSS));
        private ReadOnlyCollection<IWebElement> ProjectCards => Driver.FindElements(By.CssSelector(projectCardsCSS));

        public void ClickHomeNavigationLink()
        {
            HomeNavigationLink.Click();
        }

        public void ClickAboutNavigationLink()
        {
            AboutNavigationLink.Click();
        }

        public void ClickProjectsNavigationLink()
        {
            ProjectsNavigationLink.Click();
        }

        public bool VerifyGitHubProfileLink()
        {
            return GitHubProfileLink.Displayed && GitHubProfileLink.Enabled;
        }

        public bool VerifyLinkedInProfileLink()
        {
            return LinkedInProfileLink.Displayed && LinkedInProfileLink.Enabled;
        }

        public void VerifyProfilePicture()
        {
            Driver.WaitUntilVisible(By.CssSelector(profilePictureImageCSS));
        }

        public bool VerifyDescriptionIsNotEmpty()
        {
            Driver.WaitForText(By.CssSelector(aboutDescriptionTextCSS));
            Console.WriteLine(AboutDescriptionText.Text);

            return !string.IsNullOrWhiteSpace(AboutDescriptionText.Text);
        }

        public int GetProjectCardsCount()
        {
            Console.WriteLine($"Project Card Count: {ProjectCards.Count}");
            return ProjectCards.Count;
        }
    }
}
