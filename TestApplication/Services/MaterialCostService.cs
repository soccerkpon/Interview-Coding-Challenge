using TestApplication.DTOs.IncommingDTOs;
using TestApplication.DTOs.OutgoingDTOs;

namespace TestApplication.Services
{
	public class MaterialCostService : IMaterialCostService
	{
		private static readonly decimal WasteRate = 0.05M;

		public MaterialCostService()
		{ }

		public MaterialCostResponseDto CalculateMaterialCost(MaterialCostRequestDto request)
		{
			decimal materialCost = request.UnitCost * request.Quantity;
			decimal wasteAmount = request.IncludeWaste ? materialCost * WasteRate : 0;

			return new MaterialCostResponseDto
			{
				MaterialCost = materialCost,
				WasteAmount = wasteAmount,
				TotalCost = materialCost + wasteAmount
			};
		}
	}
}
