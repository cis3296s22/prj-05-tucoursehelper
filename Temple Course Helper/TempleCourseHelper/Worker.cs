using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace TempleCourseHelper
{
    internal class Worker
    {
        CourseDetails course1Details = new CourseDetails();
        Dictionary<string, CourseDetails> Course = new Dictionary<string, CourseDetails>();
        String URL = "https://www.coursicle.com/";


        public Dictionary<string, CourseDetails> searchCatalog()
        {
            //Open Chrome "headless" or not visible to user
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");

            //Add chrom exe location
            //driver = new ChromeDriver(chromeOptions);
            IWebDriver driver = new ChromeDriver(@"../../" + "/Driver/");

            //Goes to Coursicle
            driver.Navigate().GoToUrl(URL);
            Thread.Sleep(3);

            //Searches Temple
            driver.FindElement(By.Id("tileSearchBoxInput")).SendKeys("Temple"); ;
            Thread.Sleep(5);
            //Goes to Temple Coursicle
            driver.FindElement(By.XPath("/html/body/div[6]/a[14]")).Click();

            //Searches classes
            //for (int i = 0; i < 4; i++) ; { }
            driver.FindElement(By.Id("searchBox")).SendKeys("CIS 3308");
            Thread.Sleep(100);
                                                            //This div iterates\/
            driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/div/div[1]/div[9]/div[3]")).Click();

            course1Details.setCourseName(driver.FindElement(By.ClassName("abbrevTitle")).Text);


            //driver.Close();
            return Course;
        }
    }
}
