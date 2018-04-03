using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LIB
{
    public sealed class StringHelper
    {
        public static string Left(string param, int length, string extChars = "")
        {
            if (param.Length > length)
                return param.Substring(0, length) + extChars;

            return param;
        }
        public static string Right(string param, int length)
        {
            if (param.Length < length) { length = param.Length; }
            return param.Substring(param.Length - length, length);
        }
        public static string Mid(string param, int startIndex, int length)
        {
            if (param.Length < length) { length = param.Length; }
            return param.Substring(startIndex, length);
        }
        public static string Mid(string param, int startIndex)
        {
            return param.Substring(startIndex);
        }

        public static string ToUpper(string Text)
        {
            return Text.Replace('i', 'İ').Replace('ı', 'I').ToUpperInvariant();
        }
        public static string ToLower(string Text)
        {
            return Text.Replace('İ', 'i').Replace('I', 'ı').ToLowerInvariant();
        }
        public static string SpecialName(string Text)
        {
            string strOutput = String.Empty;
            ArrayList arrTexts = new ArrayList();
            arrTexts.AddRange(Text.Split(' '));
            for (int i = 0; i < arrTexts.Count; i++)
            {
                if (arrTexts[i].ToString().Trim() != String.Empty)
                {
                    strOutput += ToUpper(Left(arrTexts[i].ToString(), 1)) + ToLower(Mid(arrTexts[i].ToString(), 1));
                    if ((arrTexts.Count > 0) && ((arrTexts.Count - 1) > i)) strOutput += ' ';
                }
            }
            return strOutput;
        }
        public static string FullName(string FirstName, string Surname) {
            return FirstName + " " + Surname;
        }

        /// <summary>
        /// String içindeki yeni satırları <code>&lt;br /&gt;</code>'ye dönüştürür.
        /// </summary>
        /// <param name="Text">Yeni satırları html break'e dönüştürülecek string</param>
        /// <returns>Yeni satırları break'e dönüştürülmüş string</returns>
        public static string Nl2Br(string Text)
        {
            return Text.Replace("\n", "<br />");
        }

        /// <summary>
        /// STRING TEMIZLE (REG EXP)
        /// </summary>
        /// <param name="input">Temizlenecek Değişken</param>
        /// <returns></returns>
        public static string ClearString(string input)
        {
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex("[^0-9a-zA-Z_işçöüğİŞÇÖÜĞ@\\-,.:]");
            return regEx.Replace(input, "");
        }

        /// <summary>
        /// String temizleme fonksiyonuna ihtiyaç duyulmuş mu ?
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool isNeedClearString(string input)
        {
            return (input != ClearString(input));
        }
        /// <summary>
        /// String deki tüm html taglarını temizler
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ClearHtmlTags(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "(<[^>]+>)", "");
        }

        /// <summary>
        /// Querystring var mı ve düzgün mü?
        /// </summary>
        /// <param name="input">Temizlenecek Değişken</param>
        /// <returns></returns>
        public static bool IsString(object input)
        {
            string m_input = String.Empty;

            if (input == null) { return false; }
            try
            {
                m_input = ClearString(input.ToString());
                if (m_input == string.Empty) { return false; }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// String in db ye kayıt için düzenlenmesi
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ReplaceStrForDB(string input)
        {
            return ClearHtmlTags(input).Replace("'", "");
        }

        ///<summary>
        /// Türkçe karakterleri İngilizce karakterlere çevirir
        /// </summary>
        public static string TrToEng(string Text)
        {
            return Text.Replace('ı', 'i').Replace('ş', 's').Replace('ğ', 'g').Replace('ü', 'u').Replace('ç', 'c').Replace('ö', 'o')
                .Replace('İ', 'I').Replace('Ş', 'S').Replace('Ğ', 'G').Replace('Ü', 'U').Replace('Ç', 'C').Replace('Ö', 'O').Trim();
        }
        public static string ReplaceSpaceWithChar(string text,string repChar)
    {
        return text.Replace(" ", repChar);
    }

        public static string PurifyStrFromTRChars(string Text)
        {
            return Text.Replace("ş", "&#351;").Replace("Ş", "&#350;").Replace("ı", "&#305;").Replace("İ", "&#304;").Replace("ö", "&ouml;").Replace("Ö", "&Ouml;").Replace("ç", "&ccedil;").Replace("Ç", "&Ccedil;").Replace("ğ", "&#287;").Replace("Ğ", "&#286;").Replace("ü", "&uuml;").Replace("Ü", "&Uuml;").Replace("’", "&rsquo;");
        }
    }
}
