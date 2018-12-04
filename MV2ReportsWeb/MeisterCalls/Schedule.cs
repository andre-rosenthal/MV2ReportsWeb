using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV2ReportsWeb.MeisterCalls.Schedule
{
    [JsonObject("REQUEST")]
    public class Request
    {
        public String Userid { get; set; }
    }
    /// <summary>
    /// Query ....
    /// </summary>
    [JsonObject("RESPONSE")]
    public class Response
    {
        public List<Schedule> Agenda { get; set; }
    }


    public class ReturnMessage
    {
        [JsonProperty("PKY")]
        public string Pky { get; set; }
        [JsonProperty("MESSAGE")]
        public string Message { get; set; }
        [JsonProperty("REPORT_NAME")]
        public string ReportName { get; set; }
        [JsonProperty("USERNAME")]
        public string Username { get; set; }
    }

    [JsonObject("AGENDA")]
    public class Schedule
    {
        [JsonProperty("PKY")]
        public string Pky { get; set; }
        [JsonProperty("AGENDA_TYPE")]
        public string Type { get; set; }
        [JsonProperty("DOW")]
        public string DayOfWeek { get; set; }
        [JsonProperty("SLOT")]
        public string TimeSlot { get; set; }
        [JsonProperty("NICKNAME")]
        public string  Nickname { get; set; }
        [JsonProperty("USERID")]
        public string  Username{ get; set; }
        [JsonProperty("DELETE")]
        public string DeleteFlag { get; set; }
        [JsonProperty("NAME")]
        public string Name { get; set; }
        [JsonProperty("VARIANT")]
        public string Variant { get; set; }
        [JsonProperty("WITH_METADATA")]
        public string WithMetadata { get; set; }
        [JsonProperty("COLUMNS_NAMED")]
        public string ColumnsNamed { get; set; }
        [JsonProperty("PARAMETERS")]
        public List<MV2ReportsWeb.MeisterCalls.ReportFind.Parameter> Parameters { get; set; }

    }
}