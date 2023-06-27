using HospitalApp.Infrastructure;
using HospitalApp.Models;
using HospitalApp.Models.Entities;
using HospitalApp.Services;
using HospitalApp.Services.Interfaces;

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