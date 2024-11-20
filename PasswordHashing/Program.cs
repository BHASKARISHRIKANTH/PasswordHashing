
using Microsoft.EntityFrameworkCore;
using PasswordHashing.Data;
using PasswordHashing.Repositories;
using PasswordHashing.Services;
using System;
using System.Text.Json.Serialization;

namespace PasswordHashing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<IUserRepository,UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddDbContext<UserDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"))
           );
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}