using Business.Services;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;
using Business.Interfaces;
using DataAccess;
using DataAccess.Repositories;
using Infrastructure.ExternalServices;
using Core.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DBHelpers>();

//  External Services 
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IExceptionService,ExceptionService>();

// Repositories
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IHallRepository, HallRepository>();
builder.Services.AddScoped<IMajorRepository, MajorRepository>();
builder.Services.AddScoped<IPeriodRepository, PeriodRepository>();
builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ILectureRepository, LectureRepository>();
builder.Services.AddScoped<IAcademicTermRepository, AcademicTermRepository>();
builder.Services.AddScoped<ICourseOfferingRepository, CourseOfferingRepository>();
builder.Services.AddScoped<ICourseRepository, CoursesRepository>();

// Services
builder.Services.AddScoped<IPeriodService, PeriodsService>();
builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IMajorService, MajorService>();
builder.Services.AddScoped<IHallService, HallService>();
builder.Services.AddScoped<IAdministratorService, AdministratorService>();
builder.Services.AddScoped<ITimeSlotsService, TimeSlotsService>();
builder.Services.AddScoped<ILectureService, LectureService>();
builder.Services.AddScoped<IAcademicTermService, AcademicTermService>();
builder.Services.AddScoped<ICourseOfferingService, CourseOfferingService>();
builder.Services.AddScoped<ICoursesService, CoursesService>();



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
