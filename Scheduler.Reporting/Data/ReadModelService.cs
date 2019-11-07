﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scheduler.Domain;
using Scheduler.Reporting.Data.Entities;

namespace Scheduler.Reporting.Data
{
	public interface IReadModelService
	{
		Task CreateCalendarAsync(Guid aggregateRootId, string name, string timezone);
		Task AddCalendarOwnerAsync(Guid aggregateRootId, Guid ownerId);
		Task CreateUserAsync(Guid id, string firstname, string lastname, string email, string timeZoneCode);
	}
	public class ReadModelService : IReadModelService
	{
		private readonly SchedulerReadModelDbContext _context;

		public ReadModelService(SchedulerReadModelDbContext context)
		{
			_context = context;
		}

		public async Task AddCalendarOwnerAsync(Guid aggregateRootId, Guid ownerId)
		{
			var calendar = await _context.Calendars.FindAsync(aggregateRootId);
			if (calendar == null)
			{
				throw new ReadModelException($"Cannot find calendar with id {aggregateRootId}");
			}
			//var users = await _context.Users.FindAsync(organisers.Select(o => o.Id).ToList());
			//calendar.Organisers =
		}

		public async Task CreateCalendarAsync(Guid aggregateRootId, string title, string timezone)
		{
			_context.Calendars.Add(new Entities.CalendarEntity
			{
				Id = aggregateRootId,
				Title = title,
				TimeZoneCode = timezone,
				IsArchived = false
			});
			await _context.SaveChangesAsync();
		}

		public async Task CreateUserAsync(Guid id, string firstname, string lastname, string email, string timeZoneCode)
		{
			_context.Users.Add(new UserEntity
			{
				Id = id,
				Firstname = firstname,
				Lastname = lastname,
				Email = email,
				TimeZoneCode = timeZoneCode
			});
			await _context.SaveChangesAsync();
		}
	}
}
