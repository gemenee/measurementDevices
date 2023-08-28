using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistance.Entities;

namespace Persistance
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public DbSet<AccountingUnit> AccountingUnits { get; set; }
		public DbSet<ChildOrganization> ChildOrganizations { get; set; }
		public DbSet<Consumer> Consumers { get; set; }
		public DbSet<CurrentTransformer> CurrentTransformers { get; set; }
		public DbSet<DeliveryPoint> DeliveryPoints { get; set; }
		public DbSet<ElectricityMeter> ElectricityMeters { get; set; }
		public DbSet<MeasurementPeriod> MeasurementPeriods { get; set; }
		public DbSet<MeasurementPoint> MeasurementPoints { get; set; }
		public DbSet<HeadOrganization> HeadOrganizations { get; set; }
		public DbSet<VoltageTransformer> VoltageTransformers { get; set; }
	}

	public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseSqlite("Data Source=TNE.db");

			return new AppDbContext(optionsBuilder.Options);
		}
	}

}
