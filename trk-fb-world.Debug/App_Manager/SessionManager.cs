using System;
using System.Web;
using TurkcellFacebookDunyasi.Com.Enums;
using LIB.ExtentionMethods;

namespace TurkcellFacebookDunyasi.App.App_Manager
{
    public class SessionManager
    {
        #region Structure
        private System.Web.SessionState.HttpSessionState S;

        //private static SessionManager _sessionManager;

        private SessionManager() { this.S = HttpContext.Current.Session; }

        public static SessionManager GetInstance()
        {
            return new SessionManager();

            /*if (_sessionManager == null)
                _sessionManager = new SessionManager();
            return _sessionManager;*/
        }

        private void SET(SessionType SessionName, object Value) { S[SessionName.ToString()] = Value; }
        private object GET(SessionType SessionName) { return S[SessionName.ToString()]; }

        #endregion

        public enum SessionType
        {
            IsFbLogin,
            IsSsoLogin,
            SessionUser,
            SessionUserFriends,
            PageToken,
            TurkcellSessionId,
            LdapQueryLock,
            IsSubscriptionActive
        }

        public string PageToken
        {
            get { return (GET(SessionType.PageToken).ToString()); }
            set { SET(SessionType.PageToken, value); }
        }

        public string TurkcellSessionId
        {
            get { return GET(SessionType.TurkcellSessionId).ToString(); }
            set { SET(SessionType.TurkcellSessionId, value); }
        }

        public bool HasSessionUser
        {
            get { return (GET(SessionType.SessionUser) != null); }
        }

        public bool HasSessionUserFriends
        {
            get { return (GET(SessionType.SessionUserFriends) != null); }
        }

        public string SessionUser
        {
            get { return (GET(SessionType.SessionUser).ToString()); }
            set { SET(SessionType.SessionUser, value); }
        }

        public string SessionUserFriends
        {
            get { return (GET(SessionType.SessionUserFriends).ToString()); }
            set { SET(SessionType.SessionUserFriends, value); }
        }

        public bool IsSubscriptionActive
        {
            get { return (GET(SessionType.IsSubscriptionActive) == null ? false : Convert.ToBoolean(GET(SessionType.IsSubscriptionActive))); }
            set { SET(SessionType.IsSubscriptionActive, value); }
        }

        public bool IsLdapQueryDone
        {
            get { return (GET(SessionType.LdapQueryLock) == null ? false : Convert.ToBoolean(GET(SessionType.LdapQueryLock))); }
            set { SET(SessionType.LdapQueryLock, value); }
        }

        public bool IsFbLogin
        {
            get { return (GET(SessionType.IsFbLogin) == null ? false : Convert.ToBoolean(GET(SessionType.IsFbLogin))); }
            set { SET(SessionType.IsFbLogin, value); }
        }

        public bool IsSsoLogin
        {
            get { return (GET(SessionType.IsSsoLogin) == null ? false : Convert.ToBoolean(GET(SessionType.IsSsoLogin))); }
            set { SET(SessionType.IsSsoLogin, value); }
        }

        public void Destroy() {
            S.Clear();
            S.Abandon();
        }
    }
}