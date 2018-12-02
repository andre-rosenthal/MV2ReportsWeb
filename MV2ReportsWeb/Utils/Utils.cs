using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV2ReportsWeb.Utils
{
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
    }
}