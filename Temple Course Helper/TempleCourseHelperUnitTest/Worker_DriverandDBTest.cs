using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TempleCourseHelper;


namespace TempleCourseHelper.UnitTests
{
    [TestClass]
    public class Worker_DriverandDBTest
    {
        [TestMethod]
        public void ConnectionwithDBandWebScrapping_Successfull()
        {
            //Arrange
            Worker worker = new Worker();
           
            string[] exampleNumbers = new string[]
                {
                    "3207",
                    "3441",
                    "4398",
                    "3308"
                };
            string[] exampleLetters = new string[]
            {
                    "CIS",
                    "CIS",
                    "CIS",
                    "CIS"
            };

            //Act
            worker.searchCatalog(exampleLetters, exampleNumbers);
            worker.setTUID("111111111");
            worker.UpdateRecords();

            //Assert
            Assert.IsTrue(worker.checkRecords()); 
        }
    }
}
