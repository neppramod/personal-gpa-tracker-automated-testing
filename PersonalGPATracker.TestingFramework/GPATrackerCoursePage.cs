using PersonalGPATracker.WebDriverFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalGPATracker.TestingFramework
{
    public static class GPATrackerCoursePage
    {
        private const string URL_PORT = "http://localhost:9090/";

        private const string AddUrl = URL_PORT + "Course/Add";
        private const string EditUrl = URL_PORT + "Course/Edit/CSCI3110";
        private const string ViewUrl = URL_PORT + "Course/Details/CSCI3110";
        private const string DeleteUrl = URL_PORT + "Course/Delete/CSCI3110";
        private const string HomeUrl = URL_PORT + "Home/Index";

        public static string Code { set { Chrome.Code = value; } }

        public static string Title { set { Chrome.Title = value; } }

        public static string CreditHours { set { Chrome.CreditHours = value; } }

        public static string LetterGrade { set { Chrome.LetterGrade = value; } }

        public static object PageTitle { get { return Chrome.PageTitle; } }

        public static object AddedCourseCode { get { return Chrome.AddedCourseCode; } }

        public static double TotalGPA { get { return Chrome.TotalGPA; } }

        public static object CourseListRowsCount { get { return Chrome.CourseListRowsCount; } }

        public static object DetailsOfACourse { get { return Chrome.DetailsOfACourse; } }

        public static double TotalQualityPoints { get { return Chrome.TotalQualityPoints; } }
        public static int TotalCreditHours { get { return Chrome.TotalCreditHours; } }

        public static double TotalGradePoints { get { return Chrome.TotalGradePoints; } }

        public static object RowDetailsOfACourse { get { return Chrome.RowDetailsOfACourse; } }

        public static void Initialize()
        {
            Chrome.Create();
        }

        public static void EndTest()
        {
            Chrome.Quit();
        }

        public static void GotoAdd()
        {
            Chrome.Goto(AddUrl);
        }

        public static void IssueAddCourseCommand()
        {
            Chrome.ClickAddCourseButton();
        }

        public static void IssueBackToCourseListLink()
        {
            Chrome.ClickBackToCourseListLink();
        }

        public static void GotoEdit()
        {
            Chrome.Goto(EditUrl);
        }

        public static void IssueUpdateCourseCommand()
        {
            Chrome.ClickUpdateCourseButton();
        }

        public static void GotoView()
        {
            Chrome.Goto(ViewUrl);
        }

        public static void GotoDelete()
        {
            Chrome.Goto(DeleteUrl);
        }

        public static void IssueDeleteCourseCommand()
        {
            Chrome.ClickDeleteCourseButton();
        }

        public static void GotoHome()
        {
            Chrome.Goto(HomeUrl);
        }

        public static void IssueDetailsLinkInOneCourse()
        {
            Chrome.ClickDetailsLink();
        }

        public static void IssueAddCourseMenuLink()
        {
            Chrome.ClickAddCourseMenuLink();
        }

        public static void IssueDeleteLink()
        {
            Chrome.ClickDeleteLink();
        }

        public static void IssuePersonalGPATrackerMenuCommand()
        {
            Chrome.ClickPersonalGPATrackerMenuCommand();
        }

        public static void IssueHomeMenuCommand()
        {
            Chrome.ClickHomeMenuCommand();
        }

        public static void IssueUserSNameCommand()
        {
            Chrome.ClickUserSNameCommand();
        }
    }
}
