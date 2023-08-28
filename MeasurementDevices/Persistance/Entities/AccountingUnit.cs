using System.Collections.Generic;
using Persistance.Entities;

namespace Persistance
{
	public class AccountingUnit : EntityBase
	{
		public List<MeasurementPeriod> MeasurementPeriods { get; set; }
	}
}