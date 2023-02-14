using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace interview_dotnet.Models
{
	public class ContactsContext : DbContext
	{
        public ContactsContext(DbContextOptions<ContactsContext> options)
        : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}

