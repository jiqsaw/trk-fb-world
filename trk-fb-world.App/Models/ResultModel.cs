using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class ResultModel
    {
        public enum ResultType
        {
            success,
            error
        }

        public ResultType Type { get; set; }
        public string Message { get; set; }
    }
}