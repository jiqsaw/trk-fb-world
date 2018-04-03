<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title></title>
</head>
<body runat="server">
    <div>
        <%
            using (var context = new TurkcellFacebookDunyasi.EF.TurkcellFacebookDunyasiDb())
            {
                var webServiceList = context.WebService.Where(f => f.PlatformCode == 1).ToList();
                foreach (var webService in webServiceList)
                {
                    Response.Write("<li>" + webService.Url + "</li>");
                }
            }
        %>
    </div>
</body>
</html>
