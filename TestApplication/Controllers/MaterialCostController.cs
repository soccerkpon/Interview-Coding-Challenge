using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.DTOs.OutgoingDTOs;
using TestApplication.Services;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    public class MaterialCostController : Controller
    {
        private readonly IMaterialCostService _materialCostService;

        public MaterialCostController(IMaterialCostService materialCostService)
        {
            _materialCostService = materialCostService;
        }

        [HttpPost]
        [Route("calculate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MaterialCostResponseDto> Calculate([FromBody] MaterialCostRequestDto request)
        {
            try
            {
                return Ok(_materialCostService.CalculateMaterialCost(request));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
