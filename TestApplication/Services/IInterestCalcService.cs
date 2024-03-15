using System.Collections.Generic;
using TestApplication.DTOs.OutgoingDTOs;
using TestApplication.DTOs.IncommingDTOs;

namespace TestApplication.Services
{
	public interface IInterestCalcService
	{
		StatementDto GetInterestOwedOnCustomerCreditCardsByPerson(PersonDto people);
	}
}
