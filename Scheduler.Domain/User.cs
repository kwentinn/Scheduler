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
		public User(Guid id, string firstname, string lastname, string email, string timeZoneCode = null)
		{
			// vérifications
			if (id == Guid.Empty) throw new ApplicationException("Id cannot be an empty Guid.");
			if (string.IsNullOrEmpty(firstname)) throw new ApplicationException("Firstname is required.");
			if (string.IsNullOrEmpty(lastname)) throw new ApplicationException("Lastname is required.");
			if (string.IsNullOrEmpty(email)) throw new ApplicationException("Lastname is required.");

			// tout est ok, on applique l'évent sur l'objet
			AddAndApplyEvent(new UserRegistered
			{
				AggregateRootId = id,
				Firstname = firstname,
				Lastname = lastname,
				Email = email,
				TimeZoneCode = timeZoneCode
			});
		}

		private void Apply(UserRegistered @event)
		{
			Id = @event.AggregateRootId;
			Firstname = @event.Firstname;
			Lastname = @event.Lastname;
			Email = @event.Email;
			//TimeZone = new TimeZoneInfo() {  @event.TimeZoneCode;
		}
	}
}