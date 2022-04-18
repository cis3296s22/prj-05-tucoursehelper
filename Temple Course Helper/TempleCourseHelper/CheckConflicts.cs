using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace TempleCourseHelper
{
    internal class CheckConflicts
    {
        Dictionary<int, Dictionary<int, ArrayList>> conflictsClasses = new Dictionary<int, Dictionary<int, ArrayList>>();
        public Dictionary<int, Dictionary<int, CourseDetails>> runChecker(Dictionary<int, Dictionary<int, CourseDetails>> CourseSchedule)
        {
            int classIter = 0;
            //Sets all days
            foreach (KeyValuePair<int, Dictionary<int, CourseDetails>> kd in CourseSchedule)
            {
                Dictionary<int, ArrayList> conflictsSections = new Dictionary<int, ArrayList>();
                int sectionIter = 0;
                var courseSections = kd.Value;
                foreach (KeyValuePair<int, CourseDetails> kv in courseSections)
                {
                    ArrayList timeList = new ArrayList();
                    sectionIter++;    
                    conflictsSections.Add(sectionIter, formatTime(kv.Value.getCourseTime(),timeList));
                }
                classIter++;
                conflictsClasses.Add(classIter, conflictsSections);
            }
            foreach (KeyValuePair<int, Dictionary<int,ArrayList>> kd in conflictsClasses)
            {

                var courseSections = kd.Value;
                foreach (KeyValuePair<int, ArrayList> kv in courseSections)
                {
                    
                    for (int i = 0; i < timeList.Count; i += 2)
                    {
                        DateTime aStart = DateTime.Parse("2020-01-01T" + kv.Value[i]);
                        DateTime aEnd = DateTime.Parse("2020-01-01T" + kv.Value[i + 1]);

                        DateTime bStart = DateTime.Parse("2020-01-01T" + timeList[i + 2]);
                        DateTime bEnd = DateTime.Parse("2020-01-01T" + timeList[i + 3]);
                    }
                    
                }

            }
            return CourseSchedule;
        }

        public bool HasOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return Min(start1, end1) < Max(start2, end2) && Max(start1, end1) > Min(start2, end2);
        }

        public DateTime Max(DateTime d1, DateTime d2)
        {
            return d1 > d2 ? d1 : d2;
        }

        public DateTime Min(DateTime d1, DateTime d2)
        {
            return d2 > d1 ? d1 : d2;
        }

        private ArrayList formatTime(string timeString, ArrayList timeList)
        {
            int addTime = 0;
            char[] oneTimeSeparator = { '-' };
            char[] twoTimeSeparator = { '/' };
            if (timeString.Contains("/"))
            {
                //Removes "/" from the time string
                String[] bothTimeRanges = timeString.Split(twoTimeSeparator,StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < bothTimeRanges.Length; i++)
                {
                    //Removes "-" from the time string
                    String[] oneTimeRange = bothTimeRanges[i].Split(oneTimeSeparator, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < oneTimeRange.Length; j++)
                    {
                        addTime = 0;
                        //Checks if pm to add 1200, replaces am & pm with ":00" for format
                        if (oneTimeRange[j].Contains("pm"))
                        {
                            addTime = 120000;
                            oneTimeRange[j] = Regex.Replace(oneTimeRange[j], @"pm", ":00");
                        }
                        else
                        {
                            oneTimeRange[j] = Regex.Replace(oneTimeRange[j], @"am", ":00");
                        }

                        //If string only has 7 chars (ex. "9:00:00" make it "09:00:00")
                        if(oneTimeRange[j].Length == 7)
                        {
                            oneTimeRange[j] = oneTimeRange[j].Insert(0, "0");
                        }
                        //Removes ":" in order to add pm amount
                        oneTimeRange[j] = Regex.Replace(oneTimeRange[j], @":", "");
                        //Converts string to int, adds pm time, reverts back to a string and adds back the ":"
                        timeList.Add((Convert.ToString(Convert.ToInt32(oneTimeRange[j]) + addTime)).Insert(2,":").Insert(5,":"));
                    }
                }
            }
            else
            {
                //Removes "-" from the time string
                String[] oneTimeRange = timeString.Split(oneTimeSeparator, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < oneTimeRange.Length; j++)
                {
                    addTime = 0;
                    //Checks if pm to add 1200, replaces am & pm with ":00" for format
                    if (oneTimeRange[j].Contains("pm"))
                    {
                        addTime = 120000;
                        oneTimeRange[j] = Regex.Replace(oneTimeRange[j], @"pm", ":00");
                    }
                    else
                    {
                        oneTimeRange[j] = Regex.Replace(oneTimeRange[j], @"am", ":00");
                    }

                    //If string only has 4 chars (ex. "9:00" make it "09:00")
                    if (oneTimeRange[j].Length == 7)
                    {
                        oneTimeRange[j] = oneTimeRange[j].Insert(0, "0");
                    }
                    //Removes ":" in order to add pm amount
                    oneTimeRange[j] = Regex.Replace(oneTimeRange[j], @":", "");
                    //Converts string to int, adds pm time, reverts back to a string and adds back the ":"
                    timeList.Add((Convert.ToString(Convert.ToInt32(oneTimeRange[j]) + addTime)).Insert(1, ":").Insert(4, ":"));
                }
            }
            return timeList;
        }
    }
}
