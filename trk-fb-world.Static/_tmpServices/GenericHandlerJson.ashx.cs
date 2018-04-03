using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;

namespace TurkcellFacebookDunyasi.Static._tmpServices
{
    /// <summary>
    /// Summary description for tariffQuery
    /// </summary>
    public class tariffQuery : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.GetEncoding("windows-1254");

            string Path = ConfigurationManager.AppSettings["url_Static_phys"].ToString() + "_tmpServices\\";


            Path += context.Request.QueryString["q"].ToString() + ".txt";

            context.Response.Write(LIB.FileHelper.Read(Path));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class ssoLoginQuery : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.GetEncoding("windows-1254");

            string Path = ConfigurationManager.AppSettings["url_Static_phys"].ToString() + "_tmpServices\\";
            Path += context.Request.QueryString["q"].ToString() + ".txt";

            context.Response.Write(LIB.FileHelper.Read(Path));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class currentInvoiceQuery : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.GetEncoding("windows-1254");

            string Path = ConfigurationManager.AppSettings["url_Static_phys"].ToString() + "_tmpServices\\";
            Path += context.Request.QueryString["q"].ToString() + ".txt";

            context.Response.Write(LIB.FileHelper.Read(Path));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class customerClubsQuery : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.GetEncoding("windows-1254");

            string Path = ConfigurationManager.AppSettings["url_Static_phys"].ToString() + "_tmpServices\\";
            Path += context.Request.QueryString["q"].ToString() + ".txt";

            context.Response.Write(LIB.FileHelper.Read(Path));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class customerSubsQuery : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.GetEncoding("windows-1254");

            string Path = ConfigurationManager.AppSettings["url_Static_phys"].ToString() + "_tmpServices\\";
            Path += context.Request.QueryString["q"].ToString() + ".txt";

            context.Response.Write(LIB.FileHelper.Read(Path));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class billCycleQuery : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.GetEncoding("windows-1254");

            string Path = ConfigurationManager.AppSettings["url_Static_phys"].ToString() + "_tmpServices\\";
            Path += context.Request.QueryString["q"].ToString() + ".txt";

            context.Response.Write(LIB.FileHelper.Read(Path));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}