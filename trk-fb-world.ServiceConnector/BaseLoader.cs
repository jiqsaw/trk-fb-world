using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using TurkcellFacebookDunyasi.Core.Services;
using TurkcellFacebookDunyasi.EF;

namespace TurkcellFacebookDunyasi.ServiceConnector
{
    public class BaseLoader
    {
        private string TurkcellCookieName = "CSI_TcellSession";

        public string Sid
        { 
            get
            {
                return HttpContext.Current.Session[TurkcellCookieName] == null ? "" : HttpContext.Current.Session[TurkcellCookieName].ToString();
            }
            set
            {
                HttpContext.Current.Session[TurkcellCookieName] = value;
            }
        }

        protected TurkcellFacebookDunyasiDb _context;
        protected WebServiceRepository _webServiceRepository;
        protected WebServiceService _webServiceService;

        //Servis sorgularinda kullanilan ortak encoding.
        public Encoding RequestEncoding { get; set; }

        public BaseLoader()
        {
            RequestEncoding = System.Text.Encoding.UTF8;
            _context = new TurkcellFacebookDunyasiDb();
            _webServiceRepository = new WebServiceRepository(_context);
            _webServiceService = new WebServiceService(_webServiceRepository);
        }

        protected string GetJson(string Path, bool HasCookie = true)
        {
            using (var client = new WebClient())
            {
                client.Encoding = RequestEncoding;

                if (HasCookie)
                {
                    if (!String.IsNullOrEmpty(Sid))
                        client.Headers.Add(System.Net.HttpRequestHeader.Cookie, TurkcellCookieName + "=" + Sid);
                }

                var json = client.DownloadString(Path);
                return json;
            }
        }

        protected string GetJsonFromPost(string Path, NameValueCollection postData)
        {
            using (var client = new WebClient())
            {
                client.Encoding = RequestEncoding;

                if (!String.IsNullOrEmpty(Sid))
                    client.Headers.Add(System.Net.HttpRequestHeader.Cookie, TurkcellCookieName + "=" + Sid);

                var json = client.UploadValues(Path, postData);
                return RequestEncoding.GetString(json);
            }
        }

        protected string GetUrl(Com.WebServiceDefinitions.Naming Naming)
        {
            return _webServiceService.GetWebServiceUrl(Naming);
        }

        protected string GenerateRequestUrl(string baseUrl, NameValueCollection requestParameters)
        {
            return baseUrl + "?" + String.Join("&", Array.ConvertAll(requestParameters.AllKeys, key => String.Format("{0}={1}", key, requestParameters[key])));
        }

        public static T ParseJsonObject<T>(string json) where T : class, new()
        {
            JObject jobject = JObject.Parse(json);
            return JsonConvert.DeserializeObject<T>(jobject.ToString());
        }
    }
}
