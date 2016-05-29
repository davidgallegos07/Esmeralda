using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Esmeralda.Models
{
    public class EsmeraldaContext : IdentityDbContext<ApplicationUser>
    {
        public EsmeraldaContext()
        {
          Database.Migrate();
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<CreditCard> CretditCards { get; set; }
        public DbSet<UserProfileCreditCard> UserProfileCreditCards { get; set; }
        public DbSet<AdminProfile> AdminProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Meal> Meals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:DefaultConnection:ConnectionString"];
            optionsBuilder.UseSqlServer(connString);
        
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Database.setInitializer(new
            //    MigrateDatabaseToLastestVersion<EsmeraldaContext>, Configuration());            
            base.OnModelCreating(builder);

            builder.Entity<UserProfileCreditCard>().HasKey(uc => new { uc.UserProfileId, uc.CreditCardId });

            builder.Entity<UserProfileCreditCard>()
                .HasOne(uc => uc.UserProfile)
                .WithMany(uc => uc.UserProfileCreditCards)
                .HasForeignKey(uc => uc.UserProfileId);

            builder.Entity<UserProfileCreditCard>()
                .HasOne(cc => cc.CreditCard)
                .WithMany(cc => cc.UserProfileCreditCards)
                .HasForeignKey(cc => cc.CreditCardId);
        }
       
    }
}
