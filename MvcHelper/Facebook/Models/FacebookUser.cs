using Microsoft.AspNet.Mvc.Facebook;
using Newtonsoft.Json;

// Add any fields you want to be saved for each user and specify the field name in the JSON coming back from Facebook
// http://go.microsoft.com/fwlink/?LinkId=273889

namespace MvcHelper.Facebook.Models
{
    public class FacebookUser
    {
        [JsonProperty("id")]
        public string FbId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }        

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("birthday")]
        public string BirthDay { get; set; }

        [JsonProperty("location")]
        public FacebookLocation Location { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("picture")] // This renames the property to picture.
        [FacebookFieldModifier("width(100).height(100)")] // This sets the picture size to large.
        //1025985782?fields=id,name,picture.width(50).height(50)
        public FacebookConnection<FacebookPicture> ProfilePicture { get; set; }

        //[FacebookFieldModifier("limit(8)")] // This sets the size of the friend list to 8, remove it to get all friends.
        [FacebookFieldModifier("fields(first_name,last_name)")] 
        public FacebookGroupConnection<FacebookUserFriend> Friends { get; set; }

        //[FacebookFieldModifier("limit(16)")] // This sets the size of the photo list to 16, remove it to get all photos.
        //public FacebookGroupConnection<FacebookPhoto> Photos { get; set; }
    }
}