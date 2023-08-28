using System.Collections.Generic;

namespace Persistance
{
	public class Consumer : EntityBase
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public List<MeasurementPoint> MeasurementPoints { get; set; }
		public List<DeliveryPoint> DeliveryPoints { get; set; }
		public int OwnerOrganizationId { get; set; }
		public virtual ChildOrganization Owner { get; set; }
	}
}
