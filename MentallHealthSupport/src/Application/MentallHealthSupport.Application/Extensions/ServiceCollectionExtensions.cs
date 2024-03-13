using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MentallHealthSupport.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        return collection;
    }
}