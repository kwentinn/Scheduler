﻿using System;

namespace Scheduler.Reporting.Data.Entities
{
	public class UserEntity
	{
		public Guid	Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
	}
}