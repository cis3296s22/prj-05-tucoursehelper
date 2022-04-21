using Hangfire.Server;
using System;
using TempleCourseHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TempleCourseHelper.Tests
{
    [TestClass]
    public class CourseDetailsTest

    {
        [TestMethod]
        public void setsCourseName_Correctly()
        {
            //Arrange
            CourseDetails courseDetails = new CourseDetails();
            
            //Act
            courseDetails.setCourseName("SomeCourse");

            //Assert
            Assert.AreEqual(courseDetails.getCourseName(), "SomeCourse");
        }
        [TestMethod]
        public void setsCourseName_Wrong()
        {
            //Arrange
            CourseDetails courseDetails = new CourseDetails();
            //Act
            courseDetails.setCourseName("WrongCourse");
            //Assert
            Assert.AreNotEqual(courseDetails.getCourseName(), "CorrectCourse");
        }
        [TestMethod]
        public void setsCourseCode_Correctly()
        {
            //Arrange
            CourseDetails courseDetails = new CourseDetails();

            //Act
            courseDetails.setCourseCode("9999");

            //Assert
            Assert.AreEqual(courseDetails.getCourseCode(), "9999");
        }
    }
}
