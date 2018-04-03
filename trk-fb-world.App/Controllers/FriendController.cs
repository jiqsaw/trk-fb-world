using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.Filters;
using TurkcellFacebookDunyasi.App.Models;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Services;
using TurkcellFacebookDunyasi.EF;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    [ActionLog]
    public class FriendController : BaseController
    {

        private ClickToCallUserBlockService servClickToCallUserBlock;


        public FriendController(ClickToCallUserBlockService srvClickToCallUserBlock)
        {
            servClickToCallUserBlock = srvClickToCallUserBlock;
        }

        public PartialViewResult FriendList(string NextUrl)
        {
            ViewBag.NextUrl = NextUrl;
            return PartialView();
        }

        public PartialViewResult FriendProfile(int Id)
        {
            ProfileModel model = new ProfileModel();
            model.FriendData = UserFb.Friends.Where(p => p.UserId == Id).SingleOrDefault();
            model.UserBlocks = servClickToCallUserBlock.GetByUserId(UserFb.Data.Id).ToList();

            return PartialView(model);
        }

    }
}
