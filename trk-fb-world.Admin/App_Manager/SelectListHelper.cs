using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace TurkcellFacebookDunyasi.Admin.App_Manager
{
    public class SelectListHelper
    {
        public static List<SelectListItem> SelectListEnum(Type type)
        {
            if (!type.IsEnum)
                throw new ArgumentException("Type is not an enum.");

            //if (selected != null && selected.GetType() != type)
            //throw new ArgumentException("Selected object is not " + type.ToString());

            var slEnum = new List<SelectListItem>();

            var source = Enum.GetValues(type);
            var displayAttributeType = typeof(DisplayAttribute);

            foreach (var value in source)
            {
                var item = new SelectListItem();
                item.Value = ((int)value).ToString();

                /*
                if (selected > -1)
                    item.Selected = selected == (int)value;
                */

                FieldInfo field = value.GetType().GetField(value.ToString());
                DisplayAttribute attrs = (DisplayAttribute)field.GetCustomAttributes(displayAttributeType, false).First();

                //item.Text = Enum.GetName(type, value);
                item.Text = attrs.GetName();

                //item.Text = Enum.GetName(type, value);

                slEnum.Add(item);
            }
            return slEnum;
        }
    }
}