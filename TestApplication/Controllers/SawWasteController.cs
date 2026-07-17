using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.DTOs.OutgoingDTOs;
using TestApplication.Services;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    public class SawWasteController : Controller
    {
        private readonly ISawWasteService _sawWasteService;

        public SawWasteController(ISawWasteService sawWasteService)
        {
            _sawWasteService = sawWasteService;
        }

        [HttpPost]
        [Route("calculate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SawWasteResponseDto> Calculate([FromBody] SawWasteRequestDto request)
        {
            try
            {
                return Ok(_sawWasteService.CalculateSawWaste(request));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
