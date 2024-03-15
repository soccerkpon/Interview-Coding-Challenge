using System;
using System.Collections.Generic;
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
        public IActionResult GetInterestValues([FromBody] PersonDto people)
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

        // Basic
        // Write an HTTP GET endpoint to return the interest for a single card passing amount owed and using the correct interest rate defined in the service.

        // Intermediate
        // Modify the existing HTTP endpoint or write a new one that takes a payment amount by card to be subtracted from the statement balance before calculating the interest.

        // Advanced
        // Incorporate dates and fees into the service that checks if customer's last payment was over 30 days ago and adds a $10 fee to the interest owed.
    }
}
