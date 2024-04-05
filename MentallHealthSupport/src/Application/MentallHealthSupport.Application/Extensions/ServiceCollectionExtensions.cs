using MentallHealthSupport.Application.Contracts.Services;
using MentallHealthSupport.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MentallHealthSupport.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IPsychologistService, PsychologistService>();
        collection.AddScoped<IReviewService, ReviewService>();
        collection.AddScoped<ISessionService, SessionService>();
        collection.AddScoped<ISpotService, SpotService>();
        collection.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        return collection;
    }
}