using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TempleCourseHelper
{
    public class CourseDetails
    {
        private string courseName, courseCode, courseDescription, courseProfessor, professorRating, courseTime, courseSection, courseDays, courseCredits; 

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


        public void setCourseName(string name)
        {
            this.courseName = name;
        }
        public void setCourseCode(string code)
        {
            this.courseCode = code;
        }
        public void setCourseDescription(string desc)
        {
            for (int i = 1; i < desc.Length; i++)
            {
                //After 100 charecters of the decription
                if (i % 55 == 0)
                {
                    //The code will search for the next white space
                    while (true)
                    {
                        //Makes sure the i doesn't go out of bounds
                        try
                        {
                            if (Char.IsWhiteSpace(desc[i]))
                            {
                                //It will be replaced with a "\n"
                                desc = desc.Insert(i, "\n");
                                break;
                            }
                        }
                        catch (Exception IndexOutOfRangeException)
                        {
                            break;
                        }
                        i++;
                    }
                }
            }
            this.courseDescription = Regex.Replace(desc, @"Description: ","");
        }
        public void setCourseProfessor(string prof)
        {
            this.courseProfessor = prof;
        }
        public void setProfessorRating(string profRating)
        {
            this.professorRating = profRating;
        }
        public void setCourseTime(string time)
        {
            this.courseTime = Regex.Replace(time, @"\r\n", ""); 
        }
        public void setCourseSection(string section)
        {
            this.courseSection = section;
        }
        public void setCourseDays(string days)
        {
            this.courseDays = days;
        }
        public void setCourseCredit(string credit)
        {
            this.courseCredits = Regex.Replace(credit, @"Credits: ","");   
        }

    }
}
