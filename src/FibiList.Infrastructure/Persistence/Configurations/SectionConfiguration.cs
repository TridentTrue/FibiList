using FibiList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FibiList.Infrastructure.Persistence.Configurations
{
	public class SectionConfiguration : IEntityTypeConfiguration<Section>
	{
		public void Configure(EntityTypeBuilder<Section> builder)
		{
			builder.Property(s => s.Id).IsRequired().ValueGeneratedNever();
			builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
		}
	}
}
