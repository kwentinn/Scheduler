using System;
using System.Collections.Generic;

namespace Scheduler.Domain
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; protected set; }
		public string LastName { get; protected set; }
		public string Email { get; protected set; }
		public TimeZoneInfo DefaultTimeZone { get; private set; }
	}

	public class Organiser : User
	{
		public List<Calendar> Calendars { get; private set; }
	}

	public class Participant : User
	{
		public List<Appointment> Appointments { get; private set; }
	}
}