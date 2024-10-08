﻿using CSharpFunctionalExtensions;
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
    public class EmergencyStation: Common.Entity<EmergencyStationId>
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
            List<AmbulanceRequest> ambulanceRequests)
            : base(id)
        {
            StationNumber = stationNumber;
            CountOfEmployees = countOfemployees;
            PhoneNumber = phoneNumber;
            Address = address;
            DistrictId = districtId;
            District = district;
            AmbulanceRequests = ambulanceRequests ?? [];

        }

        public StationNumber StationNumber { get; set; }
        public DistrictId DistrictId { get; set; }
        public District? District { get; set; }
        //TODO: Переделать в метод
        public int CountOfEmployees { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Address Address { get; set; }
        public List<AmbulanceRequest> AmbulanceRequests { get; set; } = [];

        public Result UpdateMainInfo(
            StationNumber? stationNumber,
            DistrictId? districtId,
            District? district,
            PhoneNumber? phoneNumber,
            Address? address)
        {
            StationNumber = stationNumber ?? StationNumber;
            DistrictId = districtId ?? DistrictId;
            District = district ?? District;
            PhoneNumber = phoneNumber ?? PhoneNumber;
            Address = address ?? Address;

            return Result.Success();
        }

        public void AddAmbulanceRequest(AmbulanceRequest ambulanceRequest) => AmbulanceRequests.Add(ambulanceRequest);
        public void RemoveAmbulanceRequest(AmbulanceRequest ambulanceRequest) => AmbulanceRequests.Remove(ambulanceRequest);

    }
}
