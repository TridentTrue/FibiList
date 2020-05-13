using FibiList.Domain.Entities;
using FibiList.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace FibiList.Infrastructure.Persistence
{
    public class GroceriesContext : DbContext
	{
        public GroceriesContext(DbContextOptions<GroceriesContext> options) : base(options)
        {
        }

        // entities
        public DbSet<MealPlan> MealPlans { get; set; }
		public DbSet<Meal> Meals { get; set; }
		public DbSet<MealIngredient> MealIngredients { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<Unit> Units { get; set; }
		public DbSet<Section> Sections { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            DateTime currentTime = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "placeholder";
                        entry.Entity.Created = currentTime;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "placeholder";
                        entry.Entity.LastModified = currentTime;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
// TODO to be replaced with DI
namespace FibiList.Infrastructure
{
    using FibiList.Infrastructure.Persistence;

    public class GroceriesContextFactory : IDesignTimeDbContextFactory<GroceriesContext>
    {
        public GroceriesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GroceriesContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FibiList;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new GroceriesContext(optionsBuilder.Options);
        }
    }
}