using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.App_Manager;
using TurkcellFacebookDunyasi.App.Filters;
using TurkcellFacebookDunyasi.App.Models;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core.Services;
using TurkcellFacebookDunyasi.ServiceManager.Models;
using TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [FbAuthorize]
    [SSOAuthorize]
    [ActionLog]
    public class SmsGonderController : BaseController
    {
        private readonly IUserSmsRepository repository;
        private readonly UserSmsService service;

        public SmsGonderController(IUserSmsRepository repository, UserSmsService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public PartialViewResult Default()
        {
            return PartialView();
        }

        public PartialViewResult RemainingBalance()
        {
            try
            {
                WebSmsModel model = new WebSmsModel();
                WebSmsHandler handler = new WebSmsHandler();
                model.serviceData = handler.PrepareData(UserFb.Data.Msisdn);

                return PartialView(model);
            }
            catch (Exception)
            {
                return PartialView();
            }
        }

        [HttpPost]
        public ActionResult Default(UserSms entity, string ToIds, string ToMsisdns)
        {
            try
            {
                bool ServiceRequestStatus = true;
                bool multipleSendContainErrors = false;
                
                //WebSMS Servis Cagrisi.
                WebSmsHandler handler = new WebSmsHandler();
                string[] recipientMsisdns = ToMsisdns.Split(',');

                foreach (var recipient in recipientMsisdns)
                {
                    WebSms smsSendResult = handler.PrepareData(UserFb.Data.Msisdn, recipient, entity.Message);
                    if (smsSendResult.Error != null)
                    {
                        multipleSendContainErrors = true;
                    }
                }

                //BURADA ASLINDA BASARILI OLMA - KISMEN BASARILI OLMA VE TAMAMEN HATALI OLMA DURUMLARI VAR
                //BU IFI GENISLETMEK GEREKIYOR.
                if (ServiceRequestStatus == true && multipleSendContainErrors == false)
                {
                    ToIds = ToIds.Remove(0, 1);
                    ToIds = ToIds.Remove((int)ToIds.Length - 1, 1);
                    service.Add(UserFb.Data.Id, ToIds.Split(',').ToArray(), entity.CharNumber, entity.SMSFreeLimit, entity.Message, false);
                    return PartialResultSuccess("RequestSuccess");
                }
                else
                {
                    return PartialResultError("SentSMSError");
                }

            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }

    }
}
