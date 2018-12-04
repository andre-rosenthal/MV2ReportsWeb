using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV2ReportsWeb.Utils
{
    public enum Statuses
    {
        Pending,
        Finished,
        Scheduled,
        Running
    }

    public enum ScheduleTypes
    {
        NotSpecified,
        Daily,
        Weekly,
        Monthly,
        SemiAnually,
        Annually
    }

    public enum Weekdays
    {
        All,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    public static class Utils
    {
        public static DateTime ToDateTime(String d, String t)
        {
            string date = d.Substring(0, 4) + '/' + d.Substring(4, 2) + '/' + d.Substring(6, 2);
            string time = t.Substring(0, 2) + ':' + t.Substring(2, 2) + ':' + t.Substring(4, 2);
            string dts = date + " " + time;
            DateTime dt = DateTime.Now;
            if (DateTime.TryParse(dts, out dt))
                return dt;
            else
                return DateTime.Now;
        }

        public static ScheduleTypes GetSchedule(string s)
        {
            switch (s)
            {
                case "D":
                    return ScheduleTypes.Daily;
                case "W":
                    return ScheduleTypes.Weekly;
                case "M":
                    return ScheduleTypes.Monthly;
                case "S":
                    return ScheduleTypes.SemiAnually;
                case "A":
                    return ScheduleTypes.Annually;
                default:
                    return ScheduleTypes.NotSpecified;
            }
        }
        public static Weekdays GetWeekdays(string s)
        {
            switch (s)
            {
                case "X":
                    return Weekdays.Sunday;
                case "M":
                    return Weekdays.Monday;
                case "T":
                    return Weekdays.Tuesday;
                case "W":
                    return Weekdays.Wednesday;
                case "R":
                    return Weekdays.Thursday;
                case "F":
                    return Weekdays.Friday;
                case "S":
                    return Weekdays.Saturday;
                default:
                    return Weekdays.All;
            }
        }
    }
}