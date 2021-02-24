using AutoMapper;
using BlogApp.Business.DependencyInjection;
using BlogApp.Business.JwtConfig;
using BlogApp.WebAPI.AnnotationFilters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.WebAPI
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
            services.AddAutoMapper(typeof(Startup));
            services.AddDependencies();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer (option => {

                    option.RequireHttpsMetadata = true;
                    option.TokenValidationParameters = new TokenValidationParameters {

                        ValidIssuer = JwtConfig.Issuer,
                        ValidAudience = JwtConfig.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.SecurityKey)),

                        ValidateLifetime = true,

                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ClockSkew = TimeSpan.Zero
                      
                    };
                            
                });

            // this configuration ignores internal server error caused by returning nested objects from API
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).AddFluentValidation() ;

            services.AddScoped(typeof(ValidateId<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
