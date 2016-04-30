using NUnit.Framework;
using PersonalGPATracker.TestingFramework;
using System;
using TechTalk.SpecFlow;

/// <summary>
/// Assumption: When counting rows in the list page, count value = 1 is considered empty (couseListRowsCount)
/// (because first row contains the heading information of the table)
/// </summary>
namespace PersonalGPATrackerTests
{
    [Binding]
    public class PersonalGPATrackerCourseCRUDSteps
    {
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

        [Then]
        public void ThenThePageShouldGoToHomePageAndCourseAddedToList()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));

            var couseListRowsCount = GPATrackerCoursePage.CourseListRowsCount;            
            Assert.That(couseListRowsCount, Is.EqualTo(2));

            var addedCourseCode = GPATrackerCoursePage.AddedCourseCode;
            Assert.That(addedCourseCode, Contains.Substring("CSCI3110"));
        }

        [When]
        public void WhenIIssueTheBackToCourseListLink()
        {
            GPATrackerCoursePage.IssueBackToCourseListLink();
        }

        [Then]
        public void ThenThePageShouldGoToHomePageWithoutAddingTheCourseToTheList()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));

            var couseListRowsCount = GPATrackerCoursePage.CourseListRowsCount;            
            Assert.That(couseListRowsCount, Is.EqualTo(1));
        }

                
        [Then]
        public void ThenThePageShouldGoToHomePage()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));
        }
                

        [Then]
        public void ThenThePageShouldGoToAddCoursePageWithoutCourseUpdatedInTheList()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));

            var previouslyAddedCourseCode = GPATrackerCoursePage.AddedCourseCode;
            Assert.That(previouslyAddedCourseCode, Contains.Substring("CSCI3110"));
        }



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

            var editedCourseCode = GPATrackerCoursePage.AddedCourseCode;
            Assert.That(editedCourseCode, Contains.Substring("CSCI3111"));
        }

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


        [Given]
        public void GivenINavigateToTheCourseDeletePage()
        {            
            GPATrackerCoursePage.GotoDelete();
        }

        [When]
        public void WhenIIssueTheDeleteCourseCommand()
        {
            GPATrackerCoursePage.IssueDeleteCourseCommand();
        }

        [Then]
        public void ThenThePageShouldGoToHomePageAndCourseDeletedFromTheList()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));

            var couseListRowsCount = GPATrackerCoursePage.CourseListRowsCount;
            Assert.That(couseListRowsCount, Is.EqualTo(1));
        }

        [Given]
        public void GivenINavigateToTheCourseHomePage()
        {
            GPATrackerCoursePage.GotoHome();
        }

        [Given]
        public void GivenIViewEmptyCourseList()
        {
            var couseListRowsCount = GPATrackerCoursePage.CourseListRowsCount;
            Assert.That(couseListRowsCount, Is.EqualTo(1));
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

        [Then]
        public void ThenCourseShouldBeAddedToTheList()
        {
            var rowDetailOfACourse = GPATrackerCoursePage.RowDetailsOfACourse;
            Assert.That(rowDetailOfACourse, Is.EqualTo("CSCI3110 Advanced Web Design and Development 3 B- 2.7 8.1 Edit | Details | Delete"));
        }


        [Then]
        public void ThenTheTotalGPAShouldBeCalculatedUsingQualityPoints()
        {
            var totalGPA = GPATrackerCoursePage.TotalGPA;
            var totalQualityPoints = GPATrackerCoursePage.TotalQualityPoints;
            var totalCreditHours = GPATrackerCoursePage.TotalCreditHours;
            var totalGradePoints = GPATrackerCoursePage.TotalGradePoints;

            
            // Being careful as to not fail the test based on floating point precision error
            Assert.That(Math.Round(totalGPA, 2), Is.InRange(totalQualityPoints / totalCreditHours, 2.70));
            Assert.That(Math.Round(totalQualityPoints, 2), Is.InRange(8.09, totalCreditHours * totalGradePoints));
        }


        [When]
        public void WhenIIssueTheDetailsLinkInOneCourse()
        {
            GPATrackerCoursePage.IssueDetailsLinkInOneCourse();
        }

        [Then]
        public void ThenThePageShouldGoToDetailsPageOfThatCourse()
        {
            var courseDetailsPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseDetailsPageTitle, Is.EqualTo("Details of course: CSCI3110 - My ASP.NET Application"));
        }

        [When]
        public void WhenIIssueTheAddCourseMenuCommand()
        {
            GPATrackerCoursePage.IssueAddCourseMenuLink();
        }

        
        [Then]
        public void ThenThePageShouldGoToAddCoursePage()
        {
            var courseAddPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseAddPageTitle, Is.EqualTo("Add New Course - My ASP.NET Application"));
        }        

        [When]
        public void WhenIIssueTheDeleteLink()
        {
            GPATrackerCoursePage.IssueDeleteLink();
        }

        [Then]
        public void ThenThePageShouldGoToCourseDeletePage()
        {
            var deleteCoursePageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(deleteCoursePageTitle, Is.EqualTo("Delete course :CSCI3110 - My ASP.NET Application"));
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
        public void ThenThePageShouldRemainInCourseHomePage()
        {
            var courseListPageTitle = GPATrackerCoursePage.PageTitle;
            Assert.That(courseListPageTitle, Is.EqualTo("Course List and GPA - My ASP.NET Application"));
        }

        [Given]
        public void GivenCheckTheCourseInTheList()
        {
            var couseListRowsCount = GPATrackerCoursePage.CourseListRowsCount;            
            Assert.That(couseListRowsCount, Is.EqualTo(2));

            var addedCourseCode = GPATrackerCoursePage.AddedCourseCode;
            Assert.That(addedCourseCode, Contains.Substring("CSCI3110"));
        }

    }
}
