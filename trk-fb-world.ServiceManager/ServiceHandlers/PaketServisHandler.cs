using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using TurkcellFacebookDunyasi.ServiceManager.Models.Partials;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class PaketServisHandler : BaseHandler
    {
        public PaketVeServis Data { get; set; }

        public PaketServisHandler()
        {
            Data = new PaketVeServis();
        }

        public PaketVeServis PrepareData()
        {
            //MUSTERI PAKET VE SERVIS ABONELIKLERI
            try
            {
                CustomerSubscriptionsQuery CustomerSubsQueryObj = WebServiceLoader.CustomerSubscriptionsQuery();

                if (CustomerSubsQueryObj == null) return Data;

                Services serviceInfo;
                foreach (var item in CustomerSubsQueryObj.CustomerSubscriptions.ToList())
                {
                    serviceInfo = new Services
                    {
                        ServiceName = item.ServiceName
                    };

                    Data.Services.Add(serviceInfo);
                }

                return Data;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
