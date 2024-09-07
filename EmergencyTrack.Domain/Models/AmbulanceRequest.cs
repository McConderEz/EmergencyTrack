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
    public class AmbulanceRequest: Common.Entity<AmbulanceRequestId>
    {
        private AmbulanceRequest(AmbulanceRequestId id): base(id) { }

        public AmbulanceRequest(
            AmbulanceRequestId id,
            RequestDateTime requestDateTime,
            SickPersonId sickPersonId,
            SickPerson? sickPerson,
            List<CauseOfRecall> causeOfRecalls,
            List<ProcedurePerformed> procedurePerformeds,
            EmergencyStationId emergencyStationId,
            EmergencyStation emergencyStation)
            :base(id)
        {
            RequestDateTime = requestDateTime;
            SickPersonId = sickPersonId;
            SickPerson = sickPerson;
            EmergencyStationId = emergencyStationId;
            EmergencyStation = emergencyStation;
            CauseOfRecalls = causeOfRecalls ?? [];
            ProcedurePerformeds = procedurePerformeds ?? [];
        }

        public RequestDateTime RequestDateTime { get; set; }
        public List<CauseOfRecall> CauseOfRecalls { get; set; } = [];
        public List<ProcedurePerformed> ProcedurePerformeds { get; set; } = [];
        public SickPersonId SickPersonId { get; set; }
        public SickPerson? SickPerson { get; set; }
        public EmergencyStationId EmergencyStationId { get; set; }
        public EmergencyStation? EmergencyStation { get; set; }

        public Result UpdateMainInfo(
            RequestDateTime? requestDateTime,
            SickPersonId? sickPersonId,
            SickPerson? sickPerson,
            EmergencyStationId? emergencyStationId,
            EmergencyStation? emergencyStation)
        {
            RequestDateTime = requestDateTime ?? RequestDateTime;
            SickPersonId = sickPersonId ?? SickPersonId;
            SickPerson = sickPerson ?? SickPerson;
            EmergencyStationId = emergencyStationId ?? EmergencyStationId;
            EmergencyStation = emergencyStation ?? EmergencyStation;

            return Result.Success();
        }

        public void AddCauseOfRecall(CauseOfRecall causeOfRecall) => CauseOfRecalls.Add(causeOfRecall);
        public void RemoveCauseOfRecall(CauseOfRecall causeOfRecall) => CauseOfRecalls.Remove(causeOfRecall);
        public void AddProcedurePerformed(ProcedurePerformed procedurePerformed) => ProcedurePerformeds.Add(procedurePerformed);
        public void RemoveProcedurePerformed(ProcedurePerformed procedurePerformed) => ProcedurePerformeds.Remove(procedurePerformed);

    }
}
