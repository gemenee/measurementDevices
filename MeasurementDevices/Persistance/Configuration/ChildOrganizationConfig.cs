using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration
{
	internal class ChildOrganizationConfig : IEntityTypeConfiguration<ChildOrganization>
	{
		public void Configure(EntityTypeBuilder<ChildOrganization> builder)
		{
			builder.HasKey(e => e.Id);

			builder.HasIndex(e => e.Name).IsUnique();

			builder
				.HasOne(e => e.HeadOrganization)
				.WithMany(x => x.Children)
				.HasForeignKey(x => x.HeadOrganizationId);

			builder
				.HasMany(x => x.Consumers)
				.WithOne(x => x.Owner)
				.HasForeignKey(x => x.OwnerOrganizationId);
		}
	}
}