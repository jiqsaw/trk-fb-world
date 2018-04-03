using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurkcellFacebookDunyasi.Static
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            Response.ContentEncoding = Encoding.GetEncoding("windows-1254");

            string Path = ConfigurationManager.AppSettings["url_Static_phys"].ToString() + "_tmpServices\\";
            Path += Request.QueryString["q"].ToString() + ".txt";

            Response.Write(LIB.FileHelper.Read(Path));
        }
    }
}