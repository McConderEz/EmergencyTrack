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
    public class City: Entity<CityId>
    {
        private City(CityId id) : base(id) { }

        public City(CityId id, Title title): base(id)
        {
            Title = title;
        }

        public Title Title { get; private set; }
    }
}
