using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleCourseHelper
{
    internal class CheckConflicts
    {
        private int day = 0;
        public Dictionary<int, Dictionary<int, CourseDetails>> runChecker(Dictionary<int, Dictionary<int, CourseDetails>> CourseSchedule)
        {
            ClassTimeDate classTimeDate = new ClassTimeDate();

            foreach (KeyValuePair<int, Dictionary<int, CourseDetails>> kd in CourseSchedule)
            {
                var courseSections = kd.Value;
                foreach (KeyValuePair<int, CourseDetails> kv in courseSections)
                {

                    switch (kv.Value.getCourseDays().Contains())
                    {
                        case :
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }

                    classTimeDate.setDay


                }

                //Each iteration will post the section into a different label
            }
            return CourseSchedule;
        }

    }
}
