using Microsoft.Extensions.DependencyInjection;

using MediatR;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam;


namespace Domain
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDomainContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Bootstrapper)))
                .AddCommands()
                .AddValidators();
        }

        private static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddTransient<CreateNotamCommandHandler>();

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateNotamCommand>, CreateNotamCommandValidator>();
            return services;
        }

    }
}