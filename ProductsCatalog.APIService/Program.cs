
using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;
using ProductsCatalog.APIService.Models.DataAccess;

namespace ProductsCatalog.APIService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connStr = builder.Configuration.GetConnectionString("default");
            builder.Services.AddDbContext<ProductsDbContext>(opt =>
            {
                opt.UseSqlServer(connStr);
            });



            builder.Services.AddControllers().AddXmlSerializerFormatters();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddOData();
            var app = builder.Build();

            // Configure the HTTP request pipeline.




            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();


            //app.MapControllers();
            app.UseEndpoints(endpoints =>
            {
                endpoints.EnableDependencyInjection();
                endpoints.Select().OrderBy().Filter().MaxTop(100).SkipToken();
                endpoints.MapControllers();
            });


            app.Run();
        }
    }
}
