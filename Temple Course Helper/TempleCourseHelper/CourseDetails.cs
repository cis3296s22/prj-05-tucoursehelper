﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TempleCourseHelper
{
    internal class CourseDetails
    {
        string courseName, courseCode, courseDescription, courseProfessor, professorRating, courseTime, courseSection, courseDays, courseCredits; 

        public string getCourseName()
        {
            return courseName;
        }
        public string getCourseCode()
        {
            return courseCode;
        }
        public string getCourseDescription()
        {
            return courseDescription;
        }
        public string getCourseProfessor()
        {
            return courseProfessor;
        }
        public string getProfessorRating()
        {
            return professorRating;
        }
        public string getCourseTime()
        {
            return courseTime;
        }
        public string getCourseSection()
        {
            return courseSection;
        }
        public string getCourseDays()
        {
            return courseDays;
        }
        public string getCourseCredit()
        {
            return courseCredits;
        }


        public void setCourseName(String name)
        {
            this.courseName = name;
        }
        public void setCourseCode(String code)
        {
            this.courseCode = code;
        }
        public void setCourseDescription(String desc)
        {
            this.courseDescription = Regex.Replace(desc, @"Description: ","");
        }
        public void setCourseProfessor(String prof)
        {
            this.courseProfessor = prof;
        }
        public void setProfessorRating(String profRating)
        {
            this.professorRating = profRating;
        }
        public void setCourseTime(String time)
        {
            this.courseTime = Regex.Replace(time, @"\r\n", ""); ;
        }
        public void setCourseSection(String section)
        {
            this.courseSection = section;
        }
        public void setCourseDays(String days)
        {
            this.courseDays = days;
        }
        public void setCourseCredit(string credit)
        {
            this.courseCredits = Regex.Replace(credit, @"Credits: ","");   
        }

    }
}
