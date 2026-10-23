using Library.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
            public DbSet<Book> Books { get; set; }
            public DbSet<Loan> Loans { get; set; }
            public DbSet<Reader> Readers { get; set; }
        
    }
}
