using EmergencyTrack.Application.Repositories;
using EmergencyTrack.Infrastructure.Mssql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpFunctionalExtensions.Result;

namespace EmergencyTrack.Infrastructure.Mssql
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<ApplicationDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddRepositories();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAmbulanceRequestRepository, AmbulanceRequestRepository>();
            services.AddScoped<ICauseOfRecallRepository, CauseOfRecallRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IEmergencyStationRepository, EmergencyStationRepository>();
            services.AddScoped<IProcedurePerformedRepository, ProcedurePerformedRepository>();
            services.AddScoped<IProcedureRepository, ProcedureRepository>();
            services.AddScoped<ISickPersonRepository, SickPersonRepository>();
            services.AddScoped<ISocialStatusRepository, SocialStatusRepository>();

            return services;
        }
    }
}
