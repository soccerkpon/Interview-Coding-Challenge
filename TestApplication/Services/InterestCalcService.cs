using System.Collections.Generic;
using System.Linq;
using TestApplication.DTOs.OutgoingDTOs;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.Models.DTOs.OutgoingDTOs;
using System;

namespace TestApplication.Services
{
	public class InterestCalcService : IInterestCalcService
	{
		private static readonly decimal VisaInterestRate = 10;
		private static readonly decimal MasterCardInterestRate = 5;
		private static readonly decimal DiscoverInterestRate = 1;
		public InterestCalcService()
		{ }

		public StatementDto GetInterestOwedOnCustomerCreditCardsByPerson(PersonDto person)
		{
			StatementDto statementDto = new()
			{
                		PersonId = person.Id,
				RemainingBalanceByCard = new RemainingAmountsDto() 
				{
					VisaAmountOwed = person.CreditStatement.OutstandingVisaBalance,
		                	MasterCardAmountOwed = person.CreditStatement.OutstandingMasterCardBalance,
		                	DiscoverAmountOwed = person.CreditStatement.OutstandingDiscoverBalance
				}
            		};

			RemainingAmountsDto interestsByCard = new()
			{
				VisaAmountOwed = GetInterest(person.CreditStatement.OutstandingVisaBalance, VisaInterestRate),
                		MasterCardAmountOwed = GetInterest(person.CreditStatement.OutstandingMasterCardBalance, MasterCardInterestRate),
                		DiscoverAmountOwed = GetInterest(person.CreditStatement.OutstandingDiscoverBalance, DiscoverInterestRate)
			};
			statementDto.InterestByCard = interestsByCard;
			statementDto.BalancePlusInterestByCard = GetBalancePlusInterestByCard(interestsByCard, person.CreditStatement);
			statementDto.TotalBalanceAllCards = GetTotalsForAllCards(statementDto.RemainingBalanceByCard);
			statementDto.TotalInterestAllCards = GetTotalsForAllCards(statementDto.InterestByCard);
			statementDto.TotalBalancePlusInterestAllCards = statementDto.TotalBalanceAllCards + statementDto.TotalInterestAllCards;

			return statementDto;
		}

	        private static decimal GetTotalsForAllCards(RemainingAmountsDto remainingAmounts)
	        {
	            return remainingAmounts.VisaAmountOwed + remainingAmounts.MasterCardAmountOwed + remainingAmounts.DiscoverAmountOwed;
	        }
	
	        private static RemainingAmountsDto GetBalancePlusInterestByCard(RemainingAmountsDto interestsByCard, CreditStatementDto creditStatement)
	        {
	            return new RemainingAmountsDto
				{
	                VisaAmountOwed = interestsByCard.VisaAmountOwed + creditStatement.OutstandingVisaBalance,
	                MasterCardAmountOwed = interestsByCard.MasterCardAmountOwed + creditStatement.OutstandingMasterCardBalance,
	                DiscoverAmountOwed = interestsByCard.DiscoverAmountOwed + creditStatement.OutstandingDiscoverBalance
	            };
	        }
	
	        private static decimal GetInterest(decimal amountOwed, decimal interestRate)
		{
			return amountOwed > 0 ? amountOwed * (interestRate / 100) : 0;
		}
	}
}
