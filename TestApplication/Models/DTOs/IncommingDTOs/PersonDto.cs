using System.Collections.Generic;

namespace TestApplication.DTOs.IncommingDTOs
{
	public class PersonDto
	{
		public int Id { get; set; }
		public List<CreditStatementsDto> CreditStatements { get; set; }
	}
}
