using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace LIB
{
    public sealed class Util
    {
        public static string ReturnPageNameFull() 
        {
            return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.RawUrl);
        }
        public static string ReturnPageName() 
        {
            string URL = HttpContext.Current.Request.RawUrl.Trim('/');
            URL = (URL.IndexOf('?') != -1) ? URL.Substring(0, URL.IndexOf('?')) : URL;
            return URL;
            //return HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Length - 1];
        }        
        public static string ReturnRefererPageName() 
        {
            return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.UrlReferrer.ToString());
        }
        public static string ApplicationRootPath() {
            return System.Web.HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, System.Web.HttpContext.Current.Request.Url.AbsoluteUri.LastIndexOf('/') + 1);
        }
        public static bool IsLocal()
        {
            return HttpContext.Current.Request.IsLocal;
        }

        public static bool IsEven(object input)
        { return ((int)((int.Parse(input.ToString())))) % 2 == 0; }



        /// <summary>
        /// String in db ye kayýt için düzenlenmesi
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string r(string input)
        {
            return StringHelper.ClearHtmlTags(input).Replace("'", "&#39;").Replace("\"", "").Replace("~", "").Replace("|", "");
        }

        /// <summary>
        /// Db ye düzenlenmiþ kaydedilen stringi decode 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string rt(string input)
        {
            return StringHelper.ClearHtmlTags(input).Replace("&#39;", "'");
        }

        /// <summary>
        /// Deðiþken Numeric ise true, deðilse false
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumeric(object input) {

            if (input == null) {
                return false;
            }

            if (input.ToString() == string.Empty) {
                return false;
            }

            foreach (char c in input.ToString()) {
                if (!char.IsNumber(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Deðiþken Date ise true, deðilse false
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsDate(object input)
        {
            try
            {
                Convert.ToDateTime(input);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Rasgele Sayý Üretir
        /// </summary>
        /// <param name="CharLength">Rasgele Sayý Kaç Karakterli Olsun</param>
        /// <returns></returns>
        public static string CreateRandomNumber(int CharLength) {
            //Random rnd = new Random(DateTime.Now.Year * DateTime.Now.Month * DateTime.Now.Day * DateTime.Now.Millisecond);
            if (CharLength == 0) return "0";
            Random rnd = GetRandom(0);
            string RndNumber = string.Empty;
            lock (rnd)
            {                
                for (int i = 1; i <= CharLength; i++)
                {
                    RndNumber += rnd.Next(0, 9).ToString();
                }
            }
            return RndNumber;
        }

        public static int RandomNumber(int Max, int Min = 0)
        {
            Random rnd = GetRandom(0);
            return rnd.Next(Min, Max); 
        }


        public static Random GetRandom(int seed)
        {
            Random r = (Random)System.Web.HttpContext.Current.Cache.Get("RandomNumber");
            if (r == null)
            {
                if (seed == 0)
                    r = new Random();
                else r = new Random(seed);
                System.Web.HttpContext.Current.Cache.Insert("RandomNumber", r);
            }
            return r;
        }

        ///<summary>
        /// Týrnak iþareti gibi istenmeyenler karakter kodu olarak decode etmek
        /// </summary>
        public static string CodeRplc(string Text)
        {
            return Text.Replace("'", "&#39;");
        }

        ///<summary>
        /// Týrnak iþareti gibi istenmeyen karakterleri encode etmek
        /// </summary>
        public static string DecodeRplc(string Text)
        {
            return Text.Replace("&#39;", "'");
        }

        ///<summary>
        /// 10.12.2009 15:45 >> 101220091545        
        /// </summary>
        public static string DateStr(){
            StringBuilder strText = new StringBuilder("");
            strText.Append(DateTime.Now.Day.ToString().PadLeft(2, '0'));
            strText.Append(DateTime.Now.Month.ToString().PadLeft(2, '0'));
            strText.Append(DateTime.Now.Year.ToString());
            strText.Append(DateTime.Now.Minute.ToString().PadLeft(2, '0'));
            strText.Append(DateTime.Now.Second.ToString().PadLeft(2, '0'));
            return strText.ToString();
        }

        /// <summary>
        /// Noktadan sonraki uzantýyý almak
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string GetExtension(string Text) {
            return Text.Substring(Text.LastIndexOf('.'));
        }

        public static float ByteToMB(float Byte) {
            try { return (Byte / 1048576); }
            catch (Exception) { return Byte; }
        }

        /// <summary>
        /// Sql Server a gönderebilmek için tarihi formatlar
        /// 19.07.2009 > 2009-07-19
        /// </summary>
        /// <param name="inDate"></param>
        /// <returns></returns>
        public static string DateForSql(DateTime inDate) {
            return inDate.Year.ToString() + "-" + inDate.Month.ToString().PadLeft(2, '0') + "-" + inDate.Day.ToString().PadLeft(2, '0');
        }

        public static int Age(DateTime BirthDate) {
            return DateTime.Now.Year - BirthDate.Year;
        }

        public static string MonthName(int MonthNumber) {
            switch (MonthNumber)
            {
                case 1:
                    return "Ocak";
                case 2:
                    return "Þubat";
                case 3:
                    return "Mart";
                case 4:
                    return "Nisan";
                case 5:
                    return "Mayýs";
                case 6:
                    return "Haziran";
                case 7:
                    return "Temmuz";
                case 8:
                    return "Aðustos";
                case 9:
                    return "Eylül";
                case 10:
                    return "Ekim";
                case 11:
                    return "Kasým";
                case 12:
                    return "Aralýk";
            }
            return "";
        }

        public static void ResetFields(ControlCollection pageControls)
        {
            foreach (Control contl in pageControls)
            {
                string strCntName = (contl.GetType()).Name;
                switch (strCntName)
                {
                    case "TextBox":
                        TextBox tbSource = (TextBox)contl;
                        tbSource.Text = "";
                        break;
                    case "RadioButtonList":
                        RadioButtonList rblSource = (RadioButtonList)contl;
                        rblSource.SelectedIndex = -1;
                        break;
                    case "DropDownList":
                        DropDownList ddlSource = (DropDownList)contl;
                        ddlSource.SelectedIndex = -1;
                        break;
                }
            }
        }

        public static void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox) ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList) ((DropDownList)ctrl).ClearSelection();

                ClearInputs(ctrl.Controls);
            }
        }

        public static string BindRichText(string Text) {
            string UnCleanedChars = "<p>\r\n\t&nbsp;</p>\r\n<p>\r\n\t";
            if (StringHelper.Left(Text, UnCleanedChars.Length) == UnCleanedChars) Text = Text.Replace(UnCleanedChars, "");
            return StringHelper.Nl2Br(Text.TrimStart().TrimEnd());
        }

        public static void GridHeaderLbCssEmpty(Control ParentControl) {
            foreach (Control ctrl in ParentControl.Controls)
            {
                if (ctrl is Repeater) break;
                else if (ctrl is LinkButton)
                {
                    LinkButton lbClassed = ((LinkButton)ctrl);
                    if ((lbClassed.CssClass == LIB.Var.OrderType.ASC.ToString()) || (lbClassed.CssClass == LIB.Var.OrderType.DESC.ToString()))
                        lbClassed.CssClass = "";
                }
            }        
        }

        public static string GetConfigValue(string ConfigName) {
            return ConfigurationManager.AppSettings[ConfigName].ToString();
        }
    }
}