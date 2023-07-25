using CourseZone.Service.Interfaces.Auth;
using CourseZone.Service.Interfaces.Common;
using CourseZone.Service.Interfaces.Courses;
using CourseZone.Service.Interfaces.Notifcations;
using CourseZone.Service.Interfaces.Videos;
using CourseZone.Service.Services.Auth;
using CourseZone.Service.Services.Common;
using CourseZone.Service.Services.Courses;
using CourseZone.Service.Services.Notifications;
using CourseZone.Service.Services.Videos;

namespace CourseZone.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IVideoProtsesService, VideoProtsesService>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<ICourseTypeService, CourseTypeService>();
        builder.Services.AddScoped<ICourseService, CourseService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IVideoService, VideoService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        
        
        builder.Services.AddSingleton<IEmailSender, EmailSender>();

    }
}
