using System;

namespace Persistance
{
	public abstract class Transformer : EntityBase, IVerificationExpirable, IDevice
	{
#nullable enable
		public string Number { get; set; }
		public DateTime NextVerificationDate { get; set; }
		public decimal TransformationRatio { get; set; }
		public int? MeasurementPointId { get; set; }
		public MeasurementPoint? MeasurementPoint { get; set; }

	}
}
