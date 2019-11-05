using Microsoft.EntityFrameworkCore;
using Scheduler.Reporting.Data.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Scheduler.Reporting.Data
{
	public class SchedulerReadModelDbContext : DbContext
	{
		public DbSet<CalendarEntity> Calendars { get; set; }
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<AppointmentEntity> Appointments { get; set; }

		public SchedulerReadModelDbContext([NotNull] DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// define columns types
			builder.Entity<CalendarEntity>(entity =>
			{
				entity.Property(e => e.UtcCreatedAt)
					.HasColumnType("DateTime")
					.HasDefaultValueSql("GETUTCDATE()");

				entity.Property(e => e.Title)
					.IsRequired()
					.HasColumnType("VARCHAR(255)");

				entity.Property(e => e.UtcLastUpdate)
					.HasColumnType("DateTime");

				entity
					.HasMany(d => d.CalendarOrganisers)
					.WithOne(p => p.Calendar)
					.HasForeignKey(d => d.CalendarId)
					.OnDelete(DeleteBehavior.Cascade)
					//.HasConstraintName("dfgf");
				;

				entity.HasMany(d => d.Appointments)
					.WithOne(p => p.Calendar)
					.HasForeignKey(d => d.CalendarId)
					.OnDelete(DeleteBehavior.Cascade)
					//.HasConstraintName("FK_sdkfsjdk_")
				;
			});

			// define columns types
			builder.Entity<AppointmentEntity>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.UtcCreatedAt)
					.HasColumnType("DateTime")
					.HasDefaultValueSql("GETUTCDATE()");

				entity.Property(e => e.UtcStart)
					.IsRequired()
					.HasColumnType("DateTime");

				entity.Property(e => e.UtcEnd)
					.IsRequired()
					.HasColumnType("DateTime");

				entity.Property(e => e.Title)
					.HasMaxLength(128);

				entity.HasOne(d => d.Calendar)
					.WithMany(p => p.Appointments)
					.HasForeignKey(d => d.CalendarId)
					.OnDelete(DeleteBehavior.Cascade)
					//.HasConstraintName("FK_FinishedSessions_SessionContainerId");
				;
			});

			
		}


	}
}
