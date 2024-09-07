using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmergencyTrack.Infrastructure.Mssql;
using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.ValueObjects;
using EmergencyTrack.Domain.Shared.Ids;
using NuGet.Versioning;
using System.Text;

namespace Generator
{
    public class NotesGenerator
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        private readonly Parser _parser = new Parser();

        private const string PATH = "C:\\Users\\lenka\\source\\repos\\EmergencyTrack\\EmergencyTrack.Generator.Mssql\\Dataset\\";

        public NotesGenerator()
        {
        }

        public void GenAll()
        {
            GenCity();
            GenDistrict();
            GetCauseOfRecall();
            GetProcedure();
            GenSocialStatus();
            GenEmergencyStation();
            GenSickPerson();
            GenAmbulanceRequest();
            GenProcedurePerformed();
        }



        public void GenCity()
        {
            var list = _parser.Parse(PATH + "City.txt");
            for (var i = 0; i < list.Count; i++)
            {
                var title = Title.Create(list[i]);
                var id = CityId.NewGuid();
                _dbContext.Cities.Add(new City(id, title.Value, null));
            }
            _dbContext.SaveChanges();
        }


        public void GenDistrict()
        {
            var list = _parser.ParseCSV(PATH + "District.csv");
            for (var i = 0; i < list.Count; i++)
            {
                var city = _dbContext.Cities.First(c => c.Title.Value.Equals(list[i].Item1));

                for (var j = 0; j < list[i].Item2.Count(); j++)
                {
                    var id = DistrictId.NewGuid();
                    var title = Title.Create(list[i].Item2[j]);
                    _dbContext.Districts.Add(new District(id, title.Value, city.Id, city, null));
                }
            }
            _dbContext.SaveChanges();
        }

        public void GetCauseOfRecall()
        {
            var list = _parser.Parse(PATH + "CauseOfRecall.txt");
            for (var i = 0; i < list.Count; i++)
            {
                var id = CauseOfRecallId.NewGuid();
                var cause = Cause.Create(list[i]);

                _dbContext.CauseOfRecalls.Add(new CauseOfRecall(id, cause.Value, null));
            }
            _dbContext.SaveChanges();
        }


        public void GetProcedure()
        {
            var list = _parser.Parse(PATH + "Procedure.txt");
            for (var i = 0; i < list.Count; i++)
            {
                var id = ProcedureId.NewGuid();
                var title = Title.Create(list[i]);
                _dbContext.Procedures.Add(new Procedure(id, title.Value, null));
            }
            _dbContext.SaveChanges();
        }

        public void GenSocialStatus()
        {
            var list = _parser.Parse(PATH + "SocialStatus.txt");
            for (var i = 0; i < list.Count; i++)
            {
                var id = SocialStatusId.NewGuid();
                var status = Status.Create(list[i]);
                _dbContext.SocialStatuses.Add(new SocialStatus(id, status.Value, null));
            }
            _dbContext.SaveChanges();
        }

        private static string GenerateStationNumber()
        {
            Random rnd = new Random();
            char[] ValidCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            var stringBuilder = new StringBuilder(10);

            for (int i = 0; i < 10; i++)
            {
 
                char randomChar = ValidCharacters[rnd.Next(ValidCharacters.Length)];
                stringBuilder.Append(randomChar);
            }

            return stringBuilder.ToString();
        }

        public void GenEmergencyStation()
        {
           
            Random rnd = new Random();
            var districtIds = _dbContext.Districts.Select(c => c.Id).ToList();
            var streets = _parser.Parse(PATH + "Streets.txt");

            for (var i = 0; i < 5000; i++)
            {
                var id = EmergencyStationId.NewGuid();
                var stationNumber = StationNumber.Create(GenerateStationNumber());
                var zipCode = rnd.Next(10000, 99999).ToString() + "-" + rnd.Next(1000, 9999).ToString();
                var address = Address.Create(
                    streets[rnd.Next(0, streets.Count)],
                    zipCode);
                _dbContext.EmergencyStations.Add(new EmergencyStation(
                    id,
                    stationNumber.Value,
                    0,
                    PhoneNumber.Create(GeneratePhoneNumber()).Value,
                    address.Value,
                    districtIds[rnd.Next(0, districtIds.Count)],
                    null,
                    null));
            }
            _dbContext.SaveChanges();
        }

        public static string GeneratePhoneNumber()
        {
            Random random = new Random();

            int countryCodeLength = random.Next(1, 4);
            string countryCode = GenerateRandomDigits(countryCodeLength, random);

            string mainNumber = GenerateRandomDigits(10, random);

            string phoneNumber = $"+{countryCode}{mainNumber}";

            return phoneNumber;
        }

