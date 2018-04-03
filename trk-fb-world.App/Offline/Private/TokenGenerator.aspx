<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title></title>
</head>
<body runat="server">
    <%
        string appId = "6";
        string appKey = "secret3459";
        string msisdn = "5323308474";
        string rand = DateTime.Now.Ticks.ToString();
        
        string messageToHash = appId + msisdn + rand;
        
        string token = "";
        string smsToken = "";
        
        var keyBytes = Encoding.UTF8.GetBytes(appKey);
        var algorithm = new System.Security.Cryptography.HMACSHA1(keyBytes);
        var messageBytes = Encoding.UTF8.GetBytes(messageToHash);

        algorithm.ComputeHash(messageBytes);
        for (int i = 0; i < algorithm.Hash.Length; i++)
            token += algorithm.Hash[i].ToString("X2");

        token = token.ToLowerInvariant();

        string requestUrl = "https://mesajlarim.turkcell.com.tr/omrestapi/api.php?action=balance&appId=" + appId + "&rand=" + rand + "&msisdn=" + msisdn + "&token=" + token;
        
        //Sms sorgusu icin gereken hashleme
        
        string message = "Turkcell WebSms Test";
        string recipient = "5321528280"; //5358881131";
        //WebServiceDefinitions.WebSMSAppId+senderMsisdn+message+recipientMsisdn+rand;
        messageToHash = appId + msisdn + message + recipient + rand;
        messageBytes = Encoding.UTF8.GetBytes(messageToHash);

        algorithm.ComputeHash(messageBytes);

        for (int i = 0; i < algorithm.Hash.Length; i++)
            smsToken += algorithm.Hash[i].ToString("X2");

        smsToken = smsToken.ToLowerInvariant();

        string smsRequestUrl = "https://mesajlarim.turkcell.com.tr/omrestapi/api.php?action=sendsms&appId=" + appId + "&rand=" + rand + "&msisdn=" + msisdn + "&token=" + smsToken + "&recipient=" + recipient + "&message=" + message;
    %>
    <div>
        <fieldset>
            <legend>Balance Query:</legend>
            <label>AppId: </label><span><%=appId %></span><br />
            <label>AppKey: </label><span><%=appKey %></span><br />
            <label>Msisdn: </label><span><%=msisdn %></span><br />
            <label>Rand: </label><span><%=rand %></span><br />
            <label>Token: </label><span><%=token %></span>
            <br />
            <br />
            <label>Request url: </label><span><%=requestUrl %></span>
        </fieldset>

        <fieldset>
            <legend>Message Query:</legend>
            <label>AppId: </label><span><%=appId %></span><br />
            <label>AppKey: </label><span><%=appKey %></span><br />
            <label>Msisdn: </label><span><%=msisdn %></span><br />
            <label>Recipient: </label><span><%=recipient %></span><br />
            <label>Message: </label><span><%=message %></span><br />
            <label>Rand: </label><span><%=rand %></span><br />
            <label>Token: </label><span><%=smsToken %></span>
            <br />
            <br />
            <label>Request url: </label><span><%=smsRequestUrl %></span>
        </fieldset>
    </div>
</body>
</html>
