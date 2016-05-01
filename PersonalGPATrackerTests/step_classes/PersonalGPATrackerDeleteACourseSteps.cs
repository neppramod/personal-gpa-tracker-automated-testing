using NUnit.Framework;
using PersonalGPATracker.TestingFramework;
using System;
using TechTalk.SpecFlow;

namespace PersonalGPATrackerTests.step_classes
{
    [Binding]
    public class PersonalGPATrackerDeleteACourseSteps
    {
        [Given]
        public void GivenINavigateToTheCourseDeletePage()
        {
            GPATrackerCoursePage.GotoDelete();
        }

        [Then]
        public void ThenThePageShouldGoToHomePageAndCourseDeletedFromTheList()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));

            var couseListRowsCount = GPATrackerCoursePage.CourseListRowsCount;
            Assert.That(couseListRowsCount, Is.EqualTo(1));
        }
    }
}
