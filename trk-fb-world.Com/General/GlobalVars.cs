using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LIB;
using TurkcellFacebookDunyasi.Com.Enums;

namespace TurkcellFacebookDunyasi.Com.General
{
    public class GlobalVars
    {
        private static string _Language;        
        public static string Language
        {
            get {
                //Cookide yok ve değer boş ise (muhtemelen ilk kez giriş)
                if (String.IsNullOrEmpty(_Language))
                {
                    switch (System.Globalization.CultureInfo.CurrentCulture.Name)
                    {
                        case "tr-TR":
                        _Language = "tr";
                        Culture = "TR";
                        LanguageCode = (int)Parameter.Language.Turkish;
                            break;

                        case "en-US":
                            _Language = "en";
                            Culture = "US";
                            LanguageCode = (int)Parameter.Language.English;
                            break;

                        case "fa-IR":
                            _Language = "fa";
                            Culture = "IR";
                            LanguageCode = (int)Parameter.Language.Persian;
                            break;

                        case "ru-RU":
                            _Language = "ru";
                            Culture = "RU";
                            LanguageCode = (int)Parameter.Language.Russian;
                            break;

                        default:
                            _Language = "en";
                            Culture = "US";
                            LanguageCode = (int)Parameter.Language.English;
                            break;
                    }
                }
                return _Language;
            }
            set { 
                _Language = value;

                switch (value)
                {
                    case "tr":
                        LanguageCode = (int)Parameter.Language.Turkish;
                        break;

                    case "en":
                        LanguageCode = (int)Parameter.Language.English;
                        break;

                    case "fa":
                        LanguageCode = (int)Parameter.Language.Persian;
                        break;

                    case "ru-RU":
                        LanguageCode = (int)Parameter.Language.Russian;
                        break;

                    default:
                        LanguageCode = (int)Parameter.Language.English;
                        break;
                }

            }
        }

        public static int LanguageCode;

        public static string Culture;

        public static string LanguageCulture { get { return Language + "-" + Culture; } }

        public static string OrderMax = "99999999";
        public static int OrderLength = 4;
        public static int OrderLengthMin = 2;

        public static int CurrAdminId;

        public static string dateFormat = "dd/MM/yyyy";

        public static string[] arrExtensionsImg = { ".jpg",".jpeg",".gif",".png" };
        public static string ExtensionsImg = ".jpg, .jpeg, .gif, .png";
        
        public const string ImgValidationExpression = "(.*\\.([gG][iI][fF]|[jJ][pP][gG]|[jJ][pP][eE][gG])$)";

        public const string UrlRewriteExtension = "";

        public const string ImgNaming = "TurkcellFacebookDunyasi_";
        public const string NoPictureFileName = "NoPicture.jpg";
        public const string NoPicturePath = "images/app_utils/noimage.jpg";

        public const int EnumValueAll = 0;
        public const string DdlInitialValue = "-1";

        public const int NameCharLimit = 11;
        public const string NameExtChars = "..";

        public const int MaskedMsisdnLength = 4;
    }
}
