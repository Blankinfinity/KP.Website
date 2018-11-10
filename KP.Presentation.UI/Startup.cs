using System.IO;
using KP.Presentation.UI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace KP.Presentation.UI
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
      services.ConfigureCors();

      services.ConfigureIISIntegration();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
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
    }
  }
}
