using System;

namespace Persistance.Entities
{
	public class MeasurementPeriod : EntityBase
	{
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public int MeasurementPointId { get; set; }
		public MeasurementPoint MeasurementPoint { get; set; }
		public int AccountingUnitId { get; set; }
		public AccountingUnit AccountingUnit { get; set; }
	}
}
