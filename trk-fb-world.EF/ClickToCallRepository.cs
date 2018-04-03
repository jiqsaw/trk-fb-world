using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Com.General;
using TurkcellFacebookDunyasi.Core;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.EF
{
    public class ClickToCallRepository : RepositoryDefault<ClickToCall>, IClickToCallRepository
    {
        public ClickToCallRepository(TurkcellFacebookDunyasiDb context) : base(context) { }


        public IEnumerable<ClickToCallPromoteModel> FrequentlyCalled(int UserId)
        {
            return _context.ClickToCall
                                    .Where(p => (p.ParticipantAUserId == UserId || p.ParticipantBUserId == UserId) && p.IsDeleted == false)
                                    .GroupBy(g => g.ParticipantAUserId == UserId ? g.ParticipantBUserId : g.ParticipantAUserId)
                                    .Select(s => 
                                        new ClickToCallPromoteModel
                                        {
                                            FriendUserId = s.Key,
                                            CallCount = s.Count(),
                                            CreateDate = s.Max(m => m.CreateDate),
                                            PromoteType = ClickToCallPromoteModel.PromoteTypes.FrequentlyCalled
                                        })
                                    .OrderByDescending(g => g.CallCount).ToList();
        }


        public IEnumerable<ClickToCallPromoteModel> LastCalls(int UserId)
        {
            return _context.ClickToCall
                .Where(p => (p.ParticipantAUserId == UserId || p.ParticipantBUserId == UserId) && p.IsDeleted == false)
                .GroupBy(g => g.ParticipantAUserId == UserId ? g.ParticipantBUserId : g.ParticipantAUserId)
                .Select(s =>
                    new ClickToCallPromoteModel
                    {
                        CreateDate = s.Max(m => m.CreateDate),
                        CallCount = 0,
                        FriendUserId = s.Key,
                        PromoteType = ClickToCallPromoteModel.PromoteTypes.LastCalls
                    })
                .OrderByDescending(p => p.CreateDate).Take(12).ToList();
        }

    }
}