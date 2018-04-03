// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class FreeUnit
    {

        [JsonProperty("getCampaignName")]
        public string GetCampaignName { get; set; }

        [JsonProperty("getDeactivationDate")]
        public string GetDeactivationDate { get; set; }

        [JsonProperty("getAvailableBalance")]
        public string GetAvailableBalance { get; set; }

        [JsonProperty("getActivationDate")]
        public string GetActivationDate { get; set; }

        [JsonProperty("getCreditUnit")]
        public string GetCreditUnit { get; set; }

        [JsonProperty("getZoneTypeDesc")]
        public string GetZoneTypeDesc { get; set; }

        [JsonProperty("getCreditUnit2")]
        public string GetCreditUnit2 { get; set; }

        [JsonProperty("getCurrPeriodBalance2")]
        public string GetCurrPeriodBalance2 { get; set; }

        [JsonProperty("getAvailableBalance2")]
        public string GetAvailableBalance2 { get; set; }

        [JsonProperty("getUnitRate")]
        public string GetUnitRate { get; set; }

        [JsonProperty("getUnitTypeDesc")]
        public string GetUnitTypeDesc { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
