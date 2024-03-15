using FluentAssertions;
using System.Collections.Generic;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.DTOs.OutgoingDTOs;
using TestApplication.Services;
using Xunit;

namespace TestApplication.Test.Services
{
	public class InterestCalcServiceTest
	{
		// Global contants, fields, mocks
		private readonly InterestCalcService interestCalcService;

        #region Test Data
        // Data Factory
        #region Case 1 Parameter
        private readonly PersonDto person_1 = new()
        {
			Id = 1,
			CreditStatement = new()
			{
                OutstandingVisaBalance = 100,
                OutstandingMasterCardBalance = 100,
                OutstandingDiscoverBalance = 100
			}
		};
		#endregion End Case 1 Parameter

		#region Case 2 Parameter
		private readonly PersonDto person_2 = new()
		{ 
			Id = 2,
			CreditStatement = new()
			{
				OutstandingVisaBalance = 100,
				OutstandingMasterCardBalance = 0,
				OutstandingDiscoverBalance = 100
			}
		};
		#endregion End Case 2 Parameter

		#region Case 3 Parameter
		private readonly PersonDto person_3 = new()
		{
			Id = 3,
			CreditStatement = new()
			{
                OutstandingVisaBalance = 1000,
                OutstandingMasterCardBalance = 87,
                OutstandingDiscoverBalance = 10
			}
		};
        #endregion End Case 3 Parameter

        #region Case 4 Parameter
        private readonly PersonDto person_4 = new()
        {
            Id = 4,
            CreditStatement = new()
            {
                OutstandingVisaBalance = 0,
                OutstandingMasterCardBalance = -13,
                OutstandingDiscoverBalance = 6753
            }
        };
        #endregion End Case 4 Parameter
        #endregion Test Data

        public InterestCalcServiceTest()
		{
			interestCalcService = new InterestCalcService();
		}

		[Fact]
		public void GetInterestCalcService_Returns_Case1Results()
		{
			// ARRANGE
			#region Expected Data
			StatementDto expectedStatementDto = new()
			{
				PersonId = 1,
				RemainingBalanceByCard = new()
				{
					VisaAmountOwed = 100,
					MasterCardAmountOwed = 100,
					DiscoverAmountOwed = 100
				},
				InterestByCard = new()
				{
                    VisaAmountOwed = 10,
                    MasterCardAmountOwed = 5,
                    DiscoverAmountOwed = 1
                },
				BalancePlusInterestByCard = new()
				{
					VisaAmountOwed = 110,
					MasterCardAmountOwed = 105,
					DiscoverAmountOwed = 101
				},
				TotalBalanceAllCards = 300,
				TotalInterestAllCards = 16,
				TotalBalancePlusInterestAllCards = 316
			};
			#endregion End Expected Data

			// ACT
			var actual = interestCalcService.GetInterestOwedOnCustomerCreditCardsByPerson(person_1);

			// ASSERT
			actual.Should().BeEquivalentTo(expectedStatementDto);
		}

		[Fact]
		public void GetInterestCalcService_Returns_Case2Results()
		{
            // ARRANGE
            #region Expected Data
            StatementDto expectedStatementDto = new()
            {
                PersonId = 2,
                RemainingBalanceByCard = new()
                {
                    VisaAmountOwed = 100,
                    MasterCardAmountOwed = 0,
                    DiscoverAmountOwed = 100
                },
                InterestByCard = new()
                {
                    VisaAmountOwed = 10,
                    MasterCardAmountOwed = 0,
                    DiscoverAmountOwed = 1
                },
                BalancePlusInterestByCard = new()
                {
                    VisaAmountOwed = 110,
                    MasterCardAmountOwed = 0,
                    DiscoverAmountOwed = 101
                },
                TotalBalanceAllCards = 200,
                TotalInterestAllCards = 11,
                TotalBalancePlusInterestAllCards = 211
            };
            #endregion End Expected Data

            // ACT
            var actual = interestCalcService.GetInterestOwedOnCustomerCreditCardsByPerson(person_2);

			// ASSERT
			actual.Should().BeEquivalentTo(expectedStatementDto);
		}

		[Fact]
		public void GetInterestCalcService_Returns_Case3Results()
		{
            // ARRANGE
            #region Expected Data
            StatementDto expectedStatementDto = new()
            {
                PersonId = 3,
                RemainingBalanceByCard = new()
                {
                    VisaAmountOwed = 1000,
                    MasterCardAmountOwed = 87,
                    DiscoverAmountOwed = 10
                },
                InterestByCard = new()
                {
                    VisaAmountOwed = 100,
                    MasterCardAmountOwed = 4.35M,
                    DiscoverAmountOwed = 0.10M
                },
                BalancePlusInterestByCard = new()
                {
                    VisaAmountOwed = 1100,
                    MasterCardAmountOwed = 91.35M,
                    DiscoverAmountOwed = 10.1M
                },
                TotalBalanceAllCards = 1097,
                TotalInterestAllCards = 104.45M,
                TotalBalancePlusInterestAllCards = 1201.45M
            };
            #endregion End Expected Data

            // ACT
            var actual = interestCalcService.GetInterestOwedOnCustomerCreditCardsByPerson(person_3);

			// ASSERT
			actual.Should().BeEquivalentTo(expectedStatementDto);
		}

        [Fact]
        public void GetInterestCalcService_Returns_Case4Results()
        {
            // ARRANGE
            #region Expected Data
            StatementDto expectedStatementDto = new()
            {
                PersonId = 4,
                RemainingBalanceByCard = new()
                {
                    VisaAmountOwed = 0,
                    MasterCardAmountOwed = -13,
                    DiscoverAmountOwed = 6753
                },
                InterestByCard = new()
                {
                    VisaAmountOwed = 0,
                    MasterCardAmountOwed = 0,
                    DiscoverAmountOwed = 67.53M
                },
                BalancePlusInterestByCard = new()
                {
                    VisaAmountOwed = 0,
                    MasterCardAmountOwed = -13M,
                    DiscoverAmountOwed = 6820.53M
                },
                TotalBalanceAllCards = 6740M,
                TotalInterestAllCards = 67.53M,
                TotalBalancePlusInterestAllCards = 6807.53M
            };
            #endregion End Expected Data

            // ACT
            var actual = interestCalcService.GetInterestOwedOnCustomerCreditCardsByPerson(person_4);

            // ASSERT
            actual.Should().BeEquivalentTo(expectedStatementDto);
        }
    }
}
