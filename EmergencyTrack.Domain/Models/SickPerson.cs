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
    public class SickPerson: Entity<SickPersonId>
    {
        private SickPerson(SickPersonId id) : base(id) { }

        public SickPerson(
            SickPersonId id,
            FullName fullName,
            BirthDate birthDate,
            SocialStatusId socialStatusId,
            SocialStatus? socialStatus,
            PhoneNumber phoneNumber,
            Address address)
            : base(id)
        {
            FullName = fullName;
            BirthDate = birthDate;
            SocialStatusId = socialStatusId;
            SocialStatus = socialStatus;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public FullName FullName { get; private set; }
        public BirthDate BirthDate { get;  private set; }
        public SocialStatusId SocialStatusId { get; private set; }
        public SocialStatus? SocialStatus { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }
    }
}
