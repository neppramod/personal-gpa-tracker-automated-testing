using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalGPATracker.WebDriverFramework
{
    public static class Chrome
    {
        private static string DRIVER_PATH = @"C:\ApplicationInstalled\chromedriver_win32";
        private static IWebDriver _page = null;

        public static string Code
        {
            set
            {
                var codeElement = _page.FindElement(By.Id("Code"));
                codeElement.Clear();
                codeElement.SendKeys(value);
            }
        }

        public static string Title
        {
            set
            {
                var titleElement = _page.FindElement(By.Id("Title"));
                titleElement.Clear();
                titleElement.SendKeys(value);
            }
        }

        public static string CreditHours
        {
            set
            {
                var creditHoursElement = _page.FindElement(By.Id("CreditHours"));                
                creditHoursElement.SendKeys(value);
            }
        }

        public static void ClickBackToCourseListLink()
        {
            var backToCourseListLink = _page.FindElement(By.CssSelector(
                @"a[href='/']"));
            backToCourseListLink.Click();
        }

        public static string LetterGrade
        {
            set
            {
                var letterGradeElement = _page.FindElement(By.Id("LetterGrade"));
                letterGradeElement.SendKeys(value);
            }
        }

        public static void ClickUpdateCourseButton()
        {
            var updateCourseButton = _page.FindElement(By.CssSelector(
                @"body > div.container.body-content > form > div > div:nth-child(6) > div > input"));
            updateCourseButton.Click();
        }

        public static object PageTitle { get { return _page.Title; } }

        public static object AddedCourseCode
        {
            get
            {            
                var addedCourseElement = _page.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr[2]"));
                return addedCourseElement.Text;
            }
        }

        public static double TotalGPA
        {
            get
            {
                var totalGPAH1 = _page.FindElement(By.CssSelector("body > div.container.body-content > h1"));
                var selectedSubText = totalGPAH1.Text.Substring(totalGPAH1.Text.Length - 4);
                return Convert.ToDouble(selectedSubText);                
            }
        }

        public static int CourseListRowsCount
        {
            get
            {
                return _page.FindElements(By.CssSelector("body > div.container.body-content > table > tbody > tr")).Count;                                
            }
        }

        public static object DetailsOfACourse
        { 
            get
            {
                var detailElements = _page.FindElements(By.CssSelector("body > div.container.body-content > div > dl > dd"));
                var detailsOfACourse = "";

                foreach (var dd in detailElements)
                {
                    detailsOfACourse += dd.Text + "|";
                }

                return detailsOfACourse;
            }
        }

        public static void ClickDeleteLink()
        {
            var deleteCourseLink = _page.FindElement(By.CssSelector(
                @"body > div.container.body-content > p > a:nth-child(2)"));
            deleteCourseLink.Click();
        }

        public static void ClickHomeMenuCommand()
        {
            var homeMenuCommand = _page.FindElement(By.CssSelector(
                @"body > div.navbar.navbar-inverse.navbar-fixed-top > div > div.navbar-collapse.collapse > ul > li:nth-child(1) > a"));
            homeMenuCommand.Click();
        }

        public static void ClickUserSNameCommand()
        {
            var usersNameCommand = _page.FindElement(By.CssSelector(
                @"body > div.navbar.navbar-inverse.navbar-fixed-top > div > div.navbar-collapse.collapse > ul > li:nth-child(3) > a"));
            usersNameCommand.Click();
        }

        public static void ClickPersonalGPATrackerMenuCommand()
        {
            var personalGPATrackerMenuCommand = _page.FindElement(By.CssSelector(
                @"body > div.navbar.navbar-inverse.navbar-fixed-top > div > div.navbar-header > a"));
            personalGPATrackerMenuCommand.Click();
        }

        public static void ClickAddCourseMenuLink()
        {
            var addCourseLink = _page.FindElement(By.CssSelector(
                @"body > div.navbar.navbar-inverse.navbar-fixed-top > div > div.navbar-collapse.collapse > ul > li:nth-child(2) > a"));
            addCourseLink.Click();
        }

        public static void ClickDetailsLink()
        {
            var detailsLink = _page.FindElement(By.CssSelector(
                @"body > div.container.body-content > table > tbody > tr:nth-child(2) > td:nth-child(7) > a:nth-child(2)"));
            detailsLink.Click();

        }

        public static void ClickDeleteCourseButton()
        {
            var deleteCourseButton = _page.FindElement(By.CssSelector(
                @"body > div.container.body-content > div > form > div > input.btn.btn-danger"));
            deleteCourseButton.Click();
        }

        public static void ClickAddCourseButton()
        {
            var addCourseButton = _page.FindElement(By.CssSelector(
                @"body > div.container.body-content > form > div > div:nth-child(5) > div > input"));
            addCourseButton.Click();
        }        

        public static void Create()
        {
            _page = new ChromeDriver(DRIVER_PATH);
        }

        public static void Quit()
        {
            Thread.Sleep(1000);
            _page.Dispose();
            _page.Quit();
        }

        public static void Goto(string url)
        {
            _page.Navigate().GoToUrl(url);
        }
    }
}
