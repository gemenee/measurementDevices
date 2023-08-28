using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;

namespace Persistance.Configuration
{
	internal class MeasurementPeriodConfig : IEntityTypeConfiguration<MeasurementPeriod>
	{
		public void Configure(EntityTypeBuilder<MeasurementPeriod> builder)
		{
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(e => e.MeasurementPoint).IsRequired();
			builder.Property(e => e.AccountingUnit).IsRequired();

			builder.HasKey(e => e.Id);
			builder.HasIndex(e => new { e.MeasurementPointId, e.AccountingUnitId }).IsUnique();

			builder.HasOne(e => e.MeasurementPoint).WithMany(e => e.MeasurementPeriods).HasForeignKey(e => e.MeasurementPointId);
			builder.HasOne(e => e.AccountingUnit).WithMany(e => e.MeasurementPeriods).HasForeignKey(e => e.AccountingUnitId);
		}
	}
}