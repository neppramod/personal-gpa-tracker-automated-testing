Feature: PersonalGPATrackerEditCourse
	In order to calculate overall GPA
	As a CS student
	I want to edit a course

Background:
	Given I setup a course seed
	And check the course in the list
	And I navigate to the Course Edit page

@Normal_Flow
Scenario: Edit a course
	Given I have entered CSCI3111 as the Code	
		And I have entered Basic Web Design and Development as the Title
		And I have selected 6 as the Credit Hours
		And I have selected A- as the Letter Grade
	When I issue the Update Course command
	Then the page should go to home page and course updated in the list

@Alternative_Flow
Scenario: Go to home without updating a course
	Given I have entered CSCI3111 as the Code
		And I have entered Basic Web Design and Development as the Title
		And I have selected 6 as the Credit Hours
		And I have selected A- as the Letter Grade
	When I issue the Back to Course List link
	Then the page should go to add course page without course updated in the list

