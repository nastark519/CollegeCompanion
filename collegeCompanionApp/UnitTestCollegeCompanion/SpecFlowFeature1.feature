Feature: SpecFlowFeature1
	In order see searches for a state
	To make sure that the feature is working
	I want to see some of the Colleges form Oregon.

@mytag
Scenario: Add two numbers
	Given I am on https://collegecompanionapp.azurewebsites.net/
	And I have entered Oregon into the search bar
	When I press search
	Then the result should have <div style="float:left; width:20em;margin-right:2em;">
