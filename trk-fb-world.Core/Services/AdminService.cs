using TurkcellFacebookDunyasi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class AdminService
    {
        private readonly IAdminRepository repository;

        public AdminService(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Admin Admin)
        {
            // email

            // erp data

            repository.Save(Admin);
            repository.Commit();
        }

        public void SaveLoginDate(Admin Admin)
        {
            Admin.LastLoginDate = DateTime.Now;
            repository.SaveAndCommit(Admin);
        }

        public Admin Auth(Admin Admin)
        {
            Admin _admin = repository.Auth(Admin.Username, Admin.Password);
            if (_admin != null)
                SaveLoginDate(_admin);
            
            return _admin;
        }

        public void SaveWithPermission(Admin Admin, AdminAuthService adminAuthService, List<string> RequestValues)
        {
            repository.Save(Admin);
            
            try
            {
                adminAuthService.DestroyByAdminId(Admin.Id);

                if (RequestValues != null)
                    adminAuthService.MultiSave(RequestValues, Admin.Id);
            }
            catch (Exception) { }

            repository.Commit();
        }
    }
}
