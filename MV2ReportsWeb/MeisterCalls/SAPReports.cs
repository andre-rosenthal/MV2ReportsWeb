using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV2ReportsWeb.MeisterCalls.ReportFind
{

    [JsonObject("REQUESRT")]
    public partial class Request
    {
        [JsonProperty("REPORT_GUID")]
        public string ReportGuid { get; set; }
        [JsonProperty("USERID")]
        public string UserId { get; set; }
    }

    [JsonObject("RESPONSE")]
   
    public partial class Response
    {
        [JsonProperty("REPORT_DATA")]
        public List<ReportData> ReportData { get; set; }
    }

    public partial class ReportData
    {
        [JsonProperty("PKY")]
        public string Pky { get; set; }

        [JsonProperty("DATESTAMP")]
        public string Date { get; set; }
        [JsonProperty("TIMESTAMP")]
        public string Time { get; set; }

        [JsonProperty("USERNAME")]
        public string Username { get; set; }

        [JsonProperty("REPORT")]
        public Report Report { get; set; }

        [JsonProperty("STATUS")]
        public string Status { get; set; }

        [JsonProperty("EMAIL")]
        public string Email { get; set; }

        [JsonProperty("VIA_EMAIL")]
        public string ViaEmail { get; set; }

        [JsonProperty("WITH_METADATA")]
        public string WithMetadata { get; set; }

        [JsonProperty("COLUMNS_NAMED")]
        public string ColumnsNamed { get; set; }
    }

    public partial class Report
    {
        [JsonProperty("MODE")]
        public string Mode { get; set; }

        [JsonProperty("NAME")]
        public string Name { get; set; }

        [JsonProperty("PARAMETERS")]
        public List<Parameter> Parameters { get; set; }

        [JsonProperty("VARIANT")]
        public string Variant { get; set; }

        [JsonProperty("WITH_METADATA")]
        public string WithMetadata { get; set; }

        [JsonProperty("COLUMNS_NAMED")]
        public string ColumnsNamed { get; set; }

        [JsonProperty("DESCRIPTION")]
        public string Description { get; set; }
    }

    [JsonObject("PARAMETERS")]
    public partial class Parameter
    {
        [JsonProperty("SELNAME")]
        public string Selname { get; set; }

        [JsonProperty("KIND")]
        public string Kind { get; set; }

        [JsonProperty("SIGN")]
        public string Sign { get; set; }

        [JsonProperty("OPTION")]
        public string Option { get; set; }

        [JsonProperty("LOW")]
        public string Low { get; set; }

        [JsonProperty("HIGH")]
        public string High { get; set; }
    }
}