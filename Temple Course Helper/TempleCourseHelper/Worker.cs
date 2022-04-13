﻿using System;
using System.Collections.Concurrent;
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
        DBConnector DB = new DBConnector();
        //Dictionary for class sections
        Dictionary<int, CourseDetails> ClassSection = new Dictionary<int, CourseDetails>();
        //Dictionary of dictionary of class sections for different classes
        Dictionary<int, Dictionary<int,CourseDetails>> CourseSchedule = new Dictionary<int, Dictionary<int,CourseDetails>>();
        String CoursicleURL = "https://www.coursicle.com/temple/";
        String TUID = "";

        public Dictionary<int, Dictionary<int, CourseDetails>> searchCatalog(String[] courseLetters,String[] courseNumbers)
        {
            int section = 1;
            //Open Chrome "headless" or not visible to user
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");

            //Add chrom exe location
            //driver = new ChromeDriver(chromeOptions);
            IWebDriver driver = new ChromeDriver(@"../../" + "/Resources/");

            //Goes to Coursicle
            driver.Navigate().GoToUrl(CoursicleURL);
            Thread.Sleep(50);


            //Clears any contents in CourseSchedule
            CourseSchedule.Clear();

            //Searches 4 classes
            for (int i = 0; i < courseNumbers.Length; i++)
            {
                section = 1;
                while (true)
                {

                    CourseDetails courseDetails = new CourseDetails();
                    //Sets course number
                    courseDetails.setCourseCode(courseNumbers[i]);

                    //Searches course
                    driver.FindElement(By.Id("searchBox")).SendKeys(courseLetters[i] + " " + courseNumbers[i]);
                    Thread.Sleep(500);

                    //Selects result
                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/div/div["+section+"]/div[9]/div[3]")).Click();
                    }
                    catch (Exception NoSuchElementException)
                    {
                        //If the first section doesnt exist, null will be returned else there is no more sections to add
                        if (section == 1)
                        {
                            return null;
                        }
                        else
                        {
                            break;
                        }
                    }

                    //Get Section/Title/Instructor/Days/Times
                    courseDetails.setCourseSection(driver.FindElement(By.ClassName("section")).Text);
                    courseDetails.setCourseName(driver.FindElement(By.ClassName("abbrevTitle")).Text);
                    courseDetails.setCourseProfessor(driver.FindElement(By.ClassName("instructor")).Text);
                    //Tries to get rating, not all professors have them
                    try
                    {
                        courseDetails.setProfessorRating(driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/div/div["+section+"]/div[9]/div[2]/div[3]/div[2]/div[2]")).Text);
                    }
                    catch (Exception NoSuchElementException)
                    {
                        courseDetails.setProfessorRating("No Rating");
                    }
                    //Tries to get time, some classes provide two time creating two different element id's
                    try //Multiple times
                    {
                        courseDetails.setCourseTime(driver.FindElement(By.CssSelector("#cardContainer > div:nth-child("+section+") > div.wrap > div.card.back > div.courseNameBack > div.time.twoTimes")).Text);
                    }
                    catch (Exception NoSuchElementException) // One time
                    {
                        courseDetails.setCourseTime(driver.FindElement(By.CssSelector("#cardContainer > div:nth-child("+section+") > div.wrap > div.card.back > div.courseNameBack > div.time")).Text);
                    }
                    courseDetails.setCourseDays(driver.FindElement(By.ClassName("days")).Text);

                    if (section == 1)
                    {
                        //Click small info circle
                        driver.FindElement(By.CssSelector("#cardContainer > div:nth-child("+section+") > div.wrap > div.card.back > div.infoIcon > i")).Click();
                        Thread.Sleep(100);

                        //Get course description and credits
                        courseDetails.setCourseDescription(driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/div[2]/div[1]/div[1]")).Text);
                        courseDetails.setCourseCredit(driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/div[2]/div[1]/div[7]")).Text);
                        //Close extra info box
                        driver.FindElement(By.CssSelector("#descriptionModal > div > div > div.modal-body > div.centerButton > button")).Click();
                        Thread.Sleep(1);
                    }

                    ClassSection.Add((i + 1), courseDetails);
                    driver.FindElement(By.Id("searchBox")).Clear();

                    section++;
                }
                CourseSchedule.Add((i + 1), ClassSection);
            }

            //Call Setup DB connection
            //DB.setupConnection();

            //adding data to database
            //DB.AddDataToDB(TUID,CourseSchedule);

            driver.Close();
            return CourseSchedule;
        }

       // public Dictionary<int, CourseDetails> getUserInfo(String ID)
        //{
            //Fill CourseSchedule with previous search of the user
        //    return CourseSchedule;
       // }
        public void setTUID(String TUID)
        {
            this.TUID = TUID;
        }
    }
}
