using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurkcellFacebookDunyasi.App.Offline.Private.WebServiceTestTool
{
    public partial class Code : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Path = Server.MapPath(Request.QueryString["FileName"].ToString());
            StreamReader sr = new StreamReader(Path, Encoding.UTF8);
            
            Response.Write("<pre>" + System.Web.HttpUtility.HtmlEncode(sr.ReadToEnd()) + "</pre>");

            sr.Close();

        }
    }
}