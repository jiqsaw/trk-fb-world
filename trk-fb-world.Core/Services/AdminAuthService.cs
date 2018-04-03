using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core.CustomModels;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class AdminAuthService
    {
        private readonly IAdminAuthRepository repository;

        public AdminAuthService(IAdminAuthRepository repository)
        {
            this.repository = repository;
        }

        public void DestroyByAdminId(int AdminId) {
            var entities = repository.GetByAdminId(AdminId);

            foreach (var item in entities.ToList())
                repository.Destroy(item);
        }

        public void MultiSave(List<string> Values, int AdminId)
        {
            List<AdminAuth> AdminAuthEntities = new List<AdminAuth>();
            AdminAuth adminAuthEntity;
            foreach (var item in Values)
            {
                adminAuthEntity = new AdminAuth();
                adminAuthEntity.AdminId = AdminId;
                adminAuthEntity.ModulId = Int32.Parse(item);

                AdminAuthEntities.Add(adminAuthEntity);
            }

            foreach (var item in AdminAuthEntities)
                Save(item);        
        }

        public void Save(AdminAuth entity)
        {
            repository.Save(entity);
        }


        public IEnumerable<AdminAuth> GetByAdminId(int AdminId)
        {
            return repository.GetByAdminId(AdminId);
        }
    }
}
