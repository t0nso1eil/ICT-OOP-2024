namespace MentallHealthSupport.Infrastructure.Persistence.Extensions;

using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Plugins;
using MentallHealthSupport.Application.Abstractions.Persistence;
using MentallHealthSupport.Infrastructure.Persistence.Migrations;
using MentallHealthSupport.Infrastructure.Persistence.Plugins;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddPlatformPostgres(builder => builder.BindConfiguration("Infrastructure:Persistence:Postgres"));
        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddPlatformMigrations(typeof(IAssemblyMarker).Assembly);
        collection.AddHostedService<MigrationRunnerService>();

        // TODO: add repositories
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

        return collection;
    }
}