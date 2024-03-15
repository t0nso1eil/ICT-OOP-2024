#pragma warning disable CA1506

using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Logging.Extensions;
using MentallHealthSupport.Application.Extensions;
using MentallHealthSupport.Infrastructure.Persistence.Extensions;
using MentallHealthSupport.Presentation.Http.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddMvcCore();

builder.Services.AddOptions<JsonSerializerSettings>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JsonSerializerSettings>>().Value);

builder.Services.AddApplication();
builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services
    .AddControllers()
    .AddNewtonsoftJson()
    .AddPresentationHttp();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

builder.Host.AddPlatformSerilog(builder.Configuration);
builder.Services.AddUtcDateTimeProvider();

WebApplication app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

// app.UseAuthentication();
// app.UseAuthorization();
app.MapControllers();

await app.RunAsync();