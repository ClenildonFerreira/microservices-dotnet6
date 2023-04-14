using AnimeShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeShopping.ProductAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connection = builder.Configuration["MySqlConnection:MysqlConnectionString"];

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<MySQLContext>(options => options.
            UseMySql(connection,
                new MySqlServerVersion(
                    new Version(8, 0, 32))));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}