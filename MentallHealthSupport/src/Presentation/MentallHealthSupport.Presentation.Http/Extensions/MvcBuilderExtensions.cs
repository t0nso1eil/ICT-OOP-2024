using MentallHealthSupport.Presentation.Http.Middlewares;

namespace MentallHealthSupport.Presentation.Http.Extensions;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddPresentationHttp(this IMvcBuilder builder)
    {
        builder.Services.AddSingleton<RequestMiddleware>();
        return builder.AddApplicationPart(typeof(IAssemblyMarker).Assembly);
    }
}