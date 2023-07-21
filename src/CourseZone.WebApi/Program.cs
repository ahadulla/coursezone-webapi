using CourseZone.Service.Services.Common;
using CourseZone.DataAccsess.Interfaces.Courses;
using CourseZone.DataAccsess.Repositories.Courses;
using CourseZone.Service.Interfaces.Common;
using CourseZone.Service.Interfaces.Courses;
using CourseZone.Service.Services.Courses;
using CourseZone.Service.Services.Notifications;
using CourseZone.Service.Interfaces.Notifcations;
using CourseZone.DataAccsess.Interfaces.Users;
using CourseZone.DataAccsess.Repositories.Users;
using CourseZone.Service.Interfaces.Auth;
using CourseZone.Service.Services.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<ICourseTypeRepository, CourseTypeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICourseTypeService, CourseTypeService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddSingleton<IEmailSender, EmailSender>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
