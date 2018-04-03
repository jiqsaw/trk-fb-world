function sendRequestToRecipients(fbIds) {
    FB.ui({
        method: 'apprequests',
        message: _fbInviteMsg,
        to: fbIds
    }, requestCallback);
}

function sendRequestViaMultiFriendSelector() {
    FB.ui({
        method: 'apprequests',
        message: _fbInviteMsg
    }, requestCallback);
}

function requestCallback(response) {
    if (response.request && response.to)
        GATracker('Invite_OK');
    else
        GATracker('Invite_Cancel');
}

function share() {
    FB.ui(
      {
          method: 'feed',
          name: _fbShareName,
          caption: _fbShareCaption,
          description: _fbShareDescription,
          link: _urlFacebookPageTab,
          picture: _fbAppImg
      },
      function (response) {
          if (response && response.post_id) {
              GATracker('Share_OK');
          } else {
              GATracker('Share_Cancel');
          }
      }
    );
}

function iFrameHeightRender() {
    if (FB != null) {
        FB.Canvas.setSize({ width: 810, height: document.body.offsetHeight });
        //FB.Canvas.scrollTo(0, 0);
    }
}