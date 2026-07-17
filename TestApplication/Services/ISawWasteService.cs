using TestApplication.DTOs.IncommingDTOs;
using TestApplication.DTOs.OutgoingDTOs;

namespace TestApplication.Services
{
	public interface ISawWasteService
	{
		SawWasteResponseDto CalculateSawWaste(SawWasteRequestDto request);
	}
}
