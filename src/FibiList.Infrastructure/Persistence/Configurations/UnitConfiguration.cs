using FibiList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FibiList.Infrastructure.Persistence.Configurations
{
	public class UnitConfiguration : IEntityTypeConfiguration<Unit>
	{
		public void Configure(EntityTypeBuilder<Unit> builder)
		{
			builder.Property(u => u.Id).IsRequired();
			builder.Property(u => u.SingularDescriptor).IsRequired().HasMaxLength(20);
			builder.Property(u => u.PluralDescriptor).IsRequired().HasMaxLength(20);
		}
	}
}
