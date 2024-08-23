using EmergencyTrack.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Shared.Ids
{
    public class CauseOfRecallId(Guid id): BaseId<CauseOfRecallId>(id);
}
