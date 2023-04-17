using AnimeShopping.ProductAPI.Config;
using AnimeShopping.ProductAPI.Model.Context;
using AnimeShopping.ProductAPI.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace AnimeShopping.ProductAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connection = builder.Configuration["MySqlConnection:MysqlConnectionString"];

        builder.Services.AddDbContext<MySQLContext>(options => options.
            UseMySql(connection,
                new MySqlServerVersion(
                    new Version(8, 0, 32))));

        IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

        builder.Services.AddSingleton(mapper);
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title="AnimeShopping.ProductAPI", Version="v1"});
            c.EnableAnnotations();
        });

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