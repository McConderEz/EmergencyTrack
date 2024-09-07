using EmergencyTrack.Application.Abstractions;
using EmergencyTrack.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAmbulanceRequestService, AmbulanceRequestService>();
            services.AddScoped<ICauseOfRecallService, CauseOfRecallService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IEmergencyStationService, EmergencyStationService>();
            services.AddScoped<IProcedurePerformedService, ProcedurePerformedService>();
            services.AddScoped<IProcedureService, ProcedureService>();
            services.AddScoped<ISickPersonService, SickPersonService>();
            services.AddScoped<ISocialStatusService, SocialStatusService>();

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
