Feature: PersonalGPATrackerViewCourse
	In order to find details of a course
	As a CS student
	I want to view a course

Background:
	Given I setup a course seed
	And I navigate to the Course View page

@Normal_Flow
Scenario: View a course	
	When I issue the Back to Course List link
	Then the page should go to home page
