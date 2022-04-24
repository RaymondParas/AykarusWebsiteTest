Feature: Welcome

First section of the personal website introducing person and social media links

@WelcomeSection
Scenario: Verify social media links
	Given I access the Aykarus website
	When I click the Home navigation link
	Then I will see a GitHub link
	And I will see a LinkedIn link
