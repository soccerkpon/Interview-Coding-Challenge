using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApplication.Controllers
{
    [Route("api/interestcalc")]
    public class InterestCalcController : Controller
    {
        private readonly IInterestCalcService _interestCalcService;

        public InterestCalcController(IInterestCalcService interestCalcService)
        {
            _interestCalcService = interestCalcService;
        }

        [HttpPost("calcInterest", Name = "CalculateInterest")]
        public IActionResult GetInterestValues([FromBody] List<PersonDto> people)
        {
            try
            {
                return Ok(_interestCalcService.GetCardInterests(people));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
