using CourseZone.Service.Services.Common;
using CourseZone.DataAccsess.Interfaces.Courses;
using CourseZone.DataAccsess.Repositories.Courses;
using CourseZone.Service.Interfaces.Common;
using CourseZone.Service.Interfaces.Courses;
using CourseZone.Service.Services.Courses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICourseTypeRepository, CourseTypeRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICourseTypeService, CourseTypeService>();



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
