using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Com
{
    public class WebServiceDefinitions
    {
        public static readonly string WebSMSAppId = ConfigurationManager.AppSettings["WebSMSAppId"].ToString();
        public static readonly string WebSMSSecretKey = ConfigurationManager.AppSettings["WebSMSSecretKey"].ToString();
        
        public static PlatformCode Platform = (PlatformCode)Convert.ToInt32(ConfigurationManager.AppSettings["WebServicePlatform"].ToString());        

        //SSO Login Values
        //public string PageToken { get; set; }
        //public string TcellSession { get; set; }

        public enum PlatformCode
        {
            None = 0,
            Prod = 1,
            Test = 2,
            Static = 3
        }

        public enum Naming
        {
            TariffQuery,                //TARİFE SORGULAMA
            FreeServicesQuery,          //KALAN KULLANIM (POSTPAID)
            SsoLogin,                   //SSO PAGE TOKEN ISTEK
            CurrentInvoiceQuery,        //GÜNCEL FATURA BİLGİSİ SORGULAMA
            CustomerClubsQuery,         //KLUP BILGISI SORGULAMA
            CustomerSubsQuery,          //SERVIS VE ABONELIK SORGULAMA
            BillCycleQuery,             //FATURA LIMIT SORGULAMA
            PrepaidFreeServicesQuery,   //KALAN KULLANIM (PREPAID)
            FaturaLimitSubsQuery,       //LIMIT KONTROLU
            KontormetreQuery,           //GUNCEL TL MIKTARI SORGULAMA
            KontorIsteLimitQuery,       //TL YUKLEME LIMITI SORGULAMA
            KontorIsteQuery,            //TL ISTE
            KontorGonderQuery,          //TL GONDER
            UsagePeriodDisplayQuery,    //TL DONEMLERI SORGULAMA
            FacebookOperationsQuery,    //EN COK ARANAN NUMARALARI SORGULAMA (POSTPAID)
            CallDetailsQuery,           //GORUSME DETAYLARI SORGULAMA (POSTPAID)
            WebSMSMessageQuery,         //WEB SMS GONDERIM
            WebSMSBalanceQuery,         //WEB SMS BALANCE SORGULAMA
            PrepaidCallDetailsQuery,    //GORUSME DETAYLARI SORGULAMA (PREPAID)
            CallDetailsSubscription,    //KULLANICININ FATURA DETAY ABONELIGINI SORGULAMA (PRE-POST)
            CorporateCallDetailsQuery,  //GORUSME DETAYLARI SORGULAMA (POSTPAID + KURUMSAL)

            GetUserWsdl,                //KULLANICI FBID SORGULAMA
            UpdateUserWsdl,             //KULLANICI FBID GUNCELLEME
            TiklaKonusWsdl,             //TIKLA KONUS SERVISI
            MobileBillInfoServiceWsdl,      //SON 6 FATURA
            MobileBillAnalysisServiceWsdl,  //FATURA ANALİZİ
        }
    }
}
