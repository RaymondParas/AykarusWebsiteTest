Feature: Projects

A section that provides a list of personal projects

@tag1
Scenario: Verify project count
	Given I access the Aykarus website
	When I click the Projects navigation link
	Then I will see 4 project cards
