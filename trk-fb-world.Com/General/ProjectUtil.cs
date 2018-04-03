using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Web;
using System.Data;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Com.Enums;

namespace TurkcellFacebookDunyasi.Com.General
{
    public class ProjectUtil
    {
        public static string GenerateImageName(string FileName) {
            return GlobalVars.ImgNaming + LIB.Util.CreateRandomNumber(4) + "_" + LIB.FormatHelper.FileName(FileName);
        }

        public static string MaskMsisdn(string Msisdn) {
            var formattedMsisdn = LIB.FormatHelper.Phone(Msisdn);
            return LIB.StringHelper.Left(formattedMsisdn, formattedMsisdn.Length - GlobalVars.MaskedMsisdnLength -1) + new String('*', GlobalVars.MaskedMsisdnLength);
        }

        public static bool CheckIfMsisdn(string input) {
            return (input.Length >= 10) && LIB.Util.IsNumeric(LIB.StringHelper.Right(input, 10));
        }

        public static string CallDetailOpAddres(string input, bool isSubscriptionActive) {
            input = input.TrimEnd();
            if (isSubscriptionActive == true)
            {
                return CheckIfMsisdn(input) ? LIB.FormatHelper.Phone(LIB.StringHelper.Right(input, 10)) : input;
            }
            else
            {
                return CheckIfMsisdn(input) ? MaskMsisdn(input) : input;
            }
        }
    }
}
