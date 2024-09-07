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
    public class City: Common.Entity<CityId>
    {
        private City(CityId id) : base(id) { }

        public City(CityId id, Title title, IEnumerable<District> districts): base(id)
        {
            Title = title;
            Districts = districts.ToList() ?? [];
        }

        public Title Title { get; set; }
        public List<District> Districts { get; set; } = [];

        public Result UpdateMainInfo(Title? title)
        {
            Title = title ?? Title;

            return Result.Success();
        }

        public void AddDistrict(District district) => Districts.Add(district);
        public void RemoveDistrict(District district) => Districts.Remove(district);
    }
}
