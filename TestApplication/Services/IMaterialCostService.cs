using TestApplication.DTOs.IncommingDTOs;
using TestApplication.DTOs.OutgoingDTOs;

namespace TestApplication.Services
{
	public interface IMaterialCostService
	{
		MaterialCostResponseDto CalculateMaterialCost(MaterialCostRequestDto request);
	}
}
