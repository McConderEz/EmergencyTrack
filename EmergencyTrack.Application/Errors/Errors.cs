using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application.Errors
{
    public static class Errors
    {
        public static string FAILURE_CREATION = "entity creation fall with error";
        public static string FAILURE_DELETE = "entity has not been deleted";
        public static string FAILURE_GET = "failed to get the entities";
        public static string FAILURE_UPDATE = "failed to update the entity";
    }
}
