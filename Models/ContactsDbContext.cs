using Microsoft.EntityFrameworkCore;

namespace ContactManager.Models
{
	public class ContactsDbContext : DbContext
	{
		public DbSet<Contact> Contacts { get; set; }

		public ContactsDbContext (DbContextOptions<ContactsDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Contact>()
				.Property(c => c.FirstName ).IsRequired().HasMaxLength(200);
			modelBuilder.Entity<Contact>()
				.Property(c => c.LastName ).IsRequired().HasMaxLength(200);

		}

	}
}