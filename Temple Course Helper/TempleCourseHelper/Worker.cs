using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TempleCourseHelper
{
    internal class Worker
    {
        IWebDriver driver;
        Dictionary<string, CourseDetails> Course = new Dictionary<string, CourseDetails>();
        String TempleURL = "https://prd-xereg.temple.edu/StudentRegistrationSsb/ssb/term/termSelection?mode=courseSearch";
        public void startBrowser()
        {
            //Open Chrome "headless" or not visible to user
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");

            //Add chrom exe location
            driver = new ChromeDriver(chromeOptions);
        }
        public void closeBrowser()
        {
            //Add chrom exe location
            driver.Close();//*[@id="textcontainer"]/div/div[2]/p/strong
        }
        public Dictionary<string, CourseDetails> searchCatalog()
        {
            startBrowser();

            driver.Navigate().GoToUrl(TempleURL);
            Thread.Sleep(3);
            //EXAMPLE
            //
            //Here is a full xpath copied from the link above. If you follow the html code you can see we need to iterate the li[x].  
            //That is the list that has the different majors as its contents.
            //
            //html/body/div[3]/div/div[3]/div/div/div/ul/li[1]/a
            //
            //This is the same example but with the shortened xpath. Here we skip the intro address: html/body/div[3]/div/div[3]/div/div/
            //
            //*[@id="textcontainer"]/div/ul/li[1]/a

            //Now we are looking inside one of these majors, and we can see a full xpath and the last div[x] is what we need to iterate.
            //Also the short version for context. The information will be stored on the last object in that line, so in this case "strong"
            //
            //"/html/body/div[3]/div/div[3]/div/div/div/div[0]/p/strong";
            //*[@id="textcontainer"]/div/div[2]/p/strong

            //Fill the Dictionary

            closeBrowser();
            return Course;
        }
    }
}
