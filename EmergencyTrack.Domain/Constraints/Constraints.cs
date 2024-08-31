using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Domain.Constraints
{
    public static class Constraints
    {
        public static readonly int MAX_VALUE_LENGTH = 100;
        public static readonly int MAX_DESCRIPTION_LENGTH = 1500;
        public static readonly double MIN_VALUE = 0;
        public static readonly int MAX_PHONENUMBER_LENGTH = 14;
        public static readonly int MIDDLE_NAME_LENGTH = 50;
        public static readonly int STATION_NUMBER_LENGTH = 10;
    }
}
