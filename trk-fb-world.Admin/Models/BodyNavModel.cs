using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.Admin.Models
{
    public class BodyNavModel
    {
        private string _Title;
        public string Title { get { return HttpContext.GetGlobalResourceObject("Pages", _Title).ToString(); } set { _Title = value; } }

        public bool HasBtnNew { get; set; }

        public bool HasBtnList { get; set; }

        public bool HasBtnSortable { get; set; }

        private object _RouteValues;
        public object RouteValues {
            get { return _RouteValues; }
            set
            {
                if (value == null)
                    _RouteValues = new { Id = DBNull.Value };
                else
                    _RouteValues = value;
            }
        }
    }
}