using Kendo.Mvc.UI;
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
using TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [FbAuthorize]
    [SSOAuthorize]
    [ActionLog]
    public class TlGonderController : BaseController
    {
        //
        // GET: /TlGonder/

        private readonly IUserSentTLRepository repository;
        private readonly UserSentTLService service;

        public TlGonderController(IUserSentTLRepository repository, UserSentTLService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public PartialViewResult Default(string UserId)
        {
            TlGonderModel model = new TlGonderModel();
            TLGonderHandler handler = new TLGonderHandler();
            model.serviceData = handler.PrepareData(TLGonderHandler.TLGonderMethod.GET);

            var friend = UserFb.Friends.Where(u => u.UserId == Convert.ToInt32(UserId)).FirstOrDefault();
            ViewBag.FbId = friend.FbId;
            ViewBag.Picture = friend.Picture.Data.Url;
            ViewBag.FirstNameView = friend.FirstNameView;
            ViewBag.LastNameView = friend.LastNameView;
            ViewBag.Msisdn = friend.Msisdn;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Default(UserSentTL entity, string ToMsisdn, int creditIndex)
        {
            try
            {
                bool ServiceRequestStatus = false;

                TlGonderModel model = new TlGonderModel();
                TLGonderHandler handler = new TLGonderHandler();
                model.serviceData = handler.PrepareData(ToMsisdn, creditIndex);
                model.serviceData = handler.PrepareData(TLGonderHandler.TLGonderMethod.POST);

                if (model.serviceData != null)
                {
                    ServiceRequestStatus = true;
                }

                if (ServiceRequestStatus == true)
                {
                    entity.UserId = UserFb.Data.Id.ToString();
                    repository.SaveAndCommit(entity);

                    return PartialResultSuccess("RequestSuccess");
                }
                else
                {
                    return PartialResultError("SentTLError");
                }
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }
    }
}
