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

        public City(CityId id, Title title, IEnumerable<District> districts): base(id)
        {
            Title = title;
            Districts = districts.ToList() ?? [];
        }

        public Title Title { get; private set; }
        public List<District> Districts { get; set; } = [];
    }
}
