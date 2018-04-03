using MvcHelper.Facebook.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class UserFbService
    {
        private readonly IUserFbRepository repository;

        public UserFbService(IUserFbRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<UserFb> GetAllFbUsers()
        {
            return repository.GetAllFbUsers();
        }

        public IList<UserFbDataModel> GetUserFriendsData(int UserId, string FbId, IList<FacebookUserFriend> Friends)
        {
            return repository.GetUserFriendsData(UserId, FbId, Friends.Select(m => m.FbId).ToList());           
        }

        public UserFb GetByFbId(string FbId)
        {
            try
            {
                return repository.GetByFbId(FbId);
            }
            catch (Exception)
            {
                return null;
            }            
        }

        public void Save(UserFb entity) {
            try
            {
                repository.SaveAndCommit(entity);
            }
            catch (Exception) { }
        }

        public void Update(UserFb entity)
        {
            try
            {                
                repository.Update(entity);
            }
            catch (Exception)
            { }            
        }
    }   

}
