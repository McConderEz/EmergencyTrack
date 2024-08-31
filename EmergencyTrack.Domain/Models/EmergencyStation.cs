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
    public class EmergencyStation: Entity<EmergencyStationId>
    {
        private EmergencyStation(EmergencyStationId id) : base(id) { }

        public EmergencyStation(
            EmergencyStationId id,
            StationNumber stationNumber,
            int countOfemployees,
            PhoneNumber phoneNumber,
            Address address,
            DistrictId districtId,
            District district,
            IEnumerable<AmbulanceRequest> ambulanceRequests)
            : base(id)
        {
            StationNumber = stationNumber;
            CountOfEmployees = countOfemployees;
            PhoneNumber = phoneNumber;
            Address = address;
            DistrictId = districtId;
            District = district;
            AmbulanceRequests = ambulanceRequests.ToList() ?? [];

        }

        public StationNumber StationNumber { get; private set; }
        public DistrictId DistrictId { get; private set; }
        public District? District { get; private set; }
        //TODO: Переделать в метод
        public int CountOfEmployees { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }

        public List<AmbulanceRequest> AmbulanceRequests { get; set; } = [];
    }
}
