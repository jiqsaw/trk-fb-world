<%@ Page Language="C#" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>

    <link href="Styles/Style.css" rel="stylesheet" />

    <script src="Scripts/jquery.js"></script>
    <script src="Scripts/Script.js"></script>

</head>
<body>
    
    <%
        string RequestUrl = Request.RawUrl.Substring(Request.RawUrl.IndexOf("|") + 1);
        string ResponseData = "";
        string ConnectStatus = "";
        string ExceptionMessage = "";

        using (var client = new System.Net.WebClient())
        {
            try
            {   
                client.Encoding = Encoding.UTF8;
                ResponseData = client.DownloadString(RequestUrl);

                ConnectStatus = "SUCCESS";
            }
            catch (Exception ex)
            {
                ConnectStatus = "FAIL";
                ExceptionMessage = ex.Message;
            }
        }
    %>
    
    <h1>REQUEST URL</h1>            <%=RequestUrl %>     
    <h1>CONNECT STATUS</h1>         <%=ConnectStatus %>

    <% if (ConnectStatus == "FAIL") { %>
    <h1>EXCEPTION MESSAGE</h1> <span class="exc"> <%=ExceptionMessage %> </span>
    
    <% } 
    else { %>
   
    <h1>RESPONSE DATA</h1>          
    <span id="responseDataOutput"><%=ResponseData %></span>
        
    <% } %>    

</body>
</html>