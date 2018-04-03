<%@ Page Language="C#"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>

    <%                                    
    
        public TurkcellFacebookDunyasi.ServiceConnector.TiklaKonus.getCallInformationResponse GetCallInformation(long CallId)
        {
            TurkcellFacebookDunyasi.ServiceConnector.TiklaKonus.getCallInformationRequest g = new TurkcellFacebookDunyasi.ServiceConnector.TiklaKonus.getCallInformationRequest();
            g.callId = CallId;
            return TurkcellFacebookDunyasi.ServiceConnector.Loader.GetInstance().TiklaKonusClient().getCallInformation(g);
        }
    
        //public string IsBusy(long CallId) {
        //        try
        //        {
        //            TurkcellFacebookDunyasi.ServiceConnector.TiklaKonus.getCallInformationResponse resp = GetCallInformation(CallId);
                
        //            Response.Write("<br />resp.participantStatusA: " + resp.participantStatusA.ToString());
        //            Response.Write("<br />resp.participantStatusB: " + resp.participantStatusB.ToString());
        //            Response.Write("<br />resp.status: " + resp.status.ToString());
                
        //            Response.Write("<br /><br /><br />");
                
        //            return (
        //                (resp.participantStatusA == TurkcellFacebookDunyasi.ServiceConnector.TiklaKonus.participantStatus.UNKNOWN) &&
        //                (resp.participantStatusB == TurkcellFacebookDunyasi.ServiceConnector.TiklaKonus.participantStatus.UNKNOWN) &&
        //                (resp.status == TurkcellFacebookDunyasi.ServiceConnector.TiklaKonus.callStatus.CLOSED)
        //                ).ToString();
        //        }
        //        catch (Exception ex) { return ex.ToString(); }
        //}
     
    %>

    <%--<%# IsBusy(20833258) %>--%>


</body>
</html>
