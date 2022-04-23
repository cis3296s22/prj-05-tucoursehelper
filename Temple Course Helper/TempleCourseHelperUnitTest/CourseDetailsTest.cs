using Hangfire.Server;
using System;
using TempleCourseHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TempleCourseHelper.UnitTests
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
            Assert.AreNotEqual(courseDetails.getCourseName(), "AnotherCourse");
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
            Assert.AreNotEqual(courseDetails.getCourseCode(), "9998");
        }
       

        [TestMethod]
        public void setCourseDescription_Correctly()
        {
            //Arrange
            CourseDetails courseDetails = new CourseDetails();
            //Act
            courseDetails.setCourseDescription("This is a description");
            //Assert
            Assert.AreEqual(courseDetails.getCourseDescription(), "This is a description");
            Assert.AreNotEqual(courseDetails.getCourseDescription(), "This is not description");
        }
        

        [TestMethod]
        public void setCourseProfessor_Correctly()
        {
            //Arrange
            CourseDetails courseDetails = new CourseDetails();
            //Act
            courseDetails.setCourseProfessor("Tamer Aldwairi");
            //Assert
            Assert.AreEqual(courseDetails.getCourseProfessor(), "Tamer Aldwairi");
            Assert.AreNotEqual(courseDetails.getCourseProfessor(), "Eugene Kwatny");
        }

        [TestMethod]
        public void setProfessorRating_Correctly()
        {
            //Arrange
            CourseDetails courseDetails = new CourseDetails();
            //Act
            courseDetails.setProfessorRating("99");
            //Assert
            Assert.AreEqual(courseDetails.getProfessorRating(), "99");
            Assert.AreNotEqual(courseDetails.getProfessorRating(), "50");
        }

        [TestMethod]
        public void setCourseTime_Correctly()
        {
            //Arrange
            CourseDetails courseDetails = new CourseDetails();
            //Act
            courseDetails.setCourseTime("05:00");
            //Assert
            Assert.AreEqual(courseDetails.getCourseTime(), "05:00");
            Assert.AreNotEqual(courseDetails.getCourseTime(), "10:00");
        }

        [TestMethod]
        public void setCourseDays_Correctly()
        {
            //Arrange
            CourseDetails courseDetails = new CourseDetails();
            //Act
            courseDetails.setCourseDays("Monday");
            //Assert
            Assert.AreEqual(courseDetails.getCourseDays(), "Monday");
            Assert.AreNotEqual(courseDetails.getCourseDays(), "Tuesday");
        }

        [TestMethod]
        public void setCourseCredit_Correctly()
        {
            //Arrange
            CourseDetails courseDetails = new CourseDetails();
            //Act
            courseDetails.setCourseCredit("4");
            //Assert
            Assert.AreEqual(courseDetails.getCourseCredit(), "4");
            Assert.AreNotEqual(courseDetails.getCourseCredit(), "3");
        }

    }
}
