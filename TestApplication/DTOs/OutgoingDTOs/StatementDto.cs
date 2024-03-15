using TestApplication.DTOs.IncommingDTOs;
using TestApplication.Models.DTOs.OutgoingDTOs;

namespace TestApplication.DTOs.OutgoingDTOs
{
	public class StatementDto
	{
		public int PersonId { get; set; }
		public RemainingAmountsDto RemainingBalanceByCard { get; set; }
		public RemainingAmountsDto InterestByCard { get; set; }
		public RemainingAmountsDto BalancePlusInterestByCard { get; set; }
		public decimal TotalBalanceAllCards { get; set; }
		public decimal TotalInterestAllCards { get; set; }
		public decimal TotalBalancePlusInterestAllCards { get; set; }
	}
}
