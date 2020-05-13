using FibiList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FibiList.Infrastructure.Persistence.Configurations
{
	public class MealIngredientConfiguration : AuditableEntityConfiguration<MealIngredient>
	{
		public override void Configure(EntityTypeBuilder<MealIngredient> builder)
		{
			builder.HasKey(mi => new { mi.MealId, mi.IngredientId });
			builder.HasOne(mi => mi.Meal);
			builder.HasOne(mi => mi.Ingredient);
			builder.Property(mi => mi.Quantity).HasColumnType("decimal(5,3)").IsRequired();
			builder.Property(mi => mi.Notes).HasMaxLength(100);
			base.Configure(builder);
		}
	}
}
