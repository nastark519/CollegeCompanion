Feature: SpecFlowFeature1
	In order see searches work
	To make sure that the feature is working
	I want to see some of the Colleges searches.


Scenario: Search Oregon
	Given I am on https://collegecompanionapp.azurewebsites.net/
	And I have entered Oregon into the search bar
	When I press search
	Then the result should have <div style="float:left; width:20em;margin-right:2em;">

Scenario: Bold titles in search results
	Given I am logged in and have run a successful search either via the Index or the Form Search
	When I get back my search results
	Then the titles of the sections should be bold

Scenario: Remove "use another service" from log in
	Given I am attempting to Log In
	When I look at the text on the page
	Then I should not see the option to use another service

Scenario: Empty search returns results and error
	Given that I am in the Form Page
	When I don't fill in anything
	Then I should see an error page and no results

Scenario: Alphabetize Degree List
	Given that I am on the Form Page
	When I select the Degree List
	Then I should see the Degree List Alphabetized. 

Scenario: Align contact elements
	Given I am on the Contact page
	When I look at the text elements and member emails
	Then they should align nicely instead of stacking poorly over each other

Scenario: Fix that Any state returns no schools
	Given I am on https://collegecompanionapp.azurewebsites.net/Home/SearchForm
	When I select 'Any' state
	Then I should see colleges from any state.

Scenario: Clarify the Demographics controls
	Given I am logged in and have saved a college I can go to the Lifestyle page and click on the People link
	When I select a college from the drop down menu
	Then I should see an explanation about the following controls 

Scenario: Front page search shouldn't require clicking on top link to work
	Given I am on the Index page and it is the first time the site has been loaded
	When I type a state into the search bar
	Then I should get back results

Scenario: As a college student I want my data to be returned in pleasant and meaningful manners so I can understand the information 1. 
	Given I am logged in and have saved a college I can go to the Lifestyle page and click on the Food link
	When I select a college from the drop down menu
	Then a set of results showed up in panels instead of a table

Scenario: As a college student I want my data to be returned in pleasant and meaningful manners so I can understand the information 2.
	Given I am logged in and have saved a college I can go to the Lifestyle page and click on the People link
	When I select a college from the drop down menu
	Then a set of results showed up in a pie chart instead of a table

Scenario: Refactor stateinput test to dictionary for better efficiency
	Given I am running a search through the Index page
	When the state input is search for in the code
	Then it should be a dictionary not a complex if statement

Scenario: As a college student I want to be able to search for food options in my area and learn their hours, if they are currently open and know if they are in my price range so that I can decide where I want to eat 1.
	Given that I am logged in then on the Lifestyle page, and then on the Yelp page
	When I select a college and enter a term
	Then I then can check in for open businesses only. 

Scenario: As a college student I want to be able to search for food options in my area and learn their hours, if they are currently open and know if they are in my price range so that I can decide where I want to eat 2.
	Given hat I am logged in then on the Lifestyle page, and then on the Yelp page
	When I click search
	Then I should see results that provide me with prices.

Scenario: As a college student I want to be able to take a Quiz that helps me determine what degree or major I would be best suited for, so that if I'm still unsure I can get some guidance.
	Given I am on the Index page of the site and click on the button "Take the Quiz!"
	When I have selected a value for all radio buttons on the form and click the "Submit" button
	Then a popup will declare to me the degrees I am best suited for.

Scenario: tooltips that tells me what the fields in the advance search mean
	Given I am on https://collegecompanionapp.azurewebsites.net/Home/SearchForm
	When I hover the mouse over the lables
	Then a tool tip should pop up and go away when the mouse in no longer over that element

Scenario: I want to be able to do all Lifestyle searches based on a list of my saved colleges so that I don't have to enter things in manually.
	Given that I am logged in 
	And  I am on https://collegecompanionapp.azurewebsites.net/Home/SearchesMenu
	When click on each link (People, Food, Demographics)
	Then I can select a saved college from a list of saved colleges

Scenario: able to see multiple pages of my results
	Given I have entered a search that has more than 12 resalts
	When I click the 2 at the bottom of the page 
	Then I should see differant resalts that the original page returned

Scenario: I want to be able to click on a link for a college that takes me to their website
	Given I am https://collegecompanionapp.azurewebsites.net/Home/SearchResults?&schoolName=&state=Oregon%20OR&city=&accreditor=&ownership=1,2,3&lowerBound=0&upperBound=&cost=&acceptanceRate=0..&degree=Any&degreeType=Any
	When results are returned to me based upon my search
	Then I can select a link in the panel footer which will take me the individual college's website

Scenario: Acceptance Rate shouldn't show as N/A%
	Given I am on the Form Search Page
	When I search for a college
	Then I should not see any Acceptance rate with "N/A" 

Scenario: About page BG is too distracting
	Given I am on the About page 
	When I attempt to read the text 
	Then the background should not be too distracting so I can do so easily

Scenario: As a college student I want a custom error page instead of default ones, this way I know why things have gone wrong as it pertains to me or my activity.
	Given I am using the website
	When I run into an error in the site
	Then I should be presented a custom webpage and not the stack trace version

Scenario: As a college student, I want a captcha for my log in page so that I know my data is secure from bots.
	Given I am on https://collegecompanionapp.azurewebsites.net/Account/Register
	When I go to register a new account
	Then a captch test should insure that I am not a robot

Scenario: I want to be able to log into the site so I can find my saved colleges so I can view them later.
	Given I am a logged in user 
	And have already run a search
	And have saved a schools
	When I log out and log back in
	Then I should be able to see the colleges I've saved

Scenario: As a user is logged in they should be able to save a college
	Given I am loged in and am on a populated search 
	When I click on the heart icon for a given college
	Then I should be able to save that college

Scenario: As a user not logged in I should be presented with the Register page
	Given I am not logged in 
	When I try to save a college
	Then I should be redirected to https://collegecompanionapp.azurewebsites.net/Account/Register


































