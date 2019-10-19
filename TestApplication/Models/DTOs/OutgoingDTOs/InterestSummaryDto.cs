using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Models.DTOs.OutgoingDTOs;

namespace TestApplication.DTOs.OutgoingDTOs
{
	public class InterestSummaryDto
	{
		public int PersonId { get; set; }
		public IList<CardInterestsDto> Wallets { get; set; }
		public decimal TotalDueWithInterest { get; set; }
		public decimal TotalInterestDue { get; set; }
	}
}
