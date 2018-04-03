// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class CreditTransferResponse
    {

        [JsonProperty("CreditTransfer")]
        public CreditTransfer CreditTransfer { get; set; }

        [JsonProperty("result")]
        public string ServiceResult { get; set; }

        [JsonProperty("errorMessage")]
        public string Error { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
}
