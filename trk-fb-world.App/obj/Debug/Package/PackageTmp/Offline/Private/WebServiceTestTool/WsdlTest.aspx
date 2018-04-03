<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WsdlTest.aspx.cs" Inherits="TurkcellFacebookDunyasi.App.Offline.Private.WebServiceTestTool.WsdlTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <%
            TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers.FaturalarimHandler h = new TurkcellFacebookDunyasi.ServiceManager.ServiceHandlers.FaturalarimHandler();
            Response.Write(h.Test().ToString());
        %>

    </div>
    </form>
</body>
</html>
