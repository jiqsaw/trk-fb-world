using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class ClickToCallFreeService
    {
        private readonly IClickToCallFreeRepository _repository;

        public ClickToCallFreeService(IClickToCallFreeRepository repository)
        {
            _repository = repository;
        }

        public bool HadFreeCallWith(int participantA, int participantB)
        {
            return _repository.HadFreeCallWith(participantA, participantB);
        }

        public void Save(ClickToCallFree entity)
        {
            _repository.Save(entity);
        }

        public void SaveAndCommit(ClickToCallFree entity)
        {
            _repository.SaveAndCommit(entity);
        }

        public void Commit()
        {
            _repository.Commit();
        }
    }
}
