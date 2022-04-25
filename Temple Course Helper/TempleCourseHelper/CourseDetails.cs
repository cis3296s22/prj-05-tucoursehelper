using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TempleCourseHelper
{

    /// <summary>  
    /// Class that holds all the info(Name, Code, Descrption, Professor, etc.) for the classes searched.
    /// </summary>  
    public class CourseDetails
    {
        private string courseName, courseCode, courseDescription, courseProfessor, professorRating, courseTime, courseSection, courseDays, courseCredits;

        /// <summary>  
        /// Gets the Name of the Course.
        /// </summary>
        /// <returns> Returns a String with the Name of the Course.</returns>
        public string getCourseName()
        {
            return courseName;
        }

        /// <summary>  
        /// Gets the Course of the Course.
        /// </summary>
        /// <returns> Returns a String with the Course of the Course.</returns>
        public string getCourseCode()
        {
            return courseCode;
        }

        /// <summary>  
        /// Gets the Description of the Course.
        /// </summary>
        /// <returns> Returns a String with the Description of the Course.</returns>
        public string getCourseDescription()
        {
            return courseDescription;
        }

        /// <summary>  
        /// Gets the Professor of the Course.
        /// </summary>
        /// <returns> Returns a String with the Professor of the Course.</returns>
        public string getCourseProfessor()
        {
            return courseProfessor;
        }

        /// <summary>  
        /// Gets the Professor's Rating of the Course.
        /// </summary>
        /// <returns> Returns a String with the Rating.</returns>
        public string getProfessorRating()
        {
            return professorRating;
        }

        /// <summary>  
        /// Gets the Time of the Course.
        /// </summary>
        /// <returns> Returns a String with the Time of the Course.</returns>
        public string getCourseTime()
        {
            return courseTime;
        }

        /// <summary>  
        /// Gets the Section of the Course.
        /// </summary>
        /// <returns> Returns a String with the Section of the Course.</returns>
        public string getCourseSection()
        {
            return courseSection;
        }

        /// <summary>  
        /// Gets the Day(s) of the Course.
        /// </summary>
        /// <returns> Returns a String with the Day(s) of the Course.</returns>
        public string getCourseDays()
        {
            return courseDays;
        }

        /// <summary>  
        /// Gets the Credits of the Course.
        /// </summary>
        /// <returns> Returns a String with the Credits of the Course.</returns>
        public string getCourseCredit()
        {
            return courseCredits;
        }

        /// <summary>  
        /// Sets the Name of the Course.
        /// </summary>
        /// <param name="name"> Name of the Course.</param>
        public void setCourseName(string name)
        {
            this.courseName = name;
        }

        /// <summary>  
        /// Sets the Code of the Course.
        /// </summary>
        /// <param name="code"> Code of the Course.</param>
        public void setCourseCode(string code)
        {
            this.courseCode = code;
        }

        /// <summary>  
        /// Sets the Description of the Course. It also makes sure that the description appears fully on the screen.
        /// </summary>
        /// <param name="desc"> Description of the Course.</param>
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

        /// <summary>  
        /// Sets the Professor of the Course.
        /// </summary>
        /// <param name="prof"> Professor of the Course.</param>
        public void setCourseProfessor(string prof)
        {
            this.courseProfessor = prof;
        }

        /// <summary>  
        /// Sets the professor's rating of the Course.
        /// </summary>
        /// <param name="profRating"> Professor's rating of the Course.</param>
        public void setProfessorRating(string profRating)
        {
            this.professorRating = profRating;
        }

        /// <summary>  
        /// Sets the Time of the Course.
        /// </summary>
        /// <param name="time"> Time of the Course.</param>
        public void setCourseTime(string time)
        {
            this.courseTime = Regex.Replace(time, @"\r\n", ""); 
        }

        /// <summary>  
        /// Sets the Section of the Course.
        /// </summary>
        /// <param name="section"> Section of the Course.</param>
        public void setCourseSection(string section)
        {
            this.courseSection = section;
        }

        /// <summary>  
        /// Sets the Day(s) of the Course.
        /// </summary>
        /// <param name="days"> Day(s) of the Course.</param>
        public void setCourseDays(string days)
        {
            this.courseDays = days;
        }

        /// <summary>  
        /// Sets the Credits of the Course.
        /// </summary>
        /// <param name="credit"> Credits of the Course.</param>
        public void setCourseCredit(string credit)
        {
            this.courseCredits = Regex.Replace(credit, @"Credits: ","");   
        }

    }
}
