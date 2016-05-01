using NUnit.Framework;
using PersonalGPATracker.TestingFramework;
using System;
using TechTalk.SpecFlow;

namespace PersonalGPATrackerTests.step_classes
{
    [Binding]
    public class PersonalGPATrackerTitleBarSteps
    {
        [When]
        public void WhenIIssueTheAddCourseMenuCommand()
        {
            GPATrackerCoursePage.IssueAddCourseMenuLink();
        }

        [When]
        public void WhenIIssuePersonalGPATrackerMenuCommand()
        {
            GPATrackerCoursePage.IssuePersonalGPATrackerMenuCommand();
        }

        [When]
        public void WhenIIssueHomeMenuCommand()
        {
            GPATrackerCoursePage.IssueHomeMenuCommand();
        }

        [When]
        public void WhenIIssueUserSNameCommand()
        {
            GPATrackerCoursePage.IssueUserSNameCommand();
        }

        [Then]
        public void ThenThePageShouldGoToAddCoursePage()
        {
            var courseAddPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseAddPageTitle, Is.EqualTo("Add New Course - My ASP.NET Application"));
        }

        [Then]
        public void ThenThePageShouldRemainInCourseHomePage()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));
        }
    }
}
