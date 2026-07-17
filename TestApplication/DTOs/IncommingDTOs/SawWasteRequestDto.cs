using System.Collections.Generic;

namespace TestApplication.DTOs.IncommingDTOs
{
	public class SawWasteRequestDto
	{
		public decimal BoardLength { get; set; }
		public List<decimal> CutLengths { get; set; }
	}
}
