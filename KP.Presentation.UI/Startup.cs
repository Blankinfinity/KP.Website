using System;
using System.IO;
using KP.Domain.DapperAttributeMapper;
using KP.Domain.Entities.Models;
using KP.Infrastructure.IoC;
using KP.Infrastructure.Logger;
using KP.Presentation.UI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Serilog;

namespace KP.Presentation.UI
{
    public class Startup
    {
        public IApplicationContainerManager ContainerManager { get; private set; }
        /// <summary>
        /// Gets or sets the application configuration, where key value pair settings are stored. See
        /// http://docs.asp.net/en/latest/fundamentals/configuration.html
        /// http://weblog.west-wind.com/posts/2015/Jun/03/Strongly-typed-AppSettings-Configuration-in-ASPNET-5
        /// </summary>
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
                      .MinimumLevel.Is(Serilog.Events.LogEventLevel.Debug)
                      .Enrich.FromLogContext()
                      .WriteTo.File(Environment.MachineName + ".log")
                      .CreateLogger();

            var confBuilder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", true, true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
              .AddEnvironmentVariables();

            // https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows
            if (env.IsDevelopment())
            {
                confBuilder.AddUserSecrets<Startup>();
            }
            Configuration = confBuilder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Changed from void to IServiceProvider for autofac injection of services.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();

            services.ConfigureIISIntegration();

            services.ConfigureLoggerService();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Create the IServiceProvider based on the container.
            ContainerManager = new AutofacIoCManager();
            return ContainerManager.PopulateAndGetServiceProvider(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ILogManager logManager)
        {
            loggerFactory.AddSerilog(logManager.CreateLogger());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            //app.UseHttpsRedirection();
            app.Use(async (context, next) =>
            {
                await next();

          //have to ignore api urls here as otherwise we coulgn't get the correct response.
          //There must be a better way to ignore api calls though
          if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html"; // Put your Angular root page here 
              await next();
                }
            });

            app.UseDefaultFiles();

            // Set to UseStaticFile with Options to stop caching of static content
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        NoCache = true,
                        NoStore = true
                    };
                }
            });

            app.UseMvcWithDefaultRoute();
            TypeMapper.Initialize(typeof(Owner));
            TypeMapper.Initialize(typeof(Account));
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}
