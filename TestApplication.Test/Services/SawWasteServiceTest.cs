using AwesomeAssertions;
using System.Collections.Generic;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.DTOs.OutgoingDTOs;
using TestApplication.Services;
using Xunit;

namespace TestApplication.Test.Services
{
	public class SawWasteServiceTest
	{
		private readonly SawWasteService sawWasteService;

		public SawWasteServiceTest()
		{
			sawWasteService = new SawWasteService();
		}

		[Fact]
		public void CalculateSawWaste_SingleCut_ReturnsWaste()
		{
			// ARRANGE
			SawWasteRequestDto request = new()
			{
				BoardLength = 100,
				CutLengths = new List<decimal> { 30 }
			};

			SawWasteResponseDto expected = new()
			{
				WasteLength = 70
			};

			// ACT
			var actual = sawWasteService.CalculateSawWaste(request);

			// ASSERT
			actual.Should().BeEquivalentTo(expected);
		}

		[Fact]
		public void CalculateSawWaste_MultipleCuts_ReturnsWaste()
		{
			// ARRANGE
			SawWasteRequestDto request = new()
			{
				BoardLength = 100,
				CutLengths = new List<decimal> { 30, 20, 10 }
			};

			SawWasteResponseDto expected = new()
			{
				WasteLength = 40
			};

			// ACT
			var actual = sawWasteService.CalculateSawWaste(request);

			// ASSERT
			actual.Should().BeEquivalentTo(expected);
		}
	}
}
