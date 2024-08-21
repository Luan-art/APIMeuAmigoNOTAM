using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIMeuAmigoNOTAM.Domain.Pipes.v1
{
    public class FailFastValidation<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public FailFastValidation(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);
            var failures = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var errors = failures.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (errors.Any())
            {
                var errorMessages = string.Join("; ", errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                throw new ValidationException($"Validation failed: {errorMessages}");
            }

            return await next();
        }
    }
}
