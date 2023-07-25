using CourseZone.DataAccsess.Interfaces.Courses;
using CourseZone.DataAccsess.Interfaces.Users;
using CourseZone.DataAccsess.Interfaces.Videos;
using CourseZone.DataAccsess.Repositories.Courses;
using CourseZone.DataAccsess.Repositories.Users;
using CourseZone.DataAccsess.Repositories.Videos;

namespace CourseZone.WebApi.Configurations.Layers;

public static class DataAcsesConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<ICourseTypeRepository, CourseTypeRepository>();
        builder.Services.AddScoped<ICourseRepository, CourseRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IVideoRepository, VideosRepository>();
    }
}
