using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using UnityRepositoryPatterns.Models;

namespace UnityRepositoryPatterns.Persistence.Contexts
{
    public class BookManageDbContext : DbContext
    {
        public BookManageDbContext() : base("name=BookManageDbContext") {
            Database.SetInitializer<BookManageDbContext>(null);
        }
        public DbSet<Auther> Auther { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");
            //builder.Entity<Auther>()
            //    .HasKey(cus => cus.AutherID);
            //builder.Entity<Book>()
            //    .HasKey(cus => cus.BookID);
        }
    }
}