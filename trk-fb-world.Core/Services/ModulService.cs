using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Core.Interfaces;
using TurkcellFacebookDunyasi.Core.CustomModels;
using TurkcellFacebookDunyasi.Com.General;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class ModulService
    {
        private readonly IModulRepository repository;

        public ModulService(IModulRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Modul> GetLiveModuls()
        {
            return repository.GetLiveModuls();
        }

        public IEnumerable<Modul> GetListForAdmin()
        {
            return repository.GetListForAdmin();
        }

        public List<PanelMenuModel> GetAdminPermissions(int AdminId)
        {
            return FillPanelMenuModel(repository.GetAdminModuls(AdminId));
        }

        public List<PanelMenuModel> GetPanelMenuList()
        {
            return FillPanelMenuModel(GetListForAdmin().ToList());
        }

        private List<PanelMenuModel> FillPanelMenuModel(IEnumerable<Modul> listModul)
        {
            List<PanelMenuModel> listPanelMenuModel = new List<PanelMenuModel>();

            PanelMenuModel panelMenuModelItem;
            foreach (var item in listModul.ToList())
            {
                panelMenuModelItem = new PanelMenuModel();
                panelMenuModelItem.Id = item.Id;
                panelMenuModelItem.LanguageCode = item.Language;
                panelMenuModelItem.AdminPath = item.AdminPath;
                panelMenuModelItem.Description = item.Description;
                panelMenuModelItem.IsInAdminMenu = item.IsInAdminMenu;
                panelMenuModelItem.IsSubEndItem = item.IsSubEndItem;
                panelMenuModelItem.ParentId = item.ParentId;

                listPanelMenuModel.Add(panelMenuModelItem);
            }

            return listPanelMenuModel;
        }
    }
}
