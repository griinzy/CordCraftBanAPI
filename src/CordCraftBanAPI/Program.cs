
using CordCraftBanAPI.ApiKey;
using CordCraftBanAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CordCraftBanAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BanDbContext>(options => options.UseSqlite("Data source=bans.db"));

            builder.Services.AddScoped<ApiKeyAuthFilter>();

            builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();

            builder.Services.AddHttpContextAccessor();

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
