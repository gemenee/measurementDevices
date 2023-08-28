namespace Persistance
{
	public class DeliveryPoint : EntityBase
	{
		public string Name { get; set; }
		public decimal MaximumPowerOutputInKilowatts { get; set; }
		public int ConsumerId { get; set; }
		public Consumer Consumer { get; set; }
		public int AccountingInitId { get; set; }
		public AccountingUnit AccountingUnit { get; set; }
	}
}