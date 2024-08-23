using EmergencyTrack.Domain.Common;
using EmergencyTrack.Domain.Shared.Ids;
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

        public string StationNumber { get; set; }
        public DistrictId DistrictId { get; set; }
        public int CountOfEmployees { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public List<AmbulanceRequest> AmbulanceRequests { get; set; } = [];
    }
}
