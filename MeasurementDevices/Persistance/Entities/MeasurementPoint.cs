using System.Collections.Generic;
using Persistance.Entities;

namespace Persistance
{
	public class MeasurementPoint : EntityBase
	{
		public string Name { get; set; }
		public int ConsumerId { get; set; }
		public Consumer Consumer { get; set; }
		public ElectricityMeter? ElectricityMeter { get; set; }
		public CurrentTransformer? CurrentTransformer { get; set; }
		public VoltageTransformer? VoltageTransformer { get; set; }
		public List<MeasurementPeriod> MeasurementPeriods { get; set;}
	}
}
