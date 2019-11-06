using Kledex.Extensions;
using Kledex.Store.Cosmos.Mongo.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scheduler.Domain;
using Scheduler.Reporting.Data;

namespace Scheduler.Web
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
			services
				.AddControllers();

			// configure readmodel - mysql db
			services.AddDbContext<SchedulerReadModelDbContext>(o => o.UseNpgsql(Configuration.GetConnectionString("ReadModel")));

			services
				.AddScoped<IReadModelService, ReadModelService>()
			;

			services
				.AddKledex(typeof(Appointment))

				// configure event store (MongoDB)
				.AddCosmosDbMongoDbProvider(Configuration)

				// configure message bus (rabbitMQ)
				//.AddRabbitMQProvider(Configuration)
				;
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SchedulerReadModelDbContext readModelDbContext)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			readModelDbContext.Database.EnsureCreated();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
