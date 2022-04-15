using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleCourseHelper
{
    internal class ClassTimeDate
    {
        private int day, time;
        public void setDay(int day)
        { 
            this.day = day;
        }
        public void setTime(int time)
        {
            this.time = time;
        }
        public int getDay()
        {
            return day;
        }
        public int getTime()
        {
            return time;
        }
    }
}
