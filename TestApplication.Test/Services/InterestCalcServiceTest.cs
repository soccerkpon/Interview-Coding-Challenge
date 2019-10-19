using System;
using System.Collections.Generic;
using FluentAssertions;
using System.Text;
using Xunit;
using Moq;
using TestApplication.Services;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.DTOs.OutgoingDTOs;
using TestApplication.Models.DTOs.OutgoingDTOs;

namespace TestApplication.Test.Services
{
	public class InterestCalcServiceTest
	{
		// Global contants, fields, mocks
		readonly Mock<IInterestCalcService> _mockIInterestCalcService;
		private readonly InterestCalcService interestCalcService;

		// Data Factory

		public InterestCalcServiceTest()
		{
			_mockIInterestCalcService = new Mock<IInterestCalcService>();
			interestCalcService = new InterestCalcService();
		}

		[Fact]
		public void GetInterestCalcService_Returns_Case1Results()
		{
			// ARRANGE
			#region Case 1 Parameter
			IList<PersonDto> people = new List<PersonDto>
			{
				new PersonDto
				{
					Id = 1,
					Wallets = new List<WalletsDto>
					{
						new WalletsDto
						{
							AmountsOwedVisa = new List<decimal> { 100 },
							AmountsOwedMC = new List<decimal> { 100 },
							AmountsOwedDiscover = new List<decimal> { 100 }
						}
					}
				}
			};
			#endregion End Case 1 Parameter

			#region Expected Data
			IList<InterestSummaryDto> expectedCase1 = new List<InterestSummaryDto>
			{
				new InterestSummaryDto
				{
					PersonId = 1,
					Wallets = new List<CardInterestsDto>
					{
						new CardInterestsDto
						{
							VisaInterest = new List<decimal> { 10 },
							MCInterest = new List<decimal> { 5 },
							DiscoverInterest = new List<decimal> { 1 }
						}
					},
					TotalDueWithInterest = 316,
					TotalInterestDue = 16
				}
			};
			#endregion End Expected Data

			// ACT
			var actual = interestCalcService.GetCardInterests(people);

			// ASSERT
			actual.Should().BeEquivalentTo(expectedCase1);
		}

		[Fact]
		public void GetInterestCalcService_Returns_Case2Results()
		{
			// ARRANGE
			#region Case 2 Parameter
			IList<PersonDto> people = new List<PersonDto>
			{
				new PersonDto
				{
					Id = 2,
					Wallets = new List<WalletsDto>
					{
						new WalletsDto
						{
							AmountsOwedVisa = new List<decimal> { 100 },
							AmountsOwedMC = new List<decimal> { 0 },
							AmountsOwedDiscover = new List<decimal> { 100 }
						},
						new WalletsDto
						{
							AmountsOwedVisa = new List<decimal> { 0 },
							AmountsOwedMC = new List<decimal> { 100 },
							AmountsOwedDiscover = new List<decimal> { 0 }
						}
					}
				}
			};
			#endregion End Case 2 Parameter

			#region Expected Data
			IList<InterestSummaryDto> expectedCase2 = new List<InterestSummaryDto>
			{
				new InterestSummaryDto
				{
					PersonId = 2,
					Wallets = new List<CardInterestsDto>
					{
						new CardInterestsDto
						{
							VisaInterest = new List<decimal> { 10 },
							MCInterest = new List<decimal> { 0 },
							DiscoverInterest = new List<decimal> { 1 }
						},
						new CardInterestsDto
						{
							VisaInterest = new List<decimal> { 0 },
							MCInterest = new List<decimal> { 5 },
							DiscoverInterest = new List<decimal> { 0 }
						}
					},
					TotalDueWithInterest = 316,
					TotalInterestDue = 16
				}
			};
			#endregion End Expected Data

			// ACT
			var actual = interestCalcService.GetCardInterests(people);

			// ASSERT
			actual.Should().BeEquivalentTo(expectedCase2);
		}

		[Fact]
		public void GetInterestCalcService_Returns_Case3Results()
		{
			// ARRANGE
			#region Case 3 Parameter
			IList<PersonDto> people = new List<PersonDto>
			{
				new PersonDto
				{
					Id = 3,
					Wallets = new List<WalletsDto>
					{
						new WalletsDto
						{
							AmountsOwedVisa = new List<decimal> { 100 },
							AmountsOwedMC = new List<decimal> { 100 },
							AmountsOwedDiscover = new List<decimal> { 100 }
						}
					}
				},
				new PersonDto
				{
					Id = 4,
					Wallets = new List<WalletsDto>
					{
						new WalletsDto
						{
							AmountsOwedVisa = new List<decimal> { 100 },
							AmountsOwedMC = new List<decimal> { 100 },
							AmountsOwedDiscover = new List<decimal> { 0 }
						}
					}
				}
			};
			#endregion End Case 3 Parameter

			#region Expected Data
			IList<InterestSummaryDto> expectedCase3 = new List<InterestSummaryDto>
			{
				new InterestSummaryDto
				{
					PersonId = 3,
					Wallets = new List<CardInterestsDto>
					{
						new CardInterestsDto
						{
							VisaInterest = new List<decimal> { 10 },
							MCInterest = new List<decimal> { 5 },
							DiscoverInterest = new List<decimal> { 1 }
						}
					},
					TotalDueWithInterest = 316,
					TotalInterestDue = 16
				},
				new InterestSummaryDto
				{
					PersonId = 4,
					Wallets = new List<CardInterestsDto>
					{
						new CardInterestsDto
						{
							VisaInterest = new List<decimal> { 10 },
							MCInterest = new List<decimal> { 5 },
							DiscoverInterest = new List<decimal> { 0 }
						}
					},
					TotalDueWithInterest = 215,
					TotalInterestDue = 15
				}
			};
			#endregion End Expected Data

			// ACT
			var actual = interestCalcService.GetCardInterests(people);

			// ASSERT
			actual.Should().BeEquivalentTo(expectedCase3);
		}
	}
}
