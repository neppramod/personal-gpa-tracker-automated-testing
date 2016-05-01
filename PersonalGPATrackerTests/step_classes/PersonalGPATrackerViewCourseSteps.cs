using NUnit.Framework;
using PersonalGPATracker.TestingFramework;
using System;
using TechTalk.SpecFlow;

namespace PersonalGPATrackerTests.step_classes
{
    [Binding]
    public class PersonalGPATrackerViewCourseSteps
    {
        [Given]
        public void GivenINavigateToTheCourseViewPage()
        {
            GPATrackerCoursePage.GotoView();
        }

        [Given]
        public void GivenIViewDetailsOfACourse()
        {
            var detailsOfACourse = GPATrackerCoursePage.DetailsOfACourse;
            Assert.That(detailsOfACourse, Is.EqualTo("CSCI3110|Advanced Web Design and Development|3|B-|"));
        }

        [When]
        public void WhenIIssueTheDeleteCourseCommand()
        {
            GPATrackerCoursePage.IssueDeleteCourseCommand();
        }

        [When]
        public void WhenIIssueTheDeleteLink()
        {
            GPATrackerCoursePage.IssueDeleteLink();
        }

        [Then]
        public void ThenThePageShouldGoToHomePage()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));
        }


        [Then]
        public void ThenThePageShouldGoToCourseDeletePage()
        {
            var deleteCoursePageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(deleteCoursePageTitle, Is.EqualTo("Delete course :CSCI3110 - My ASP.NET Application"));
        }
    }
}
