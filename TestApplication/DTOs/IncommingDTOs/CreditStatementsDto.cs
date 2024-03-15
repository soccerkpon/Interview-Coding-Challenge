namespace TestApplication.DTOs.IncommingDTOs
{
	public class CreditStatementDto
	{
		public decimal OutstandingVisaBalance { get; set; }
		public decimal OutstandingMasterCardBalance { get; set; }
		public decimal OutstandingDiscoverBalance { get; set; }
	}
}
