using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration
{
	internal class HeadOrganizationConfig : IEntityTypeConfiguration<HeadOrganization>
	{
		public void Configure(EntityTypeBuilder<HeadOrganization> builder)
		{
			builder.HasKey(e => e.Id);

			builder.HasIndex(e => e.Name).IsUnique();
		}
	}
}