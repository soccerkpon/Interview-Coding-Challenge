using System.Collections.Generic;
using System.Linq;
using TestApplication.DTOs.OutgoingDTOs;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.Models.DTOs.OutgoingDTOs;

namespace TestApplication.Services
{
	public class InterestCalcService : IInterestCalcService
	{
		private static readonly decimal VisaInterestRate = 10;
		private static readonly decimal MCInterestRate = 5;
		private static readonly decimal DiscoverInterestRate = 1;
		public InterestCalcService()
		{ }

		public IList<InterestSummaryDto> GetCardInterests(List<PersonDto> people)
		{
			IList<InterestSummaryDto> cardInterestSummaries = new List<InterestSummaryDto>();

			foreach (PersonDto person in people)
			{
				InterestSummaryDto cardInterestSummary = new InterestSummaryDto
				{
					PersonId = person.Id
				};
				List<CardInterestsDto> creditInterestTotal = new List<CardInterestsDto>();
				foreach (CreditStatementsDto creditStatement in person.CreditStatements)
				{
					CardInterestsDto interestForWallet = new CardInterestsDto
					{
						VisaInterest = GetInterest(creditStatement.AmountsOwedVisa, VisaInterestRate),
						MCInterest = GetInterest(creditStatement.AmountsOwedMC, MCInterestRate),
						DiscoverInterest = GetInterest(creditStatement.AmountsOwedDiscover, DiscoverInterestRate)
					};
					creditInterestTotal.Add(interestForWallet);
					cardInterestSummary.TotalDuePlusInterest = GetTotalOwed(interestForWallet, creditStatement, cardInterestSummary.TotalDuePlusInterest);
					cardInterestSummary.TotalInterestDue = interestForWallet.VisaInterest.Sum() + 
														   interestForWallet.MCInterest.Sum() + 
														   interestForWallet.DiscoverInterest.Sum() + 
														   cardInterestSummary.TotalInterestDue;
				}
				cardInterestSummary.OriginalStatementValues = person.CreditStatements;
				cardInterestSummary.IndividualInterestDue = creditInterestTotal;
				cardInterestSummaries.Add(cardInterestSummary);
			}

			return cardInterestSummaries;
		}

		private static IList<decimal> GetInterest(IList<decimal> amountsOwed, decimal interestRate)
		{
			IList<decimal> interest = new List<decimal>();
			foreach (decimal amountOwed in amountsOwed)
			{
				if (amountOwed > 0)
				{
					interest.Add(amountOwed * (interestRate / 100));
				}
				else
				{
					interest.Add(0);
				}
			}
			return interest;
		}

		private static decimal GetTotalOwed(CardInterestsDto interestForStatement, CreditStatementsDto creditStatement, decimal totalDueWithInterest)
		{
			return interestForStatement.VisaInterest.Sum() + interestForStatement.MCInterest.Sum() +
			interestForStatement.DiscoverInterest.Sum() + totalDueWithInterest +
			creditStatement.AmountsOwedDiscover.Sum() + creditStatement.AmountsOwedVisa.Sum() + creditStatement.AmountsOwedMC.Sum();
		}
	}
}
