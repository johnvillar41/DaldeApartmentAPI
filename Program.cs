using DaldeApartmentAPI.ApiKey;
using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Repositories.Implementations;
using DaldeApartmentAPI.Repositories.Interfaces;
using DaldeApartmentAPI.Services.Implementations;
using DaldeApartmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace DaldeApartmentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(Program));

            //Context
            builder.Services.AddDbContext<DaldeAptContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("LaptopConnection")));

            //Serilog
            builder.Host.UseSerilog((hostContext, services, configuration) =>
            {
                configuration.ReadFrom.Configuration(hostContext.Configuration, sectionName: "Serilog");
                var sinkOptions = new MSSqlServerSinkOptions
                {
                    TableName = "Logs",
                    AutoCreateSqlTable = true,
                    SchemaName = "dbo"
                };
                var columnOpts = new ColumnOptions();
                columnOpts.Store.Remove(StandardColumn.Properties);
                columnOpts.Store.Add(StandardColumn.LogEvent);
                columnOpts.LogEvent.DataLength = 2048;
                columnOpts.PrimaryKey = columnOpts.TimeStamp;
                columnOpts.TimeStamp.NonClusteredIndex = true;

                configuration.WriteTo.MSSqlServer(
                    connectionString: builder.Configuration.GetConnectionString("LaptopConnection"),
                    sinkOptions: sinkOptions,
                    columnOptions: columnOpts
                    );

            });

            // Add Dependency Injection for services
            builder.Services.AddTransient<IPaymentService, PaymentService>();
            builder.Services.AddTransient<IRenterService, RenterService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IApartmentService, ApartmentService>();
            builder.Services.AddTransient<IApartmentRenterService, ApartmentRenterService>();

            //Add Dependency Injection for repositories
            builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
            builder.Services.AddTransient<IApartmentRepository, ApartmentRepository>();
            builder.Services.AddTransient<IApartmentRenterRepository, ApartmentRenterRepository>();
            builder.Services.AddTransient<IRenterRepository, RenterRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseMiddleware<ApiKeyMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}