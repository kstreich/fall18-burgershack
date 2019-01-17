using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using BurgerShack.Repositories;

namespace BurgerShack
{
  public class Startup
  {
    //Creates placeholder for _connectionString
    private readonly string _connectionString = "";

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;

      //gets connectionstring from appsettings.json
      _connectionString = configuration.GetSection("DB").GetValue<string>("mySQLConnectionString");
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      services.AddTransient<BurgerRepository>();
      services.AddTransient<DrinksRepository>();
      //provides IDbConnection to any class who needs it on instantiation
      services.AddTransient<IDbConnection>(x => CreateDBContext());
    }

    //Creates connection to database and returns the connection
    private IDbConnection CreateDBContext()
    {
      var connection = new MySqlConnection(_connectionString);
      connection.Open();
      return connection;
    }


    //CAN COPY/PASTE ALL THE INFO FROM THE HERE UP ^^^^

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
