using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.Core.Interfaces
{
    public interface IClickToCallFreeRepository : IRepositoryDefault<ClickToCallFree>
    {
        bool HadFreeCallWith(int participantA, int participantB);
    }
}
