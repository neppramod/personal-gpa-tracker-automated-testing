Feature: PersonalGPATrackerDeleteACourse
	In order to adjust overall GPA
	As a CS student
	I want to delete a course

Background:
	Given I setup a course seed
	And check the course in the list	
	And I navigate to the Course Delete page

@Normal_Flow
Scenario: Delete a course	
	When I issue the Delete Course command
	Then the page should go to home page and course deleted from the list

@Alternative_Flow
Scenario: Go back to list without deleting
	When I issue the Back to Course List link
	Then the page should go to home page