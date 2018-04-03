using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace TurkcellFacebookDunyasi.Admin.Extensions
{
    public static class ListExtensions
    {
        public static MvcHtmlString DropDownListEnum(this HtmlHelper helper, string name, Type type, int selected, bool HasDefaultInitial = true)
        {
            if (!type.IsEnum)
                throw new ArgumentException("Type is not an enum.");

            //if (selected != null && selected.GetType() != type)
            //throw new ArgumentException("Selected object is not " + type.ToString());

            var enums = new List<SelectListItem>();

            var source = Enum.GetValues(type);
            var displayAttributeType = typeof(DisplayAttribute);

            foreach (var value in source)
            {
                var item = new SelectListItem();
                item.Value = ((int)value).ToString();

                if (selected > -1)
                    item.Selected = selected == (int)value;

                FieldInfo field = value.GetType().GetField(value.ToString());
                DisplayAttribute attrs = (DisplayAttribute)field.GetCustomAttributes(displayAttributeType, false).First();

                //item.Text = Enum.GetName(type, value);
                item.Text = attrs.GetName();

                enums.Add(item);
            }

            // set ViewData first
            helper.ViewData[name] = enums;

            return (HasDefaultInitial)
                ? System.Web.Mvc.Html.SelectExtensions.DropDownList(helper, name, null, System.Web.HttpContext.GetGlobalResourceObject("Global", "DdlInitial").ToString())
                : System.Web.Mvc.Html.SelectExtensions.DropDownList(helper, name);
        }
    }
}