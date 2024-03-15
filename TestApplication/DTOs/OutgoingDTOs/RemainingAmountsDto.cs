namespace TestApplication.Models.DTOs.OutgoingDTOs
{
	public class RemainingAmountsDto
	{
		public decimal VisaAmountOwed { get; set; }
		public decimal MasterCardAmountOwed { get; set; }
		public decimal DiscoverAmountOwed { get; set; }
	}
}
