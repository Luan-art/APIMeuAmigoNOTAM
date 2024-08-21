using APIMeuAmigoNOTAM.Domain.Commands.v1.CreateNotam;
using APIMeuAmigoNOTAM.Domain.Commands.v1.UpdateNotam;
using APIMeuAmigoNOTAM.Domain.Pipes.v1;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDomainContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Bootstrapper)));

            services.AddTransient<CreateNotamCommandHandler>();

            services.AddScoped<IValidator<CreateNotamCommand>, CreateNotamCommandValidator>();
            services.AddScoped<IValidator<UpdateNotamCommand>, UpdateNotamCommandValidator>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>));

            return services;
        }
    }
}
