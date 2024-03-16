using MentallHealthSupport.Application.Contracts;
using MentallHealthSupport.Application.Services;

namespace MentallHealthSupport.Application.Extensions;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IReviewService, ReviewService>();
        return collection;
    }
}