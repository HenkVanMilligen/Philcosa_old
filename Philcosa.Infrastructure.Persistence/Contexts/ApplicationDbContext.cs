using Microsoft.EntityFrameworkCore;
using Philcosa.Application.Interfaces;
using Philcosa.Domain.Common;
using Philcosa.Domain.Entities;
using Philcosa.Infrastructure.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Philcosa.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=127.0.0.1; port=5432; user id=philcosa-user; password=philcosa_P@ssword14; database=PhilcosaDb; pooling=true");
        }
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }
        public DbSet<Postcard> Postcards { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<PostcardTheme> PostcardThemes { get; set; }
        public DbSet<PostcardType> PostcardTypes { get; set; }
        public DbSet<PostcardValue> PostcardValues { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<IssuedByEntity> IssuedByEntities { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }

            Debugger.Launch();
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new PostcardTypeConfiguration());
            builder.ApplyConfiguration(new PostcardValueConfiguration());
            builder.ApplyConfiguration(new ThemeConfiguration());
            builder.ApplyConfiguration(new IssuedByEntityConfiguration());
            builder.ApplyConfiguration(new PostcardThemeConfiguration());
            //builder.ApplyConfiguration(new PostcardConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
