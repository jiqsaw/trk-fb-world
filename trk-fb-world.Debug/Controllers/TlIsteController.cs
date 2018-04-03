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
    public class TlIsteController : BaseController
    {
        //
        // GET: /TlIste/

        private readonly IUserRequestTLRepository repository;
        private readonly UserRequestTLService service;
        private readonly ITransferAmountRepository transferAmountRepository;
        private readonly TransferAmountService transferAmountService;

        public TlIsteController(IUserRequestTLRepository repository, UserRequestTLService service,ITransferAmountRepository transferAmountRepository,TransferAmountService transferAmountService)
        {
            this.repository = repository;
            this.service = service;
            this.transferAmountRepository = transferAmountRepository;
            this.transferAmountService = transferAmountService;
        }

        public PartialViewResult Default(string UserId)
        {
            var friend = UserFb.Friends.Where(u => u.UserId == Convert.ToInt32(UserId)).FirstOrDefault();
            ViewBag.TransferAmounts = GetAllTransferAmounts();
            return PartialView(friend);
        }

        [HttpPost]
        public ActionResult Default(UserRequestTL entity, string Msisdn)
        {
            try
            {
                bool ServiceRequestStatus = false;
                TlIsteModel model = new TlIsteModel();

                TLIsteHandler handler = new TLIsteHandler();
                model.serviceData = handler.PrepareData(Msisdn, Convert.ToInt32(entity.Amount.Replace(" TL", "")));
                if (model.serviceData != null)
                    ServiceRequestStatus = true;

                if (ServiceRequestStatus == true)
                {
                    entity.UserId = UserFb.Data.Id.ToString();
                    repository.SaveAndCommit(entity);

                    return PartialResultSuccess("RequestSuccess");
                }
                else
                {
                    return PartialResultError("RequestTLError");
                }
            }
            catch (Exception)
            {
                return PartialResultError();
            }
        }

        public SelectList GetAllTransferAmounts()
        {
            return new SelectList(transferAmountRepository.GetLiveTransferAmounts(), "TlTransferAmount", "TlTransferAmount");
        }

    }
}
