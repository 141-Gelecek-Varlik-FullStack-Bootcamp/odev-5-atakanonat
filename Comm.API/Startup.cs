using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Comm.API.Infrastructure;
using Comm.Service.Email;
using Comm.Service.Product;
using Comm.Service.User;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace Comm.API
{
    public class Startup
    {
        public static ConnectionMultiplexer Redis;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Redis = ConnectionMultiplexer.Connect("localhost:6379");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Comm.API", Version = "v1" });
            });
            var _mappingProfile = new MapperConfiguration(mp => mp.AddProfile(new MappingProfile()));
            var _mapper = _mappingProfile.CreateMapper();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddSingleton(_mapper);
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddScoped<LoginFilter>();
            services.AddStackExchangeRedisCache(action =>
            {
                action.Configuration = "localhost:6379";
            });
            services.AddHangfire(configuration =>
            {
                configuration.UseRedisStorage(Redis);
            });
            services.AddHangfireServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Comm.API v1"));
            }

            app.UseHangfireServer();

            app.UseHangfireDashboard();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });
        }
    }
}
