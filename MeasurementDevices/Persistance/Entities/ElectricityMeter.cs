using System;

namespace Persistance
{
	public class ElectricityMeter : EntityBase, IVerificationExpirable, IDevice
	{
#nullable enable
		public string Number { get; set; }
		public int? MeasurementPointId { get; set; }
		public MeasurementPoint? MeasurementPoint { get; set; }
		public MeterType Type { get; set; }
		public DateTime NextVerificationDate { get; set; }
	}
}
