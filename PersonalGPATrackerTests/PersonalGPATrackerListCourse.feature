﻿Feature: PersonalGPATrackerListCourse
	In order to view GPA
	As a CS student
	I want to add a course
	That updates Total GPA

Background:
	Given I navigate to the Course Home page

@Normal_Flow
Scenario: Update Total GPA
	Given I have added a new course	
	Then the total GPA should be greater than Zero

@TakeAction_Flow
Scenario: View Details of a course
	Given I have added a new course
	When I issue the Details link in one course
	Then the page should go to Details page of that Course
