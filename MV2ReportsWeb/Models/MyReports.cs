using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MV2ReportsWeb.Utils;

namespace MV2ReportsWeb.Models
{
    public class MyReports
    {
        [Key]
        public int ID { get; set; }
        public String UUID { get; set; }
        [DisplayName("Report Name")]
        public String ReportName { get; set; }
        public String Description { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd hh:mm:ss tt}")]
        [Display(Name = "Executed on")]
        public DateTime DateTime { get; set; }
        public String Status { get; set; }
        public String Email { get; set; }       
        public bool Downloaded { get; set; }
        public String Content { get; set; }
        public String EDM { get; set; }
        public Statuses ToNamedStatus(string s)
        {
            switch (s)
            {
                case "F":
                    return Statuses.Finished;
                case "S":
                    return Statuses.Scheduled;
                case "R":
                    return Statuses.Running;
                default:
                    break;
            }
            return Statuses.Pending;
        }
    }
}