using CSharpFunctionalExtensions;
using EmergencyTrack.Domain.Common;
using EmergencyTrack.Domain.Shared.Ids;
using EmergencyTrack.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Models
{
    public class SocialStatus: Common.Entity<SocialStatusId>
    {
        private SocialStatus(SocialStatusId id) : base(id) { }

        public SocialStatus(
            SocialStatusId id,
            Status status,
            IEnumerable<SickPerson> sickPersons) : base(id)
        {
            Status = status;
            SickPersons = sickPersons.ToList() ?? [];
        }

        public Status Status { get; set; }
        public List<SickPerson> SickPersons { get; set; } = [];

        public Result UpdateMainInfo(Status? status)
        {
            Status = status ?? Status;

            return Result.Success();
        }

        public void AddSickPerson(SickPerson sickPerson) => SickPersons.Add(sickPerson);
        public void RemoveSickPerson(SickPerson sickPerson) => SickPersons.Remove(sickPerson);
    }
}
