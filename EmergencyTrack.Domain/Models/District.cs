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
    public class District: Common.Entity<DistrictId>
    {
        private District(DistrictId id): base(id) { }

        public District(DistrictId id, Title title, CityId cityId, City? city, List<EmergencyStation> emergencyStations) : base(id)
        {
            Title = title;
            CityId = cityId;
            City = city;
            EmergencyStations = emergencyStations ?? [];
        }

        public Title Title { get; set; }
        public CityId CityId { get; set; }
        public City? City { get; set; }
        public List<EmergencyStation> EmergencyStations { get; set; } = [];

        public Result UpdateMainInfo(Title? title, CityId? cityId, City? city)
        {
            Title = title ?? Title;
            CityId = cityId ?? CityId;
            City = city ?? City;

            return Result.Success();
        }

        public void AddEmergencyStation(EmergencyStation emergencyStation) => EmergencyStations.Add(emergencyStation);
        public void RemoveEmergencyStation(EmergencyStation emergencyStation) => EmergencyStations.Remove(emergencyStation);
    }
}
