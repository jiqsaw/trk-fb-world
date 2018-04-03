using System.Web.Mvc;
using Microsoft.AspNet.Mvc.Facebook;
using MvcHelper.Facebook.Models;
using System.Web.Script.Serialization;
using MvcHelper.Facebook;
using Facebook;
using TurkcellFacebookDunyasi.Core.Services;
using System;
using TurkcellFacebookDunyasi.App.Models;
using System.Linq;
using TurkcellFacebookDunyasi.Com.Enums;
using LIB;
using TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers;
using TurkcellFacebookDunyasi.App.Filters;

namespace TurkcellFacebookDunyasi.App.Controllers
{
    public class StartController : BaseController
    {
        private readonly UserFbService UserService;
        public StartController(UserFbService UserService)
        {
            this.UserService = UserService;
        }

        public ActionResult Default()
        {
            ViewBag.IsPageLiked = FacebookUtil.IsPageLiked(Request.Params["signed_request"]);

            return View();
        }

        public PartialViewResult Landing()
        {
            return PartialView();
        }

        [HttpPost]
        [ActionLog]
        public JsonResult FbLogin(string JsonData)
        {
            try
            {
                var UserFbData = FacebookUtil.FetchingData(JsonData);

                PrepareUser(UserFbData);

                session.IsFbLogin = true;

                return Json(new { result = "1" }, "text/plain");
            }
            catch (Exception ex)
            {

                return Json(new { result = ex.Message + " inner ex: " + ex.InnerException }, "text/plain");
            }


        }

        private void PrepareUser(FacebookUser FbData)
        {
            string FbId = FbData.FbId;

            if (!String.IsNullOrEmpty(FbId))
            {

                UserFb.Data = UserService.GetByFbId(FbId);

                if (UserFb.Data == null)
                {
                    UserFb.Data = new Core.UserFb();
                    UserFb.Data.UserType = (int)Parameter.UserType.None;
                    UserFb.Data.CustomerType = (int)Parameter.CustomerType.None;
                }

                UserFb.Data.FbId = FbData.FbId;                
                UserFb.Data.FbFirstName = FbData.FirstName;
                UserFb.Data.FbFullName = FbData.Name;
                UserFb.Data.FbGender = FbData.Gender;
                UserFb.Data.FbEmail = FbData.Email;
                UserFb.Data.FbLastName = FbData.LastName;
                UserFb.Data.FbLocale = FbData.Locale;
                UserFb.Data.FbLocation = (FbData.Location != null) ? FbData.Location.Name : "";
                UserFb.Data.FbProfileLink = FbData.Link;
                UserFb.Data.FbProfilePicture = (FbData.ProfilePicture != null) ? FbData.ProfilePicture.Data.Url : "";
                UserFb.Data.FbUserName = FbData.UserName;
                UserFb.Data.FbBirthDay = FbData.BirthDay;
                UserFb.Data.LoginDate = DateTime.Now;

                session.SessionUser = (new Serialize()).SerializeObject(UserFb.Data);

                //Db ye kaydet, varsa update yoksa insert
                UserService.Save(UserFb.Data);

                //User Logon log tut
                //Turkcell e bilgi gönder (ldap)

                //IMPORTANT: Turkcell'in GetPerson servisini cagirmak icin kullanicinin MSISDN bilgisine
                //ihtiyacimiz var. Bu sebepten ldap cagrisini facebook logininden hemen sonra yapamiyoruz.
                //kullanici SSO login islemini gecip, veritabanina bir MSISDN kaydi alindiktan sonra
                //ldap getPerson servisini cagirmaliyiz.

                //user.Friends.Data daki idleri göndererek karşılık gelen msisdn no ları ve userId leri al            
                var UserFriendsData = UserService.GetUserFriendsData(UserFb.Data.Id, UserFb.Data.FbId, FbData.Friends.Data);

                //fb den gelen arkadaşların datalarını kendi arkadaş modelin ile merge (left join) edip, değerlerini set et
                UserFb.Friends = (from u in FbData.Friends.Data
                                  join uwd in UserFriendsData on u.FbId equals uwd.FbId
                                  into a
                                  from f in a.DefaultIfEmpty(new Core.UserFbDataModel { FbId = u.FbId, UserId = null, Msisdn = null })
                                  select new UserFbFriendModel
                                  {
                                      FbId = u.FbId,
                                      Name = u.Name,
                                      FirstName = u.FirstName,
                                      LastName = u.LastName,
                                      Picture = u.Picture,
                                      PictureLink = u.Picture.Data.Url,

                                      UserId = f.UserId,
                                      Msisdn = f.Msisdn,
                                      FbBirthDay = f.FbBirthDay,
                                      IsClickToCallBlock = f.IsClickToCallBlock,
                                      IsClickToCallInvisible = f.IsClickToCallInvisible,
                                      InComingCallCount = f.InComingCallCount,
                                      OutGoingCallCount = f.OutGoingCallCount

                                  }).ToList();

                //Session'in arkadas listesini de tutmasi gerekiyor.
                session.SessionUserFriends = (new Serialize()).SerializeObject(UserFb.Friends);
            }
        }
    }
}
