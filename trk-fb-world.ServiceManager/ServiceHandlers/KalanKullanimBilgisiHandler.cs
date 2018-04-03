using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.ServiceConnector;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using TurkcellFacebookDunyasi.ServiceManager.Models.Partials;

namespace TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers
{
    public class KalanKullanimBilgisiHandler : BaseHandler
    {
        public KalanKullanimBilgisi Data { get; set; }
        public Parameter.UserType UserType { get; set; }

        public KalanKullanimBilgisiHandler(int userType)
        {
            Data = new KalanKullanimBilgisi();
            UserType = (Parameter.UserType)userType;
        }

        public KalanKullanimBilgisi PrepareData()
        {
            //KALAN KULLANIM BİLGİLERİ - POSTPAID
            try
            {

                FreeUnits freeUnits;
                int i = 1;
                if (UserType == Parameter.UserType.posp)
                {
                    FreeServicesQueryResponse FreeServicesQueryObj = WebServiceLoader.FreeServicesQuery();

                    if (!String.IsNullOrEmpty(FreeServicesQueryObj.ErrorCode))
                        Data.ErrorMessage = FreeServicesQueryObj.ErrorMessage;
                    else
                    {
                        foreach (var item in FreeServicesQueryObj.FreeServicesQuery.FreeUnits.ToList())
                        {
                            freeUnits = new FreeUnits();
                            freeUnits.Id = i;
                            freeUnits.CampaignName = item.GetCampaignName;
                            freeUnits.UnitTypeDesc = item.GetUnitTypeDesc;
                            freeUnits.ZoneTypeDesc = item.GetZoneTypeDesc;
                            freeUnits.CreditUnit = item.GetCreditUnit2;
                            freeUnits.EndDate = item.GetDeactivationDate;
                            freeUnits.AvailableBalance = Convert.ToDouble(item.GetAvailableBalance2);
                            freeUnits.TotalBalance = Convert.ToDouble(item.GetCurrPeriodBalance2);
                            Data.FreeUnits.Add(freeUnits);

                            i++;
                        }
                    }
                }
                //KALAN KULLANIM BİLGİLERİ - PREPAID
                else
                {
                    PrepaidFreeServicesQueryResponse PrepFreeServicesQueryResponseObj = WebServiceLoader.PrepaidFreeServicesQuery();

                    if (!String.IsNullOrEmpty(PrepFreeServicesQueryResponseObj.ErrorCode))
                        Data.ErrorMessage = PrepFreeServicesQueryResponseObj.ErrorMessage;
                    else
                    {
                        foreach (var item in PrepFreeServicesQueryResponseObj.PrepaidFreeServicesQuery.FreeUnits.ToList())
                        {
                            freeUnits = new FreeUnits();
                            freeUnits.Id = i;
                            freeUnits.CampaignName = item.GetCampaignName;
                            freeUnits.UnitTypeDesc = item.GetUnitTypeDesc;
                            freeUnits.ZoneTypeDesc = item.GetZoneTypeDesc;
                            freeUnits.CreditUnit = item.GetCreditUnit2;
                            freeUnits.EndDate = item.GetDeactivationDate;
                            freeUnits.AvailableBalance = Convert.ToDouble(item.GetAvailableBalance2);
                            freeUnits.TotalBalance = Convert.ToDouble(item.GetCurrPeriodBalance2);
                            Data.FreeUnits.Add(freeUnits);

                            i++;
                        }
                    }
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
