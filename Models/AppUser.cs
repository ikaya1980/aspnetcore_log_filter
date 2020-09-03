using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;

namespace aspnetcore_log_filter.Models
{
    public class AppUser 
    {

        public int AppUserId { get; set; }

        public string UserName { get; set; }

        public DateTime LoginDate { get; set; }

        public string Path { get; set; }

        public string QueryString { get; set; }

        public string Method { get; set; }

        public string Payload { get; set; }

        public string Response { get; set; }

        public string ResponseCode { get; set; }

        public DateTime RequestedOn { get; set; }

        public DateTime RespondedOn { get; set; }

        public bool IsSuccessStatusCode { get; set; }
    }
}
