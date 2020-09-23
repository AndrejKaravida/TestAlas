using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using TestApi.Core.IRepository;
using TestApi.Persistence;
using TestApi.Responses;

namespace TestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddControllers();

            services.AddScoped<ITranslationRepository, TranslationRepository>();

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", b => b
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

            services.AddControllers().AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>())
               .ConfigureApiBehaviorOptions(opts =>
               {
                   opts.InvalidModelStateResponseFactory = context =>
                   {
                       var errors = context.ModelState
                         .Where(x => x.Value.Errors.Any())
                         .SelectMany(field => field.Value.Errors.Select(fieldError => new ErrorModel()
                         {
                             FieldName = field.Key,
                             Message = fieldError.ErrorMessage
                         }));
                       return new BadRequestObjectResult(new ErrorResponse(errors.ToList()));
                   };
               });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
