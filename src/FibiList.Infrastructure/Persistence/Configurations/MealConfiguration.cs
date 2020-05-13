using FibiList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FibiList.Infrastructure.Persistence.Configurations
{
	public class MealConfiguration : AuditableEntityConfiguration<Meal>
	{
		public override void Configure(EntityTypeBuilder<Meal> builder)
		{
			builder.Property(m => m.Id).IsRequired();
			builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
			builder.Property(m => m.Description).HasMaxLength(200);
			builder.Property(m => m.ImageUrl).HasMaxLength(500);
			builder.HasOne(m => m.MealPlan);
			base.Configure(builder);
		}
	}
}
