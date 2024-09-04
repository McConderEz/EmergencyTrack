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
            IEnumerable<CauseOfRecall> causeOfRecalls,
            IEnumerable<ProcedurePerformed> procedurePerformeds,
            EmergencyStationId emergencyStationId,
            EmergencyStation emergencyStation)
            :base(id)
        {
            RequestDateTime = requestDateTime;
            SickPersonId = sickPersonId;
            SickPerson = sickPerson;
            EmergencyStationId = emergencyStationId;
            EmergencyStation = emergencyStation;
            CauseOfRecalls = causeOfRecalls.ToList() ?? [];
            ProcedurePerformeds = procedurePerformeds.ToList() ?? [];
        }

        public RequestDateTime RequestDateTime { get; private set; }
        public List<CauseOfRecall> CauseOfRecalls { get; private set; } = [];
        public List<ProcedurePerformed> ProcedurePerformeds { get; private set; } = [];
        public SickPersonId SickPersonId { get; private set; }
        public SickPerson? SickPerson { get; private set; }
        public EmergencyStationId EmergencyStationId { get; private set; }
        public EmergencyStation? EmergencyStation { get; private set; }

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
