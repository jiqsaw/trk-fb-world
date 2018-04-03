using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Web;
using System.Text.RegularExpressions;

namespace LIB
{
    public sealed class FormatHelper
    {
        public static float Price(object inNumber) {
            return float.Parse(String.Format("{0:c}", inNumber).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "").Trim());
        }
        public static string PriceToString(object inNumber) {
            return String.Format("{0:c}", inNumber).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "").Trim();
        }        
        public static string Phone(string input) {
            if (input != null)
            {
                input = input.Replace(" ", String.Empty);
                if (input.Length == 7) return String.Format("{0:### ## ##}", Convert.ToInt64(input));
                else if (input.Length == 10) return String.Format("{0:(###) ### ## ##}", Convert.ToInt64(input));
                else if (input.Length == 11) return String.Format("{0:#(###) ### ## ##}", Convert.ToInt64(input));
                else if (input.Length == 12) return String.Format("{0:##(###) ### ## ##}", Convert.ToInt64(input));
                else if (input.Length == 13) return String.Format("{0:###(###) ### ## ##}", Convert.ToInt64(input));
                else return input;
            }
            else return String.Empty;
        }        
        public static string URL(string URL) {
            if (URL.Trim() == "") return URL;
            return StringHelper.TrToEng(URL).Replace("'", "").Replace("’", "").Replace("&#39;", "").Replace("\"", "").Replace("&", "").Replace("(", "").Replace(")", "")
                .Replace(":", " ").Replace("  ", " ").Replace("   ", " ").Replace(" ", "-").Replace("|", "_").Replace("?", "").Replace(".", "");
        }        
        public static string WebPage(string WebPage) {
            if (WebPage.IndexOf("http://") == -1)
                WebPage = "http://" + WebPage;
            return WebPage;
        }
        public static string FileName(string Text) {
            return LIB.Util.r(Text);/*
            if (Text == "") return "";
            return URL(LIB.Util.r(Text)); //Regex.Match(Text, @"[^\\]*$").Value;
                                     */
        }

        public static string DateWithTime(DateTime date) {
            return date.ToShortDateString() + " " + date.ToShortTimeString();
        }

        public static string NameCharLimit(string input, int Limit, string extChars = "") {
            if (input == null) return "";

            string[] Split = input.Split(' ');
            if (Split.Length == 2)
                input = Split[0].Substring(0, 1) + ". " + Split[1].ToString();
            else if (Split.Length == 3)
                input = Split[0].Substring(0, 1) + ". " + Split[1].Substring(0, 1) + ". " + Split[2].ToString();

            if (input.Length > Limit)
                return StringHelper.Left(input, Limit, extChars);

            return input;
        }

        public static string AgeCalculation(string Birthday)
        {
            try
            {
                string[] Split = Birthday.Split('/');
                string Day = Split[1];
                string Month = Split[0];
                string Year = Split[2];
                TimeSpan Difference = new TimeSpan();
                string TodayStr = DateTime.Now.ToString("dd.MM.yyyy");
                DateTime Today = Convert.ToDateTime(TodayStr);
                DateTime BirthDate = Convert.ToDateTime(Day + "." + Month + "." + Year);
                Difference = Today - BirthDate;
                int Age = Difference.Days / 365;
                return Age.ToString();
            }
            catch { return null; }
        }

        public static string DateTR(string Date)
        {
            string[] Split = Date.Split('/');
            return Split[1] + "." + Split[0] + "." + Split[2];
        }

        public static string DateFormat(string Date)
        {
            return Date.Substring(0, 10);
        }

        public static string DateChar(string Date)
        {
            if (Date.Length == 1)
                return "0" + Date;
            else
                return Date;
        }

    }
}