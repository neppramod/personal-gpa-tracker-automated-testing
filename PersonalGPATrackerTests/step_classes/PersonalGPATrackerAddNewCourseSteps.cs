using NUnit.Framework;
using PersonalGPATracker.TestingFramework;
using System;
using TechTalk.SpecFlow;

namespace PersonalGPATrackerTests.step_classes
{
    [Binding]
    public class PersonalGPATrackerAddNewCourseSteps
    {
        [Given]
        public void GivenIViewEmptyCourseList()
        {
            var couseListRowsCount = GPATrackerCoursePage.CourseListRowsCount;
            Assert.That(couseListRowsCount, Is.EqualTo(1));
        }

        [Given]
        public void GivenINavigateToTheCourseAddPage()
        {
            GPATrackerCoursePage.GotoAdd();
        }

        [Given]
        public void GivenIHaveEntered_CODE_AsTheCode(string code)
        {
            GPATrackerCoursePage.Code = code;
        }

        [Given]
        public void GivenIHaveEntered_TITLE_AsTheTitle(string title)
        {
            GPATrackerCoursePage.Title = title;
        }

        [Given]
        public void GivenIHaveSelected_CREDITHOURS_AsTheCreditHours(int creditHours)
        {
            GPATrackerCoursePage.CreditHours = Convert.ToString(creditHours);
        }

        [Given]
        public void GivenIHaveSelected_LETTERGRADE_AsTheLetterGrade(string letterGrade)
        {
            GPATrackerCoursePage.LetterGrade = letterGrade;
        }

        [When]
        public void WhenIIssueTheAddCourseCommand()
        {
            GPATrackerCoursePage.IssueAddCourseCommand();
        }

        [When]
        public void WhenIIssueTheBackToCourseListLink()
        {
            GPATrackerCoursePage.IssueBackToCourseListLink();
        }

        [Then]
        public void ThenThePageShouldGoToHomePageAndCourseAddedToList()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));

            var couseListRowsCount = GPATrackerCoursePage.CourseListRowsCount;
            Assert.That(couseListRowsCount, Is.EqualTo(2));

            var rowDetailOfACourse = GPATrackerCoursePage.RowDetailsOfACourse;
            Assert.That(rowDetailOfACourse, Is.EqualTo("CSCI3110 Advanced Web Design and Development 3 B- 2.7 8.1 Edit | Details | Delete"));
        }


        [Then]
        public void ThenThePageShouldGoToHomePageWithoutAddingTheCourseToTheList()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));

            var couseListRowsCount = GPATrackerCoursePage.CourseListRowsCount;
            Assert.That(couseListRowsCount, Is.EqualTo(1));
        }
    }
}
