#define WSDLTestPlatform

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using TurkcellFacebookDunyasi.Logger;
using TurkcellFacebookDunyasi.Com;

#if WSDLTestPlatform
using TurkcellFacebookDunyasi.ServiceConnector.BigLdap;
using BigLdapUpdateNS = TurkcellFacebookDunyasi.ServiceConnector.BigLdapUpdate;
using TurkcellFacebookDunyasi.Core;
#else

#endif

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class GetUpdatePersonHandler : BaseHandler
    {
        public Msisdn2FbResponse GetPerson(string msisdn)
        {
            //AppId bize tanimlanan AppId olacakmis. Simdilik 300 yazarak geciyoruz. Ancak daha sonra
            //bunu web.config'e baglamak gerekiyor.

            string srvRequestUrl = "msisdn2fb(" + msisdn + ", \"300\");";

            try
            {
                stringResult personResult = WebServiceLoader.GetPersonClient().msisdn2fb(msisdn, "300");

                var serializer = new LIB.Serialize();
                string responseDataAsString = serializer.SerializeObject(personResult);

                WebServiceLoader.Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = Com.WebServiceDefinitions.Naming.GetUserWsdl.ToString(),
                    RequestUrl = srvRequestUrl,
                    ResponseData = responseDataAsString
                });

                return new Msisdn2FbResponse
                {
                    ResultCode = personResult.resultCode.ToString(),
                    Value = personResult.value
                };
            }
            catch (Exception ex)
            {
                WebServiceLoader.Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Failure.ToString(),
                    Naming = Com.WebServiceDefinitions.Naming.GetUserWsdl.ToString(),
                    RequestUrl = srvRequestUrl,
                    ResponseData = ex.Message
                });
                return null;
            }
        }

        public void UpdatePerson(string msisdn, string facebookId)
        {
            string srvRequestUrl = "updateFID(" + msisdn + ", \"\", \"\", " + facebookId + ", \"300\");";

            try
            {
                BigLdapUpdateNS.personResult updateResult = WebServiceLoader.UpdatePersonClient().updateFID(msisdn, "", "", facebookId, "300");

                var serializer = new LIB.Serialize();
                string responseDataAsString = serializer.SerializeObject(updateResult);

                WebServiceLoader.Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = Com.WebServiceDefinitions.Naming.UpdateUserWsdl.ToString(),
                    RequestUrl = srvRequestUrl,
                    ResponseData = responseDataAsString
                });
            }
            catch (Exception ex)
            {
                WebServiceLoader.Log(new WebServiceLog
                {
                    Status = LogService.LogStatus.Success.ToString(),
                    Naming = Com.WebServiceDefinitions.Naming.UpdateUserWsdl.ToString(),
                    RequestUrl = srvRequestUrl,
                    ResponseData = ex.Message
                });
            }
        }
    }
}
