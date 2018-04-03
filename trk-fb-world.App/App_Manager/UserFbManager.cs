using Microsoft.AspNet.Mvc.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkcellFacebookDunyasi.App.Models;
using TurkcellFacebookDunyasi.Core;
using LIB;

namespace TurkcellFacebookDunyasi.App.App_Manager
{
    public class UserFbManager
    {

        #region Structure

        //private static UserFbManager _UserFbManager;

        private SessionManager _sessionManager;
        private Serialize _serializer;

        public UserFbManager()
        {
            _sessionManager = SessionManager.GetInstance();
            _serializer = new Serialize();

            if (_sessionManager.HasSessionUser)
            {
                //Sessionda user bilgileri var ise, bunlari deserilaze edip data'ya aktariyoruz.
                Data = (UserFb)_serializer.DeserializeObject(_sessionManager.SessionUser, typeof(UserFb));
            }

            if (_sessionManager.HasSessionUserFriends)
            {
                //Ayni sekilde, user friend datasi sessionda var ise, Friends'e aktariyoruz.
                Friends = (List<UserFbFriendModel>)_serializer.DeserializeObject(_sessionManager.SessionUserFriends, typeof(List<UserFbFriendModel>));
            }            
        }

        public List<UserFbFriendModel> TodayBornFriends
        {
            get
            {
                return GetTodayBornFriends();
            }
        }

        public List<UserFbFriendModel> UpcomingBirthdayFriends
        {
            get
            {
                return GetUpcomingBirthdayFriends();
            }
        }

        private List<UserFbFriendModel> GetTodayBornFriends()
        {
            return Friends.Where(f =>
                {
                    if (f.FbBirthDay == null) return false;

                    string systemDay = String.Format("{0:dd}", DateTime.Today);
                    string systemMonth = String.Format("{0:MM}", DateTime.Today);

                    //0: Month, 1: Day
                    string[] userBirthDate = f.FbBirthDay.Split('/');

                    return (String.Equals(userBirthDate[0], systemMonth) && String.Equals(userBirthDate[1], systemDay));
                }).ToList();
        }

        private List<UserFbFriendModel> GetUpcomingBirthdayFriends()
        {
            return Friends.Where(f =>
                        {
                            if (f.FbBirthDay == null) return false;
                            int systemDate = Convert.ToInt32(String.Format("{0:MM}", DateTime.Today)+String.Format("{0:dd}", DateTime.Today));
                            string[] userBirthDate = f.FbBirthDay.Split('/');
                            int fbDate= Convert.ToInt32(userBirthDate[0] + userBirthDate[1]);
                            if (fbDate > systemDate)
                                return true;
                            else
                                return false;
                        }).OrderBy(f =>
                        {
                            string[] Split = f.FbBirthDay.Split('/');
                            string fbDate = Split[0] + Split[1];
                            return fbDate;
                        }).Take(4).ToList();
        }

        public void UpdateSession(bool includeFriends=false)
        {
            if (Data != null)
            {
                _sessionManager.SessionUser = _serializer.SerializeObject(Data);
            }

            if (includeFriends && Friends != null)
            {
                _sessionManager.SessionUserFriends = _serializer.SerializeObject(Friends);
            }
                
        }

        /*public static UserFbManager GetInstance()
        {
            if (_UserFbManager == null)
                _UserFbManager = new UserFbManager();
            return _UserFbManager;
        }*/

        #endregion

        public UserFb Data { get; set; }
        public IList<UserFbFriendModel> Friends { get; set; }

    }
}