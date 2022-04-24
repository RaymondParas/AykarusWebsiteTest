Feature: About

A section that provides a profile picture and a description of the owner

@AboutSection
Scenario: Verify profile picture and description
	Given I access the Aykarus website
	When I click the About navigation link
	Then I will see a profile picture
	And I will see a description
