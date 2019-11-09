using Kledex.Domain;
using Scheduler.Domain.Events;
using System;

namespace Scheduler.Domain
{
	public class User : AggregateRoot
	{
		public string Firstname { get; protected set; }
		public string Lastname { get; protected set; }
		public string Email { get; protected set; }
		public TimeZoneInfo TimeZone { get; private set; }

		public User() { }
		public User(Guid id, string firstname, string lastname, string email, string timeZoneCode = "Romance Standard Time")
		{
			// vérifications
			if (id == Guid.Empty) throw new ApplicationException("Id cannot be an empty Guid.");
			if (string.IsNullOrEmpty(firstname)) throw new ApplicationException("Firstname is required.");
			if (string.IsNullOrEmpty(lastname)) throw new ApplicationException("Lastname is required.");
			if (string.IsNullOrEmpty(email)) throw new ApplicationException("Lastname is required.");

			// si le timezone est bidon, ça pètera ici sans envoyer l'event of course
			TimeZoneInfo.FindSystemTimeZoneById(timeZoneCode ?? "Romance Standard Time");

			// tout est ok, on applique l'évent sur l'objet
			AddAndApplyEvent(new UserRegistered(id, firstname, lastname, email, timeZoneCode));
		}

		private void Apply(UserRegistered @event)
		{
			Id = @event.AggregateRootId;
			Firstname = @event.Firstname;
			Lastname = @event.Lastname;
			Email = @event.Email;
			TimeZone = TimeZoneInfo.FindSystemTimeZoneById(@event.TimeZoneCode);
		}
	}
}