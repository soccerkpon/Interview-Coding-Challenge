using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.DTOs.OutgoingDTOs;
using TestApplication.DTOs.IncommingDTOs;

namespace TestApplication.Services
{
	public interface IInterestCalcService
	{
		IList<InterestSummaryDto> GetCardInterests(IList<PersonDto> people);
	}
}
