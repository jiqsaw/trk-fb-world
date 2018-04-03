using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class CallDetailsModel : BaseModel
    {
        public IList<DateTime> DateRange { get; set; }

        public CallDetailsModel()
        {
            DateRange = GetDateRange();
        }

        public static IList<DateTime> GetDateRange()
        {
            DateTime today = DateTime.Today;
            DateTime twoMonthsBefore = DateTime.Today.AddMonths(-2);
            IList<DateTime> dateRange = new List<DateTime>();
            while (today > twoMonthsBefore)
            {
                dateRange.Add(today);
                today = today.AddDays(-6);
            }

            return dateRange;
        }
    }
}