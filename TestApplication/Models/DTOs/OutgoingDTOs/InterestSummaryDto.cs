using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.Models.DTOs.OutgoingDTOs;

namespace TestApplication.DTOs.OutgoingDTOs
{
	public class InterestSummaryDto
	{
		public int PersonId { get; set; }
		public List<CardInterestsDto> IndividualInterestDue { get; set; }
		public decimal TotalDuePlusInterest { get; set; }
		public decimal TotalInterestDue { get; set; }
		public List<CreditStatementsDto> OriginalStatementValues { get; set; }
	}
}
