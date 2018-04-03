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
    public class KlubumHandler : BaseHandler
    {
        public Klubum Data { get; set; }

        public KlubumHandler()
        {
            Data = new Klubum();
        }

        public Klubum PrepareData()
        {
            //MUSTERI KLUP BILGILERI
            try
            {
                CustomerClubsQuery CustomerClubsQueryObj = WebServiceLoader.CustomerClubsQuery();

                if (CustomerClubsQueryObj == null) return Data;

                Clubs clubInfo;
                foreach (var item in CustomerClubsQueryObj.ClubList.ToList())
                {
                    clubInfo = new Clubs
                    {
                        Club = item.Club,
                        Rank = item.Rank
                    };

                    Data.Clubs.Add(clubInfo);
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
