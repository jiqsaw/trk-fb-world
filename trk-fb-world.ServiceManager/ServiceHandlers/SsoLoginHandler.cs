using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using LIB.ExtentionMethods;
using TurkcellFacebookDunyasi.Com.Enums;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class SsoLoginHandler : BaseHandler
    {
        public SsoLogin Data;

        public SsoLoginHandler()
        {
            Data = new SsoLogin();
        }

        public SsoLogin PrepareData(string msisdn)
        { 
            //SSO Login istegi
            try
            {
                SsoLoginQuery ssoQueryObject = WebServiceLoader.SsoLoginQuery(msisdn);
                Data.CustomerType = ssoQueryObject.CustomerType;
                Data.CustomerPaymentType = ssoQueryObject.CustomerPaymentType;
                Data.CustomerMsisdn = ssoQueryObject.CustomerMsisdn;
                Data.SessionToken = ssoQueryObject.SessionToken;
                Data.Sid = ssoQueryObject.Sid;

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
