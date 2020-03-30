using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.DTOs.IncommingDTOs
{
	public class CreditStatementsDto
	{
		public List<decimal> AmountsOwedVisa { get; set; }
		public List<decimal> AmountsOwedMC { get; set; }
		public List<decimal> AmountsOwedDiscover { get; set; }
	}
}
