using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager
{
    public class Definitions
    {

        public enum WebServiceName
        {
            TariffQuery = 1,            //HAT ÖZETİM TARİF SORGULAMA
            FreeServicesQuery = 2,      //HAT ÖZETİM KALAN KULLANIM
            SsoLogin = 3,               //SSO LOGIN ISTEGI
            CurrentInvoiceQuery = 4,    //GUNCEL FATURA BILGISI
            
        }

    }
}
