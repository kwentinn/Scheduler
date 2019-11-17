using Microsoft.EntityFrameworkCore;
using Scheduler.Domain.Repositories;
using System.Linq;

namespace Scheduler.Reporting.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly SchedulerReadModelDbContext _context;

		public UserRepository(SchedulerReadModelDbContext context)
		{
			_context = context;
		}

		public bool DoesUserExistWithEmail(string email)
		{
			return _context.Users
				.AsNoTracking()
				.Any(u => u.Email == email);
		}
	}
}
