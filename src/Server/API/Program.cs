using Business.Services;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Business.Interfaces;
using DataAccess;
using DataAccess.Repositories;
using Infrastructure.ExternalServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DBHelpers>();
builder.Services.AddScoped<IExceptionService,ExceptionService>();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IHallRepository, HallRepository>();
builder.Services.AddScoped<IMajorRepository, MajorRepository>();
builder.Services.AddScoped<IPeriodRepository, PeriodRepository>();
builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();

builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IMajorService, MajorService>();
builder.Services.AddScoped<IHallService, HallService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
