using Kledex.Extensions;
using Kledex.Store.Cosmos.Mongo.Extensions;
using Kledex.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scheduler.Domain;
using Scheduler.Domain.CommandHandlers.CalendarCmdHdlrs;
using Scheduler.Domain.Commands.AppointmentCommands;
using Scheduler.Domain.Commands.CalendarCommands;
using Scheduler.Domain.Commands.UserCommands;
using Scheduler.Domain.Events;
using Scheduler.Domain.Policies;
using Scheduler.Domain.Repositories;
using Scheduler.Reporting.Data;
using Scheduler.Reporting.Data.Repositories;
using Scheduler.Reporting.EventHandlers.UserEvtHdlrs;

namespace Scheduler
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
				.AddControllers()
				.AddJsonOptions(options => options.JsonSerializerOptions.MaxDepth = 10);

			// configure readmodel - mysql db
			services.AddDbContext<SchedulerReadModelDbContext>(o => o.UseNpgsql(Configuration.GetConnectionString("ReadModel")));

			services
				.AddScoped<IReadModelService, ReadModelService>()
				.AddScoped<IAppointmentRepository, AppointmentRepository>()
				.AddScoped<IUserRepository, UserRepository>()
				.AddScoped<IPolicy<RegisterUser, User>, RegisterUserPolicy>()
				.AddScoped<IPolicy<RescheduleAppointment, Appointment>, RescheduleAppointmentPolicy>()
			;

			services
				.AddKledex
				(
					typeof(Appointment),
					typeof(CreateCalendar),
					typeof(CreateCalendarHandler),
					typeof(UserRegistered),
					typeof(UserRegisteredHandler)
				)

				// configure event store (MongoDB)
				.AddCosmosDbMongoDbProvider(options =>
				{
					options.DatabaseName = "SchedulerDomainStore";
					options.AggregateCollectionName = "Aggregates";
					options.CommandCollectionName = "Commands";
					options.EventCollectionName = "Events";
				})

				// configure policy-based validation for commands
				.AddPolicyValidationProvider()

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
