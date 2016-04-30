Feature: PersonalGPATrackerTitleBar
	In order to calculate GPA
	As a CS student
	I want to navigate to various pages of the web site

Background:
	Given I navigate to the Course Home page

@Normal_Flow
Scenario: Go to add course page
	When I issue the Add Course menu command
	Then the page should go to add course page

@Alternative_Flow
Scenario: Remain in home page
	When I issue Personal GPA Tracker menu command
	And I issue Home menu command
	And I issue User's name command
	Then the page should remain in Course Home page
