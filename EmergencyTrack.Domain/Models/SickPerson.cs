using EmergencyTrack.Domain.Common;
using EmergencyTrack.Domain.Shared.Ids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Models
{
    public class SickPerson: Entity<SickPersonId>
    {
        private SickPerson(SickPersonId id) : base(id) { }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public DateOnly BirthDate { get; set; }
        public SocialStatusId SocialStatusId { get; set; }
        public SocialStatus? SocialStatus { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
