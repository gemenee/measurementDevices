using System.Collections.Generic;

namespace Persistance
{
	public class HeadOrganization : Organization
	{
		public List<ChildOrganization> Children { get; set; }
	}
}
