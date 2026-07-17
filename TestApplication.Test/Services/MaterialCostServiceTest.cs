using AwesomeAssertions;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.DTOs.OutgoingDTOs;
using TestApplication.Services;
using Xunit;

namespace TestApplication.Test.Services
{
	public class MaterialCostServiceTest
	{
		private readonly MaterialCostService materialCostService;

		public MaterialCostServiceTest()
		{
			materialCostService = new MaterialCostService();
		}

		[Fact]
		public void CalculateMaterialCost_WithoutWaste_ReturnsMaterialCost()
		{
			// ARRANGE
			MaterialCostRequestDto request = new()
			{
				UnitCost = 10,
				Quantity = 5,
				IncludeWaste = false
			};

			MaterialCostResponseDto expected = new()
			{
				MaterialCost = 50,
				WasteAmount = 0,
				TotalCost = 50
			};

			// ACT
			var actual = materialCostService.CalculateMaterialCost(request);

			// ASSERT
			actual.Should().BeEquivalentTo(expected);
		}

		[Fact]
		public void CalculateMaterialCost_WithWaste_ReturnsMaterialCostPlusWaste()
		{
			// ARRANGE
			MaterialCostRequestDto request = new()
			{
				UnitCost = 10,
				Quantity = 5,
				IncludeWaste = true
			};

			MaterialCostResponseDto expected = new()
			{
				MaterialCost = 50,
				WasteAmount = 2.5M,
				TotalCost = 52.5M
			};

			// ACT
			var actual = materialCostService.CalculateMaterialCost(request);

			// ASSERT
			actual.Should().BeEquivalentTo(expected);
		}
	}
}
