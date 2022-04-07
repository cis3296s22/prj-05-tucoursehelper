using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleCourseHelper
{
    internal class CourseDetails
    {
        string courseName, courseDescription, courseProfessor, professorRating, courseTime;

        public string getCourseName()
        {
            return courseName;
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


        public void setCourseName(String name)
        {
            this.courseName = name;
        }
        public void setcourseDescription(String desc)
        {
            this.courseDescription = desc;
        }
        public void setcourseProfessor(String prof)
        {
            this.courseProfessor = prof;
        }
        public void setprofessorRating(String profRating)
        {
            this.professorRating = profRating;
        }
        public void setcourseTime(String time)
        {
            this.courseTime = time;
        }

    }
}
