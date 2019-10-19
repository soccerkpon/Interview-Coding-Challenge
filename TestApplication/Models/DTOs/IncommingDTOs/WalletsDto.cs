using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.DTOs.IncommingDTOs
{
	public class WalletsDto
	{
		public IList<decimal> AmountsOwedVisa { get; set; }
		public IList<decimal> AmountsOwedMC { get; set; }
		public IList<decimal> AmountsOwedDiscover { get; set; }
	}
}
