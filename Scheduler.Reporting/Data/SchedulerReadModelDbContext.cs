using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Scheduler.Reporting.Data.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Scheduler.Reporting.Data
{
	public class SchedulerReadModelDbContext : DbContext
	{
		public SchedulerReadModelDbContext([NotNull] DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Read model 
			//builder.Entity<CalendarEntity>().ToTable("Calendars");

			#region define readmodel
			//builder.Entity<StartedSessionEntity>().ToTable("StartedSessions");
			//builder.Entity<KeptAliveSessionEntity>().ToTable("KeptAliveSessions");
			//builder.Entity<FinishedSessionEntity>().ToTable("FinishedSessions");
			//builder.Entity<ConsolidatedSessionEntity>().ToTable("ConsolidatedSessions");
			//builder.Entity<ConsolidatedSessionByDayEntity>().ToTable("ConsolidatedSessionsByDay");
			////builder.Entity<SessionContainerEntity>().ToTable("SessionContainers");

			//// define columns types
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
				//entity.Property(e => e.UtcKeepAlive)
				//	.HasColumnType("DateTime");
			});

				//	entity.Property(e => e.Device)
				//		.HasMaxLength(128);
				//	entity.Property(e => e.IpAddress)
				//		.HasMaxLength(20);
				//	entity.Property(e => e.SessionId)
				//		.HasMaxLength(50);
				//	entity.Property(e => e.UserAgent)
				//		.HasMaxLength(128);
				//});

				//// define columns types
				//builder.Entity<StartedSessionEntity>(entity =>
				//{
				//	entity.Property(e => e.UtcCreatedAt)
				//		.HasColumnType("DateTime")
				//		.HasDefaultValueSql("GETUTCDATE()");
				//	entity.Property(e => e.UtcStart)
				//		.IsRequired()
				//		.HasColumnType("DateTime");
				//	entity.Property(e => e.Device)
				//		.HasMaxLength(128);
				//	entity.Property(e => e.IpAddress)
				//		.HasMaxLength(20);
				//	entity.Property(e => e.SessionId)
				//		.HasMaxLength(50);
				//	entity.Property(e => e.UserAgent)
				//		.HasMaxLength(128);
				//});

				//// define columns types
				//builder.Entity<KeptAliveSessionEntity>(entity =>
				//{
				//	entity.Property(e => e.UtcCreatedAt)
				//		.HasColumnType("DateTime")
				//		.HasDefaultValueSql("GETUTCDATE()");
				//	entity.Property(e => e.UtcStart)
				//		.IsRequired()
				//		.HasColumnType("DateTime");
				//	entity.Property(e => e.UtcKeepAlive)
				//		.HasColumnType("DateTime");
				//	entity.Property(e => e.Device)
				//		.HasMaxLength(128);
				//	entity.Property(e => e.IpAddress)
				//		.HasMaxLength(20);
				//	entity.Property(e => e.SessionId)
				//		.HasMaxLength(50);
				//	entity.Property(e => e.UserAgent)
				//		.HasMaxLength(128);
				//});

				//// define columns types
				//builder.Entity<FinishedSessionEntity>(entity =>
				//{
				//	entity.Property(e => e.UtcCreatedAt)
				//		.HasColumnType("DateTime")
				//		.HasDefaultValueSql("GETUTCDATE()");
				//	entity.Property(e => e.UtcStart)
				//		.IsRequired()
				//		.HasColumnType("DateTime");
				//	entity.Property(e => e.UtcEnd)
				//		.IsRequired()
				//		.HasColumnType("DateTime");
				//	entity.Property(e => e.Device)
				//		.HasMaxLength(128);
				//	entity.Property(e => e.IpAddress)
				//		.HasMaxLength(20);
				//	entity.Property(e => e.SessionId)
				//		.HasMaxLength(50);
				//	entity.Property(e => e.UserAgent)
				//		.HasMaxLength(128);
				//	entity.Property(e => e.UtcConsolidatedAt)
				//		.HasColumnType("DateTime");

				//	//entity.HasOne(d => d.SessionContainer)
				//	//	.WithMany(p => p.FinishedSessions)
				//	//	.HasForeignKey(d => d.SessionContainerId)
				//	//	.OnDelete(DeleteBehavior.ClientSetNull)
				//	//	.HasConstraintName("FK_FinishedSessions_SessionContainerId");
				//});

				////// define columns types
				////builder.Entity<SessionContainerEntity>(entity =>
				////{
				////	entity.Property(e => e.UtcCreatedAt)
				////		.HasColumnType("DateTime")
				////		.HasDefaultValueSql("GETUTCDATE()");

				////	entity.Property(e => e.UtcStart)
				////		.IsRequired()
				////		.HasColumnType("DateTime");

				////	entity.Property(e => e.UtcEnd)
				////		.IsRequired()
				////		.HasColumnType("DateTime");
				////});

				//// define columns types
				//builder.Entity<ConsolidatedSessionEntity>(entity =>
				//{
				//	entity.Property(e => e.UtcCreatedAt)
				//		.HasColumnType("DateTime")
				//		.HasDefaultValueSql("GETUTCDATE()");

				//	entity.Property(e => e.UtcStart)
				//		.IsRequired()
				//		.HasColumnType("DateTime");

				//	entity.Property(e => e.UtcEnd)
				//		.IsRequired()
				//		.HasColumnType("DateTime");
				//});

				//// define columns types
				//builder.Entity<ConsolidatedSessionByDayEntity>(entity =>
				//{
				//	entity.Property(e => e.UtcCreatedAt)
				//		.HasColumnType("DateTime")
				//		.HasDefaultValueSql("GETUTCDATE()");

				//	entity.Property(e => e.Day)
				//		.IsRequired()
				//		.HasColumnType("Date");
				//});
				#endregion
			}

		public DbSet<CalendarEntity> Calendars { get; set; }

	}
}
