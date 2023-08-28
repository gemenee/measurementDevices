using System.Collections.Generic;

namespace Persistance
{
	public class ChildOrganization : Organization
	{
		public int HeadOrganizationId { get; set; }
		public HeadOrganization HeadOrganization { get; set; }
		public List<Consumer> Consumers { get; set; }
	}
}
