using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IS_Project.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddValidatorsFromAssembly(assembly);

        services
            .AddMediatR(cfg => cfg
                .AddOpenBehavior(typeof(ValidationPipelineBehavior<,>))
                .RegisterServicesFromAssembly(assembly));
        return services;
    }

    internal class ValidationPipelineBehavior<TRequest, TResponse>(IValidator<TRequest> validator)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);
            return await next.Invoke();
        }
    }
}
