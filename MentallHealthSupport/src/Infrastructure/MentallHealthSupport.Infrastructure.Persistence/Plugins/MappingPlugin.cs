#pragma warning disable SA1200
#pragma warning disable IDE0065

namespace MentallHealthSupport.Infrastructure.Persistence.Plugins;

using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;

/// <summary>
///     Plugin for configuring NpgsqlDataSource's mappings
///     ie: enums, composite types
/// </summary>
public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder) { }
}