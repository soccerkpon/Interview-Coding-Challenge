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
		#region Case 1 Parameter
		private readonly List<PersonDto> people_1 = new List<PersonDto>
			{
				new PersonDto
				{
					Id = 1,
					CreditStatements = new List<CreditStatementsDto>
					{
						new CreditStatementsDto
						{
							AmountsOwedVisa = new List<decimal> { 100 },
							AmountsOwedMC = new List<decimal> { 100 },
							AmountsOwedDiscover = new List<decimal> { 100 }
						}
					}
				}
			};
		#endregion End Case 1 Parameter

		#region Case 2 Parameter
		private readonly List<PersonDto> people_2 = new List<PersonDto>
			{
				new PersonDto
				{
					Id = 2,
					CreditStatements = new List<CreditStatementsDto>
					{
						new CreditStatementsDto
						{
							AmountsOwedVisa = new List<decimal> { 100 },
							AmountsOwedMC = new List<decimal> { 0 },
							AmountsOwedDiscover = new List<decimal> { 100 }
						},
						new CreditStatementsDto
						{
							AmountsOwedVisa = new List<decimal> { 0 },
							AmountsOwedMC = new List<decimal> { 100 },
							AmountsOwedDiscover = new List<decimal> { 0 }
						}
					}
				}
			};
		#endregion End Case 2 Parameter

		#region Case 3 Parameter
		private readonly List<PersonDto> people_3 = new List<PersonDto>
			{
				new PersonDto
				{
					Id = 3,
					CreditStatements = new List<CreditStatementsDto>
					{
						new CreditStatementsDto
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
					CreditStatements = new List<CreditStatementsDto>
					{
						new CreditStatementsDto
						{
							AmountsOwedVisa = new List<decimal> { 100 },
							AmountsOwedMC = new List<decimal> { 100 },
							AmountsOwedDiscover = new List<decimal> { 0 }
						}
					}
				}
			};
		#endregion End Case 3 Parameter

		public InterestCalcServiceTest()
		{
			_mockIInterestCalcService = new Mock<IInterestCalcService>();
			interestCalcService = new InterestCalcService();
		}

		[Fact]
		public void GetInterestCalcService_Returns_Case1Results()
		{
			// ARRANGE
			#region Expected Data
			IList<InterestSummaryDto> expectedCase1 = new List<InterestSummaryDto>
			{
				new InterestSummaryDto
				{
					PersonId = 1,
					IndividualInterestDue = new List<CardInterestsDto>
					{
						new CardInterestsDto
						{
							VisaInterest = new List<decimal> { 10 },
							MCInterest = new List<decimal> { 5 },
							DiscoverInterest = new List<decimal> { 1 }
						}
					},
					TotalDuePlusInterest = 316,
					TotalInterestDue = 16,
					OriginalStatementValues = new List<CreditStatementsDto>
					{
						new CreditStatementsDto
						{
							AmountsOwedVisa = new List<decimal> { 100 },
							AmountsOwedMC = new List<decimal> { 100 },
							AmountsOwedDiscover = new List<decimal> { 100 }
						}
					}
				}
			};
			#endregion End Expected Data

			// ACT
			var actual = interestCalcService.GetCardInterests(people_1);

			// ASSERT
			actual.Should().BeEquivalentTo(expectedCase1);
		}

		[Fact]
		public void GetInterestCalcService_Returns_Case2Results()
		{
			// ARRANGE
			#region Expected Data
			IList<InterestSummaryDto> expectedCase2 = new List<InterestSummaryDto>
			{
				new InterestSummaryDto
				{
					PersonId = 2,
					IndividualInterestDue = new List<CardInterestsDto>
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
					TotalDuePlusInterest = 316,
					TotalInterestDue = 16,
					OriginalStatementValues = new List<CreditStatementsDto>
					{
						new CreditStatementsDto
						{
							AmountsOwedVisa = new List<decimal> { 100 },
							AmountsOwedMC = new List<decimal> { 0 },
							AmountsOwedDiscover = new List<decimal> { 100 }
						},
						new CreditStatementsDto
						{
							AmountsOwedVisa = new List<decimal> { 0 },
							AmountsOwedMC = new List<decimal> { 100 },
							AmountsOwedDiscover = new List<decimal> { 0 }
						}
					}
				}
			};
			#endregion End Expected Data

			// ACT
			var actual = interestCalcService.GetCardInterests(people_2);

			// ASSERT
			actual.Should().BeEquivalentTo(expectedCase2);
		}

		[Fact]
		public void GetInterestCalcService_Returns_Case3Results()
		{
			// ARRANGE
			#region Expected Data
			IList<InterestSummaryDto> expectedCase3 = new List<InterestSummaryDto>
			{
				new InterestSummaryDto
				{
					PersonId = 3,
					IndividualInterestDue = new List<CardInterestsDto>
					{
						new CardInterestsDto
						{
							VisaInterest = new List<decimal> { 10 },
							MCInterest = new List<decimal> { 5 },
							DiscoverInterest = new List<decimal> { 1 }
						}
					},
					TotalDuePlusInterest = 316,
					TotalInterestDue = 16,
					OriginalStatementValues = new List<CreditStatementsDto>
					{
						new CreditStatementsDto
						{
							AmountsOwedVisa = new List<decimal> { 100 },
							AmountsOwedMC = new List<decimal> { 100 },
							AmountsOwedDiscover = new List<decimal> { 100 }
						}
					}
				},
				new InterestSummaryDto
				{
					PersonId = 4,
					IndividualInterestDue = new List<CardInterestsDto>
					{
						new CardInterestsDto
						{
							VisaInterest = new List<decimal> { 10 },
							MCInterest = new List<decimal> { 5 },
							DiscoverInterest = new List<decimal> { 0 }
						}
					},
					TotalDuePlusInterest = 215,
					TotalInterestDue = 15,
					OriginalStatementValues = new List<CreditStatementsDto>
					{
						new CreditStatementsDto
						{
							AmountsOwedVisa = new List<decimal> { 100 },
							AmountsOwedMC = new List<decimal> { 100 },
							AmountsOwedDiscover = new List<decimal> { 0 }
						}
					}
				}
			};
			#endregion End Expected Data

			// ACT
			var actual = interestCalcService.GetCardInterests(people_3);

			// ASSERT
			actual.Should().BeEquivalentTo(expectedCase3);
		}
	}
}
