using System.Diagnostics.Contracts;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration
{
	internal class TransformerConfig : IEntityTypeConfiguration<Transformer>
	{
		public void Configure(EntityTypeBuilder<Transformer> builder)
		{
			builder
			.ToTable("transformers")
			.HasDiscriminator<int>("TransformerKind")
			.HasValue<CurrentTransformer>(1)
			.HasValue<VoltageTransformer>(2);
		}
	}

	internal class ElectricityMeterConfig : IEntityTypeConfiguration<ElectricityMeter>
	{
		public void Configure(EntityTypeBuilder<ElectricityMeter> builder)
		{
			builder.HasKey(e => e.Id);
		}
	}
}
