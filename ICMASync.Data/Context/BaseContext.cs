using ICMASync.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICMASync.Data.Context
{
    /// <summary>
    /// BaseContext.
    /// </summary>
    /// <seealso cref="T:Microsoft.EntityFrameworkCore.DbContext" />
    public class BaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Aurochses.IdentityServer.Database.Context.BaseContext" /> class.
        /// </summary>
        /// <param name="dbContextOptions">The database context options.</param>
        public BaseContext(DbContextOptions<BaseContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Test> Test { get; set; }
        //public DbSet<EmailList> EmailLists { get; set; }
        //public DbSet<EmailListMember> EmailListMembers { get; set; }
        //public DbSet<Settings> Settings { get; set; }
        //public DbSet<GiftCard> GiftCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EmailListMember>()
            //    .HasOne(b => b.EmailList)
            //    .WithMany(a => a.EmailListMembers)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
