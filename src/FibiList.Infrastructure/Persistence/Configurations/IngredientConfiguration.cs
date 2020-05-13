using FibiList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FibiList.Infrastructure.Persistence.Configurations
{
	public class IngredientConfiguration : AuditableEntityConfiguration<Ingredient>
	{
		public override void Configure(EntityTypeBuilder<Ingredient> builder)
		{
			builder.Property(i => i.Id).IsRequired();
			builder.Property(i => i.Id).IsRequired();
			builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
			builder.HasOne(i => i.Section);
			base.Configure(builder);
		}
	}
}
