using System.Linq;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.DTOs.OutgoingDTOs;

namespace TestApplication.Services
{
	public class SawWasteService : ISawWasteService
	{
		public SawWasteService()
		{ }

		public SawWasteResponseDto CalculateSawWaste(SawWasteRequestDto request)
		{
			return new SawWasteResponseDto
			{
				WasteLength = request.BoardLength - request.CutLengths.Sum()
			};
		}
	}
}
