using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleCourseHelper
{
    internal class ClassTimeRange
    {
        ArrayList timeList = new ArrayList();
        public void setTime(object time)
        {
            timeList.Add(Convert.ToInt32(time));
        }
        public void clearList()
        {
            timeList.Clear();
        }
        public ArrayList getTime()
        {
            return timeList;
        }
    }
}
