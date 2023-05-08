using BusinessLayer.FluentValidation;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Dependencies
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection service)
        {
            service.AddScoped<IRoleRepository, RoleRepository>();
            service.AddScoped<IStateRepository, StateRepository>();
            service.AddScoped<ICityRepository, CityRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ICountryRepository, CountryRepository>();
            service.AddScoped<IMenuRepository, MenuRepository>();
            service.AddScoped<IRightsDistributionRepository, RightsDistributionRepository>();
            service.AddScoped<IReportRepository, ReportRepository>();
            service.AddScoped<IComboRepository, ComboRepository>();
        }

        public static void AddValidationsDependency(this IServiceCollection service)
        {
            service.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RoleValidator>());
            service.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StateValidator>());
            service.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CityValidator>());
            service.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());
        }

    }
}
