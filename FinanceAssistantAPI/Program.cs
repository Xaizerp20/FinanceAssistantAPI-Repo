
using FinanceAssistantAPI.Data;
using FinanceAssistantAPI.Repository;
using FinanceAssistantAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using WEBTEST_API_PROYECT;

namespace FinanceAssistantAPI
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


            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DBstring"));
            });

            builder.Services.AddAutoMapper(typeof(MappingConfig));

            builder.Services.AddScoped<IFinancialRecordRepository, FinancialRecordRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }



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