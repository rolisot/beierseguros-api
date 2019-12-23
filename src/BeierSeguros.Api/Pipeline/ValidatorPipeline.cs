using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeierSeguros.Shared.Notifications;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BeierSeguros.Api.Pipeline
{
    public class ValidatorPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse> where TResponse : Notifiable
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidatorPipeline(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any()
                ? Errors(failures)
                : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var notifiable = new Notifiable();

            foreach (var failure in failures)
            {
                notifiable.AddError(new NotifiableError(failure.ErrorMessage));
            }

            return Task.FromResult(notifiable as TResponse);
        }
    }
}