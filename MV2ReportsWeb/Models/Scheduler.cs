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
        
        public String Hint { get; set; }
        [Key]
        public int ID { get; set; }
        [DisplayName("Report Name")]
        public String ReportName { get; set; }
        [DisplayName("Report Description")]
        public String ReporDescription { get; set; }
    }
}