using NUnit.Framework;
using PersonalGPATracker.TestingFramework;
using System;
using TechTalk.SpecFlow;

namespace PersonalGPATrackerTests.step_classes
{
    [Binding]
    public class PersonalGPATrackerListCourseSteps
    {
        // Setup and Teardown for the whole project.        
        [Before]
        public static void Setup()
        {
            GPATrackerCoursePage.Initialize();
        }

        [After]
        public static void Teardown()
        {
            GPATrackerCoursePage.EndTest();
        }

        [Given]
        public void GivenINavigateToTheCourseHomePage()
        {
            GPATrackerCoursePage.GotoHome();
        }

        [Given]
        public void GivenIHaveAddedANewCourse()
        {
            // Although the code is similar to GivenISetupACourseSeed, this is a different functionality
            GPATrackerCoursePage.GotoAdd();
            GPATrackerCoursePage.Code = "CSCI3110";
            GPATrackerCoursePage.Title = "Advanced Web Design and Development";
            GPATrackerCoursePage.CreditHours = "3";
            GPATrackerCoursePage.LetterGrade = "B-";
            GPATrackerCoursePage.IssueAddCourseCommand();
        }

        [Given]
        public void GivenIHaveAddedOneMoreCourse()
        {
            GPATrackerCoursePage.GotoAdd();
            GPATrackerCoursePage.Code = "CSCI3111";
            GPATrackerCoursePage.Title = "Basic Web Design and Development";
            GPATrackerCoursePage.CreditHours = "6";
            GPATrackerCoursePage.LetterGrade = "A-";
            GPATrackerCoursePage.IssueAddCourseCommand();
        }


        [When]
        public void WhenIIssueTheDetailsLinkInOneCourse()
        {
            GPATrackerCoursePage.IssueDetailsLinkInOneCourse();
        }

        [Then]
        public void ThenTheTotalGPAShouldBeCalculatedUsingQualityPoints()
        {
            var totalGPA = GPATrackerCoursePage.TotalGPA;
            var totalQualityPoints = GPATrackerCoursePage.TotalQualityPoints;
            var totalCreditHours = GPATrackerCoursePage.TotalCreditHours;
            var totalGradePoints = GPATrackerCoursePage.TotalGradePoints;

            Assert.That(totalGradePoints, Is.EqualTo(6.4));
            Assert.That(totalCreditHours, Is.EqualTo(9));

            // Being careful as to not fail the test based on floating point precision error
            Assert.That(Math.Round(totalQualityPoints, 2), Is.EqualTo(30.30));
            Assert.That(Math.Round(totalGPA, 2), Is.EqualTo(Math.Round(totalQualityPoints / totalCreditHours, 2)));            
        }

        [Then]
        public void ThenThePageShouldGoToDetailsPageOfThatCourse()
        {
            var courseDetailsPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseDetailsPageTitle, Is.EqualTo("Details of course: CSCI3110 - My ASP.NET Application"));
        }

        [Then]
        public void ThenCourseShouldBeAddedToTheList()
        {
            var rowDetailOfACourse = GPATrackerCoursePage.RowDetailsOfACourse;
            Assert.That(rowDetailOfACourse, Is.EqualTo("CSCI3110 Advanced Web Design and Development 3 B- 2.7 8.1 Edit | Details | Delete"));
        }
    }
}
