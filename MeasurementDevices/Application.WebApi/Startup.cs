using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Interfaces;
using Application.WebApi.Configuration;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistance;

namespace Application.WebApi
{
    public class Startup
	{
		public IConfiguration Configuration { get; }
		private readonly IWebHostEnvironment _env;
		public Startup(IConfiguration configuration, IWebHostEnvironment env)
		{
			Configuration = configuration;
			_env = env;
		}


		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSwaggerGen();
			services.AddScoped<IMeasurementPointService, MeasurementPointService>();
			services.AddScoped<IVerificationService, VerificationService>();
			services.AddScoped<IAccountingService, AccountingService>();

			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlite(Configuration.GetConnectionString("TNEDbConnection")));
			services.AddScoped<AppDbContextInitialiser>();
			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
				app.ApplicationServices.InitialiseDatabaseAsync().GetAwaiter().GetResult();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
