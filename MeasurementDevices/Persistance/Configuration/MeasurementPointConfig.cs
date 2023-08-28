using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configuration
{
	internal class MeasurementPointConfig : IEntityTypeConfiguration<MeasurementPoint>
	{
		public void Configure(EntityTypeBuilder<MeasurementPoint> builder)
		{
			builder.HasKey(e => e.Id);

			builder.HasOne(e => e.ElectricityMeter)
				.WithOne(x => x.MeasurementPoint)
				.HasForeignKey<ElectricityMeter>(x => x.MeasurementPointId);

			builder.HasOne(e => e.CurrentTransformer)
				.WithOne(x => x.MeasurementPoint)
				.HasForeignKey<CurrentTransformer>(x => x.MeasurementPointId);

			builder.HasOne(e => e.VoltageTransformer)
				.WithOne(x => x.MeasurementPoint)
				.HasForeignKey<VoltageTransformer>(x => x.MeasurementPointId);
		}
	}
}