        private static string GenerateRandomDigits(int length, Random random)
        {
            char[] digits = new char[length];
            for (int i = 0; i < length; i++)
            {
                digits[i] = (char)('0' + random.Next(0, 10));
            }

            return new string(digits);
        }

        public static DateTime GenerateRandomDate(DateTime startDate, DateTime endDate)
        {
            Random random = new Random();
            int range = (endDate - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }

        public void GenSickPerson()
        {
            Random rnd = new Random();
            var firstNames = _parser.Parse(PATH + "FirstName.txt");
            var secondNames = _parser.Parse(PATH + "SecondName.txt");
            var patronymics = _parser.Parse(PATH + "Patronymic.txt");
            var streets = _parser.Parse(PATH + "Streets.txt");
            var socialStatusIds = _dbContext.SocialStatuses.Select(c => c.Id).ToList();
            DateTime startDate = new DateTime(1960, 1, 1);
            DateTime endDate = DateTime.Now;

            for (var i = 0; i < 15000; i++)
            {
                for(var j = 0; j < 5; j++)
                {
                    var id = SickPersonId.NewGuid();
                    var stationNumber = StationNumber.Create(GenerateStationNumber());
                    var zipCode = rnd.Next(10000, 99999).ToString() + "-" + rnd.Next(1000, 9999).ToString();
                    var address = Address.Create(
                        streets[rnd.Next(0, streets.Count)],
                        zipCode);
                    var fullName = FullName.Create(
                        firstNames[rnd.Next(0, firstNames.Count)],
                        secondNames[rnd.Next(0, secondNames.Count)],
                        patronymics[rnd.Next(0, patronymics.Count)]);
                    _dbContext.SickPeople.Add(new SickPerson(
                        id,
                        fullName.Value,
                        BirthDate.Create(DateOnly.FromDateTime(GenerateRandomDate(startDate, endDate))).Value,
                        socialStatusIds[rnd.Next(0, socialStatusIds.Count)],
                        null,
                        PhoneNumber.Create(GeneratePhoneNumber()).Value,
                        address.Value,
                        null));
                }
            }
            _dbContext.SaveChanges();
        }

        public void GenAmbulanceRequest()
        {
            Random rnd = new Random();
            var causeOfRecalls = _dbContext.CauseOfRecalls.ToList();
            var sickPersonIds = _dbContext.SickPeople.Select(x => x.Id).ToList();
            var emergencyStationIds = _dbContext.EmergencyStations.Select(x => x.Id).ToList();
            DateTime startDate = new DateTime(2010, 1, 1);
            DateTime endDate = DateTime.Now;

            for (var i = 0; i < 20000; i++)
            {
                List<CauseOfRecall> causesOfRecall = [];
                for (var j = 0; j < rnd.Next(1,10); j++)
                {
                    causeOfRecalls.Add(causeOfRecalls[rnd.Next(0, causeOfRecalls.Count)]);        
                }

                var id = AmbulanceRequestId.NewGuid();

                _dbContext.AmbulanceRequests.Add(new AmbulanceRequest(
                    id,
                    RequestDateTime.Create(GenerateRandomDate(startDate, endDate)).Value,
                    sickPersonIds[rnd.Next(0, sickPersonIds.Count)],
                    null,
                    causesOfRecall,
                    null,
                    emergencyStationIds[rnd.Next(0, emergencyStationIds.Count)],
                    null
                    ));
            }
            _dbContext.SaveChanges();
        }

        public void GenProcedurePerformed()
        {
            Random rnd = new Random();
            var procedures = _dbContext.Procedures.ToList();
            var ambulanceRequestIds = _dbContext.AmbulanceRequests.Select(s => s.Id).ToList();

            for (var i = 0; i < ambulanceRequestIds.Count; i++)
            {
                List<Procedure> proceduresCreate = [];
                for (var j = 0; j < rnd.Next(1,10); j++)
                {
                    proceduresCreate.Add(procedures[rnd.Next(0, procedures.Count)]);
                }

                var id = ProcedurePerformedId.NewGuid();

                _dbContext.ProcedurePerformeds.Add(new ProcedurePerformed(
                    id,
                    Price.Create(rnd.Next(0, 500000)).Value,
                    proceduresCreate,
                    ambulanceRequestIds[rnd.Next(0, ambulanceRequestIds.Count)],
                    null
                    ));
            }
            _dbContext.SaveChanges();
        }


       
    }
    
}
