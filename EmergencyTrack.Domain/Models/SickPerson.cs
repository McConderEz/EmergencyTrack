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
    public class SickPerson: Common.Entity<SickPersonId>
    {
        private SickPerson(SickPersonId id) : base(id) { }

        public SickPerson(
            SickPersonId id,
            FullName fullName,
            BirthDate birthDate,
            SocialStatusId socialStatusId,
            SocialStatus? socialStatus,
            PhoneNumber phoneNumber,
            Address address,
            IEnumerable<AmbulanceRequest> ambulanceRequests)
            : base(id)
        {
            FullName = fullName;
            BirthDate = birthDate;
            SocialStatusId = socialStatusId;
            SocialStatus = socialStatus;
            PhoneNumber = phoneNumber;
            Address = address;
            AmbulanceRequests = ambulanceRequests.ToList() ?? [];
        }

        public FullName FullName { get; private set; }
        public BirthDate BirthDate { get;  private set; }
        public SocialStatusId SocialStatusId { get; private set; }
        public SocialStatus? SocialStatus { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public List<AmbulanceRequest> AmbulanceRequests { get; private set; } = [];

        public Result UpdateMainInfo(
            FullName? fullName,
            BirthDate? birthDate,
            SocialStatusId? socialStatusId,
            SocialStatus? socialStatus,
            PhoneNumber? phoneNumber,
            Address? address)
        {
            FullName = fullName ?? FullName;
            BirthDate = birthDate ?? BirthDate;
            SocialStatusId = socialStatusId ?? SocialStatusId;
            SocialStatus = socialStatus ?? SocialStatus;
            PhoneNumber = phoneNumber ?? PhoneNumber;
            Address = address ?? Address;

            return Result.Success();
        }

        public void AddAmbulanceRequest(AmbulanceRequest request) => AmbulanceRequests.Add(request);
        public void RemoveAmbulanceRequest(AmbulanceRequest request) => AmbulanceRequests.Remove(request);

    }
}
