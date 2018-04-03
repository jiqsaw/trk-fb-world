using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.EF
{
    public class ClickToCallFreeRepository : RepositoryDefault<ClickToCallFree>, IClickToCallFreeRepository
    {
        public ClickToCallFreeRepository(TurkcellFacebookDunyasiDb context) : base(context) { }

        public bool HadFreeCallWith(int participantA, int participantB)
        {
            return _context.ClickToCallFree.AsEnumerable().Any(f =>
                {
                    DateTime callDate = f.CreateDate;
                    long caller = f.ParticipantAUserId;
                    long callee = f.ParticipantBUserId;

                    return (caller == participantA && callee == participantB)
                        && (callDate.Year >= DateTime.Today.Year - 1);
                });
        }
    }
}
