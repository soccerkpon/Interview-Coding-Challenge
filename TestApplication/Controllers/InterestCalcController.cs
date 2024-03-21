using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApplication.DTOs.IncommingDTOs;
using TestApplication.DTOs.OutgoingDTOs;
using TestApplication.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    public class InterestCalcController : Controller
    {
        private readonly IInterestCalcService _interestCalcService;

        public InterestCalcController(IInterestCalcService interestCalcService)
        {
            _interestCalcService = interestCalcService;
        }

        [HttpPost]
        [Route("Interest-By-Person")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StatementDto> GetInterestValues([FromBody] PersonDto people)
        {
            try
            {
                return Ok(_interestCalcService.GetInterestOwedOnCustomerCreditCardsByPerson(people));
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("Interest-By-Card/{cardType}/{amountOwed}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StatementDto> GetInterestValues(string cardType, int amountOwed)
        {
            try
            {
                return Ok(_interestCalcService.GetInterestOwedByCard(request));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
