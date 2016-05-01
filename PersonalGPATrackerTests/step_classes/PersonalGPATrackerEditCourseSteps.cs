using NUnit.Framework;
using PersonalGPATracker.TestingFramework;
using System;
using TechTalk.SpecFlow;

namespace PersonalGPATrackerTests.step_classes
{
    [Binding]
    public class PersonalGPATrackerEditCourseSteps
    {
        [Given]
        public void GivenISetupACourseSeed()
        {
            GPATrackerCoursePage.GotoAdd();
            GPATrackerCoursePage.Code = "CSCI3110";
            GPATrackerCoursePage.Title = "Advanced Web Design and Development";
            GPATrackerCoursePage.CreditHours = "3";
            GPATrackerCoursePage.LetterGrade = "B-";
            GPATrackerCoursePage.IssueAddCourseCommand();
        }


        [Given]
        public void GivenCheckTheCourseInTheList()
        {
            var couseListRowsCount = GPATrackerCoursePage.CourseListRowsCount;
            Assert.That(couseListRowsCount, Is.EqualTo(2));

            var rowDetailOfACourse = GPATrackerCoursePage.RowDetailsOfACourse;
            Assert.That(rowDetailOfACourse, Is.EqualTo("CSCI3110 Advanced Web Design and Development 3 B- 2.7 8.1 Edit | Details | Delete"));
        }

        [Given]
        public void GivenINavigateToTheCourseEditPage()
        {
            GPATrackerCoursePage.GotoEdit();
        }

        [When]
        public void WhenIIssueTheUpdateCourseCommand()
        {
            GPATrackerCoursePage.IssueUpdateCourseCommand();
        }

        [Then]
        public void ThenThePageShouldGoToHomePageAndCourseUpdatedInTheList()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));

            var rowDetailOfACourse = GPATrackerCoursePage.RowDetailsOfACourse;
            Assert.That(rowDetailOfACourse, Is.EqualTo("CSCI3111 Basic Web Design and Development 6 A- 3.7 22.2 Edit | Details | Delete"));
        }

        [Then]
        public void ThenThePageShouldGoToAddCoursePageWithoutCourseUpdatedInTheList()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));

            var rowDetailOfACourse = GPATrackerCoursePage.RowDetailsOfACourse;
            Assert.That(rowDetailOfACourse, Is.EqualTo("CSCI3110 Advanced Web Design and Development 3 B- 2.7 8.1 Edit | Details | Delete"));
        }
    }
}
