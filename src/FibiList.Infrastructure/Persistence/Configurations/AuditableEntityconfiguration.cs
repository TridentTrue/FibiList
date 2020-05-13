using FibiList.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FibiList.Infrastructure.Persistence.Configurations
{
	public abstract class AuditableEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder.Property(a => a.CreatedBy).IsRequired().HasMaxLength(100);
			builder.Property(a => a.Created).IsRequired();
			builder.Property(a => a.LastModifiedBy).HasMaxLength(100);
			builder.Property(a => a.LastModified);
		}
	}
}
