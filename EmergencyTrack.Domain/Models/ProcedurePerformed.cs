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
    public class ProcedurePerformed: Common.Entity<ProcedurePerformedId>
    {
        private ProcedurePerformed(ProcedurePerformedId id) : base(id) { }

        public ProcedurePerformed(
            ProcedurePerformedId id,
            Price price,
            IEnumerable<Procedure> procedures,
            AmbulanceRequestId ambulanceRequestId, 
            AmbulanceRequest ambulanceRequest) : base(id)
        {
            Price = price;
            Procedures = procedures.ToList() ?? [];
            AmbulanceRequestId = ambulanceRequestId;
            AmbulanceRequest = ambulanceRequest;
        }

        public Price Price { get; private set; }
        public List<Procedure> Procedures { get; private set; } = [];
        public AmbulanceRequestId AmbulanceRequestId { get; private set; }
        public AmbulanceRequest? AmbulanceRequest { get; private set; }

        public Result UpdateInfo(Price? price, AmbulanceRequestId? ambulanceRequestId, AmbulanceRequest? ambulanceRequest)
        {
            Price = price ?? Price;
            AmbulanceRequestId = ambulanceRequestId ?? AmbulanceRequestId;
            AmbulanceRequest = ambulanceRequest ?? AmbulanceRequest;

            return Result.Success();
        }

        public void AddProcedure(Procedure procedure) => Procedures.Add(procedure);
        public void RemoveProcedure(Procedure procedure) => Procedures.Remove(procedure);
    }
}
