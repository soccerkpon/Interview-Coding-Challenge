using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models.DTOs.OutgoingDTOs
{
	public class CardInterestsDto
	{
		public IList<decimal> VisaInterest { get; set; }
		public IList<decimal> MCInterest { get; set; }
		public IList<decimal> DiscoverInterest { get; set; }
	}
}
