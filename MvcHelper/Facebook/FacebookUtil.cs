using Facebook;
using Microsoft.AspNet.Mvc.Facebook;
using MvcHelper.Facebook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcHelper.Facebook
{
    public class FacebookUtil
    {
        public static T ParseJsonObject<T>(string json) where T : class, new()
        {
            JObject jobject = JObject.Parse(json);
            return JsonConvert.DeserializeObject<T>(jobject.ToString());
        }

        public static bool IsPageLiked(object SignedRequest)
        {
            if (SignedRequest != null)
            {                
                string signedRequest = (new FacebookClient()).ParseSignedRequest(GlobalFacebookConfiguration.Configuration.AppSecret, SignedRequest.ToString()).ToString();

                SignedRequest signedRequestObj = ParseJsonObject<SignedRequest>(signedRequest);
                return ((signedRequestObj.Page != null) && (signedRequestObj.Page.Liked));
            }
            return false;
        }

        public static FacebookUser FetchingData(string JsonData) {
            return ParseJsonObject<FacebookUser>(JsonData);
        }
    }
}
