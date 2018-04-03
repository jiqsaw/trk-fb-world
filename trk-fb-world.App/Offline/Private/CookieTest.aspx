<%@ Page Language="C#"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>

    <%        
        
        string ResponseData = "";
        string sid = "";
        string pageToken = "";

        string RequestUrl = "https://csi.turkcell.com.tr/fbcsi/facebook/login?csiEntranceId=1301&msisdn=5336033839";
        Response.Write("-- LOGIN --<br /><br />");
        Response.Write("<b>RequestUrl:</b> " + RequestUrl + "<br /><br />");
        using (var client = new System.Net.WebClient())
        {
            try
            {   
                client.Encoding = Encoding.UTF8;                
                ResponseData = client.DownloadString(RequestUrl);                
                Response.Write(ResponseData);
            }
            catch (Exception) { }
        }

        Response.Write("<br /><br /> ------------------------------------------ <br /><br />");

        Response.Write("<br /><br /><br />");

        RequestUrl = "https://csi.turkcell.com.tr/fbcsi/facebook/login?csiEntranceId=1301&msisdn=5321528280";        
        Response.Write("LOGIN FARKLI NUMARA --<br /><br />");
        Response.Write("<b>RequestUrl:</b> " + RequestUrl + "<br /><br />");
        using (var client = new System.Net.WebClient())
        {
            try
            {
                client.Encoding = Encoding.UTF8;
                ResponseData = client.DownloadString(RequestUrl);
                Newtonsoft.Json.Linq.JObject jobject = Newtonsoft.Json.Linq.JObject.Parse(ResponseData);
                var s = Newtonsoft.Json.JsonConvert.DeserializeObject<TurkcellFacebookDunyasi.ServiceConnector.SsoLoginQuery>(jobject.ToString());
                sid = "TurkcellSession=" + s.Sid;
                pageToken = s.SessionToken;
                Response.Write(ResponseData);
            }
            catch (Exception) { }
        }
        
        
        Response.Write("<br /><br /> ------------------------------------------ <br /><br />");

        Response.Write("<br /><br /><br />");

        RequestUrl = "https://csi.turkcell.com.tr/fbcsi/facebook/currentInvoice?pageToken=" + pageToken;
        Response.Write("CURRENT INVOICE --<br /><br />");
        Response.Write("<b>Gönderilen Cookie:</b> " + sid + "<br /><br />");
        Response.Write("<b>RequestUrl:</b> " + RequestUrl + "<br /><br /><br /><br />");
        using (var client = new System.Net.WebClient())
        {
            try
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add(System.Net.HttpRequestHeader.Cookie, sid);
                ResponseData = client.DownloadString(RequestUrl);
                

                Response.Write(ResponseData);
            }
            catch (Exception) { }
        }


        Response.Write("<br /><br /> ------------------------------------------ <br /><br />");        
        
        
    %>


</body>
</html>
