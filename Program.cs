using HospitalApp.Infrastructure;
using HospitalApp.Models;
using HospitalApp.Models.Entities;
using HospitalApp.Services;
using HospitalApp.Services.Interfaces;
using Serilog;
using Serilog.Events;

namespace HospitalApp;

public class Program
{
    public static void Main(string[] args)
    {
        var app = CreateWebApplication(args);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }

    private static WebApplication CreateWebApplication(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
            .WriteTo.Console()
            .WriteTo.File(
                path: "HospitalApp-.log",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Host.UseSerilog(Log.Logger, true);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        builder.Services.AddCors();

        builder.Services.AddMemoryCache();

        builder.Services.AddAutoMapper(typeof(HospitalAppMappingProfile));

        builder.Services.AddDbContext<HospitalAppContext>();

        builder.Services.AddTransient<IListEntityService<Doctor>, ListEntityService<Doctor>>();

        builder.Services.AddTransient<IDoctorService, DoctorService>();

        builder.Services.AddTransient<IListEntityService<Patient>, ListEntityService<Patient>>();

        builder.Services.AddTransient<IPatientService, PatientService>();

        builder.Services.AddTransient<INsiService, NsiService>();

        return builder.Build();
    }
}