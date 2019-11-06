using Microsoft.EntityFrameworkCore;
using Scheduler.Reporting.Data.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Scheduler.Reporting.Data
{
	public class SchedulerReadModelDbContext : DbContext
	{
		public DbSet<CalendarEntity> Calendars { get; set; }
		public DbSet<CalendarOrganiserEntity> CalendarOrganisers { get; set; }
		public DbSet<UserEntity> Users { get; set; }
		public DbSet<AppointmentEntity> Appointments { get; set; }

		public SchedulerReadModelDbContext([NotNull] DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<CalendarEntity>().ToTable("Calendars");
			builder.Entity<AppointmentEntity>().ToTable("Appointment");
			builder.Entity<UserEntity>().ToTable("User");
			builder.Entity<CalendarOrganiserEntity>().ToTable("CalendarOrganiser");


			builder.Entity<CalendarEntity>(entity =>
			{
				entity.Property(e => e.UtcCreatedAt)
					.HasColumnType("timestamp")
					.HasDefaultValueSql("LOCALTIMESTAMP(3)");

				entity.Property(e => e.Title)
					.IsRequired()
					.HasColumnType("VARCHAR(255)");

				entity.Property(e => e.UtcLastUpdate)
					.HasColumnType("timestamp");

				entity
					.HasMany(d => d.CalendarOrganisers)
					.WithOne(p => p.Calendar)
					.HasForeignKey(d => d.CalendarId)
					.OnDelete(DeleteBehavior.Cascade)
					//.HasConstraintName("FK_Calendar_CalendarOrganisers_CalendarId");
				;

				entity.HasMany(d => d.Appointments)
					.WithOne(p => p.Calendar)
					.HasForeignKey(d => d.CalendarId)
					.OnDelete(DeleteBehavior.Cascade)
					//.HasConstraintName("FK_Calendar_AppointmentId")
				;
			});
			builder.Entity<AppointmentEntity>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.UtcCreatedAt)
					.HasColumnType("timestamp")
					.HasDefaultValueSql("LOCALTIMESTAMP(3)");

				entity.Property(e => e.UtcStart)
					.IsRequired()
					.HasColumnType("timestamp");

				entity.Property(e => e.UtcEnd)
					.IsRequired()
					.HasColumnType("timestamp");

				entity.Property(e => e.Title)
					.HasMaxLength(128);

				entity.HasOne(d => d.Calendar)
					.WithMany(p => p.Appointments)
					.HasForeignKey(d => d.CalendarId)
					.OnDelete(DeleteBehavior.Cascade)
					//.HasConstraintName("FK_Appointment__Id");
				;
			});
			builder.Entity<UserEntity>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.UtcCreatedAt)
					.HasColumnType("timestamp")
					.HasDefaultValueSql("LOCALTIMESTAMP(3)");

				entity.Property(e => e.Firstname)
					.IsRequired()
					.HasMaxLength(128);

				entity.Property(e => e.Lastname)
					.IsRequired()
					.HasMaxLength(128);

				//entity.HasOne(d => d.Calendar)
				//	.WithMany(p => p.CalendarOrganisers)

				//;
			});
			builder.Entity<CalendarOrganiserEntity>(entity =>
			{
				entity.HasKey(e => new { e.CalendarId, e.UserId });
				entity.HasOne(d => d.Calendar)
					.WithMany(p => p.CalendarOrganisers)
					.HasForeignKey(d => d.CalendarId)
					;
			});
		}
	}
}
