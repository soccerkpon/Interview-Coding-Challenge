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

		public IList<InterestSummaryDto> GetCardInterests(IList<PersonDto> people)
		{
			IList<InterestSummaryDto> cardInterestSummaries = new List<InterestSummaryDto>();

			foreach (PersonDto person in people)
			{
				InterestSummaryDto cardInterestSummary = new InterestSummaryDto
				{
					PersonId = person.Id
				};
				IList<CardInterestsDto> walletInterestTotal = new List<CardInterestsDto>();
				foreach (WalletsDto wallet in person.Wallets)
				{
					CardInterestsDto interestForWallet = new CardInterestsDto
					{
						VisaInterest = GetInterest(wallet.AmountsOwedVisa, VisaInterestRate),
						MCInterest = GetInterest(wallet.AmountsOwedMC, MCInterestRate),
						DiscoverInterest = GetInterest(wallet.AmountsOwedDiscover, DiscoverInterestRate)
					};
					walletInterestTotal.Add(interestForWallet);
					cardInterestSummary.TotalDueWithInterest = GetTotalOwed(interestForWallet, wallet, cardInterestSummary.TotalDueWithInterest);
					cardInterestSummary.TotalInterestDue = interestForWallet.VisaInterest.Sum() + interestForWallet.MCInterest.Sum() + interestForWallet.DiscoverInterest.Sum() + cardInterestSummary.TotalInterestDue;
				}
				cardInterestSummary.Wallets = walletInterestTotal;
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

		private static decimal GetTotalOwed(CardInterestsDto interestForWallet, WalletsDto wallet, decimal totalDueWithInterest)
		{
			return interestForWallet.VisaInterest.Sum() + interestForWallet.MCInterest.Sum() +
			interestForWallet.DiscoverInterest.Sum() + totalDueWithInterest +
			wallet.AmountsOwedDiscover.Sum() + wallet.AmountsOwedVisa.Sum() + wallet.AmountsOwedMC.Sum();
		}
	}
}
