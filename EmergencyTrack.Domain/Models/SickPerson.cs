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
            List<AmbulanceRequest> ambulanceRequests)
            : base(id)
        {
            FullName = fullName;
            BirthDate = birthDate;
            SocialStatusId = socialStatusId;
            SocialStatus = socialStatus;
            PhoneNumber = phoneNumber;
            Address = address;
            AmbulanceRequests = ambulanceRequests ?? [];
        }

        public FullName FullName { get; set; }
        public BirthDate BirthDate { get; set; }
        public SocialStatusId SocialStatusId { get; set; }
        public SocialStatus? SocialStatus { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Address Address { get; set; }
        public List<AmbulanceRequest> AmbulanceRequests { get; set; } = [];

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
