using FibiList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FibiList.Infrastructure.Persistence.Configurations
{
	public class MealPlanConfiguration : AuditableEntityConfiguration<MealPlan>
	{
		public override void Configure(EntityTypeBuilder<MealPlan> builder)
		{
			builder.Property(mp => mp.Id).IsRequired();
			base.Configure(builder);
		}
	}
}
