using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MV2ReportsWeb.Models
{
    public class Scheduler
    {
        [Key]
        public int ID { get; set; }
        public string ScheduleType { get; set; }
        public string WeekDay { get; set; }
        public string TimeSlot { get; set; }
        public string NickName { get; set; }
        public string UUID { get; set; }
        public string UserName { get; set; }
    }
}