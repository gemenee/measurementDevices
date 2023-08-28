using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration
{
	internal class ConsumerConfig : IEntityTypeConfiguration<Consumer>
	{
		public void Configure(EntityTypeBuilder<Consumer> builder)
		{
			builder.HasMany(e => e.MeasurementPoints)
				.WithOne(x => x.Consumer)
				.HasForeignKey(x => x.ConsumerId);
		}
	}
}