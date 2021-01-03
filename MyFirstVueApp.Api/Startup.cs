using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyFirstVueApp.Database;
using BloggingContext = MyFirstVueApp.Database.Models.BloggingContext;

// using BloggingContext = MyFirstVueApp.Database.Models.BloggingContext;
// using ERPDbContext = ERP.DataModel.DataModel.ERPDbContext;

namespace MyFirstViewApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private string DefaultConnectionString { set; get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => 
                o.AddPolicy("MyPolicy", builder => {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));
            
            DefaultConnectionString = Configuration["ConnectionStrings:DefaultConnection"];
            
            services.AddDbContext<BloggingContext>(
                options => options.UseSqlServer(DefaultConnectionString));
                // options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            
            // if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            // {
            //     services.AddDbContext<BloggingContext>(options =>
            //         options.UseInMemoryDatabase("ERPDb"));
            // }
            // else
            // {
            //     services.AddDbContext<BloggingContext>(options =>
            //         options.UseSqlServer(
            //             configuration.GetConnectionString("DefaultConnection")));
            // }
            
            // services.AddDbContext<MyFirstVueApp.Database.Models.BloggingContext>(options =>
            //     options.UseSqlServer(
            //         configuration.GetConnectionString("DefaultConnection")));
            
            // services.AddDbContext<MyFirstVueApp.Database.Models.BloggingContext>(options =>
            //     // services.AddDbContext<BloggingContext>(options =>
            //
            //     // 
            //     // options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //     options.UseSqlServer(DefaultConnectionString));

            // services.AddScoped<IBloggingContext>(provider => provider.GetService<BloggingContext>());
            
            // services.AddScoped<IBloggingContext>(provider => provider.GetService<BloggingContext>());
            
            
            
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "MyFirstVueApp.Api", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerUI();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFirstVueApp.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}