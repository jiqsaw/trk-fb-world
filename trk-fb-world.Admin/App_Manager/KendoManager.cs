using TurkcellFacebookDunyasi.Com.Helpers;
using Kendo.Mvc.UI.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurkcellFacebookDunyasi.Com.Helpers.UrlHelperExtensions;
using TurkcellFacebookDunyasi.Com.General;

namespace TurkcellFacebookDunyasi.Admin.App_Manager
{
    public class KendoManager
    {
        public static string DateFormat = "{0:" + GlobalVars.dateFormat + "}";
        public static string GridName = "Grid";
        public static string ClientTemplateCheck(string Field)
        {
            return "#= " + Field + " ? \"<span class='k-icon k-i-tick'></span>\" : '' #";
        }

        public static string ClientTemplateDate(string DateTimeValue)
        {
            return "#= " + DateTimeValue + " ? kendo.toString(" + DateTimeValue + ",\"" + GlobalVars.dateFormat + "\") : '' #";
        }
        public static string ClientTemplateOfferImage(string FileName)
        {
            var DefaultPath = PathHelper.Images.Offer(FileName, Com.Enums.Parameter.ImageSizeNaming.Default).ToFullPath();
            var PreviewPath = PathHelper.Images.Offer(FileName, Com.Enums.Parameter.ImageSizeNaming.Preview).ToFullPath();

            DefaultPath = DefaultPath.Replace(FileName, "#= FileName #");
            PreviewPath = PreviewPath.Replace(FileName, "#= FileName #");

            return "<a class='cb' href='" + DefaultPath + "'><img src='" + PreviewPath + "' /></a>";
        }


        public static string ClientTemplateAdminImage(string FileName)
        {
            var DefaultPath = PathHelper.Images.AdminUser(FileName, Com.Enums.Parameter.ImageSizeNaming.Default).ToFullPathAdmin();
            var PreviewPath = PathHelper.Images.AdminUser(FileName, Com.Enums.Parameter.ImageSizeNaming.Preview).ToFullPathAdmin();

            DefaultPath = DefaultPath.Replace(FileName, "#= FileName #");
            PreviewPath = PreviewPath.Replace(FileName, "#= FileName #");

            return "<a class='cb' href='" + DefaultPath + "'><img src='" + PreviewPath + "' /></a>";
        }

        public static string HtmlEditIcon = "<span class=\"k-icon k-i-pencil\"></span>";

        public static Action<PageableBuilder> pagerSettings = new Action<PageableBuilder>(
            p => p
            .Input(true)
            .PageSizes(new int[] { 5, 10, 20, 50, 100, 250, 500 })
            .Messages(pagerMessages)            
        );

        public static Action<PageableMessagesBuilder> pagerMessages = new Action<PageableMessagesBuilder>(
            m => m
                .Empty(Resources.Kendo.PagerEmpty)
                .First(Resources.Kendo.PagerFirst)
                .ItemsPerPage(Resources.Kendo.PagerItemsPerPage)
                .Last(Resources.Kendo.PagerLast)
                .Next(Resources.Kendo.PagerNext)
                .Of(Resources.Kendo.PagerOf)
                .Page(Resources.Kendo.PagerPage)
                .Previous(Resources.Kendo.PagerPrevious)
                .Previous(Resources.Kendo.PagerRefresh)
                .Display(Resources.Kendo.PagerDisplay)
        );

        public static Action<GridFilterableSettingsBuilder> filterSettings = new Action<GridFilterableSettingsBuilder>
            (c => c
                    .Messages(
                        msg => msg
                            .Info(Resources.Kendo.FilterMsgInfo)
                            .Or(Resources.Kendo.FilterMsgOr)
                            .And(Resources.Kendo.FilterMsgAnd)
                            .IsTrue(Resources.Kendo.FilterMsgIsTrue)
                            .IsFalse(Resources.Kendo.FilterMsgIsFalse)
                            .Filter(Resources.Kendo.FilterMsgFilter)
                            .Clear(Resources.Kendo.FilterMsgClear)
                    )
                    .Operators(
                        opList => opList
                            .ForString(t => t
                                .IsEqualTo(Resources.Kendo.FilterOpStrIsEqualTo)
                                .IsNotEqualTo(Resources.Kendo.FilterOpStrIsNotEqualTo)
                                .StartsWith(Resources.Kendo.FilterOpStrStartsWith)
                                .EndsWith(Resources.Kendo.FilterOpStrEndsWith)
                                .Contains(Resources.Kendo.FilterOpStrContains)
                                .DoesNotContain(Resources.Kendo.FilterOpStrDoesNotContain))
                            
                            .ForNumber(t => t
                                .IsEqualTo(Resources.Kendo.FilterOpNumIsEqualTo)
                                .IsGreaterThan(Resources.Kendo.FilterOpNumIsGreaterThan)
                                .IsGreaterThanOrEqualTo(Resources.Kendo.FilterOpNumIsGreaterThanOrEqualTo)
                                .IsLessThan(Resources.Kendo.FilterOpNumIsLessThan)
                                .IsLessThanOrEqualTo(Resources.Kendo.FilterOpNumIsLessThanOrEqualTo)
                                .IsNotEqualTo(Resources.Kendo.FilterOpNumIsNotEqualTo))

                            .ForDate(t => t
                                .IsEqualTo(Resources.Kendo.FilterOpDateIsEqualTo)
                                .IsGreaterThan(Resources.Kendo.FilterOpDateIsGreaterThan)
                                .IsGreaterThanOrEqualTo(Resources.Kendo.FilterOpDateIsGreaterThanOrEqualTo)
                                .IsLessThan(Resources.Kendo.FilterOpDateIsLessThan)
                                .IsLessThanOrEqualTo(Resources.Kendo.FilterOpDateIsLessThanOrEqualTo)
                                .IsNotEqualTo(Resources.Kendo.FilterOpDateIsNotEqualTo))
                    )
            );
    }
}