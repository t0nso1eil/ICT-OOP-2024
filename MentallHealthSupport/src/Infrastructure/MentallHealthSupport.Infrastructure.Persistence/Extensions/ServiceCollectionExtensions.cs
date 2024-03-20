#pragma warning disable IDE0008
#pragma warning disable SA1005

using MentallHealthSupport.Application.Abstractions.Persistence;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Infrastructure.Persistence.Contexts;
using MentallHealthSupport.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MentallHealthSupport.Infrastructure.Persistence.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));

        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IPsychologistRepository, PsychologistRepository>();
        collection.AddScoped<IReviewRepository, ReviewRepository>();

        //collection.AddScoped<ISessionRepository, SessionRepository>();
        //collection.AddScoped<ISpotRepository, SpotRepository>();
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

        //AddAuthentication(collection, configuration);
        return collection;
    }

    private static void AddAuthentication(this IServiceCollection collection, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection(nameof(JwtOption)).Get<JwtOption>();
        collection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
            JwtBearerDefaults.AuthenticationScheme,
            options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey)),
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["coo-coo"];
                        return Task.CompletedTask;
                    },
                };
            });
        collection.AddAuthorization();
    }
}