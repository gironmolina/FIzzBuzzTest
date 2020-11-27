using System;
using System.Threading.Tasks;
using FizzBuzzTest.Application.Dtos;
using FizzBuzzTest.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FizzBuzzTest.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FizzBuzzController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ILogger<FizzBuzzController> _logger;
		private readonly IFizzBuzzAppService _fizzBuzzAppService;

		public FizzBuzzController(
			IConfiguration configuration,
			ILogger<FizzBuzzController> logger,
			IFizzBuzzAppService fizzBuzzAppService)
		{
			_configuration = configuration;
			_logger = logger;
			_fizzBuzzAppService = fizzBuzzAppService;
		}

		/// <summary>
		/// Gets FizzBuzz from "startNumber" until "limitNumber" (set by config, default value 30).
		/// </summary>
		/// <remarks>
		/// Sample request:
		///
		///	Get -> "startName": 21
		///			to limitNumber (set by config: "30")
		///	
		///	Expected Result	->
		///	{
		///		"fizzBuzzResults": [
		///		"Fizz",
		///		"22",
		///		"23",
		///		"Fizz",
		///		"Buzz",
		///		"26",
		///		"Fizz",
		///		"28",
		///		"29",
		///		"FizzBuzz"
		///		]
		///	}
		/// </remarks>
		/// <param name="startNumber"> Start number to calculate FizzBuzz.</param>
		/// <returns>A FizzBuzzDto based on the start number until limit number (set by config, default value 30)</returns>
		/// <response code="200">Returns the FizzBuzz</response>
		/// <response code="400">startNumber not Valid</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpGet]
		public async Task<ActionResult<FizzBuzzDto>> GetFizzBuzz(int startNumber)
		{
			try
			{
				var limitNumber = Convert.ToInt32(_configuration["LimitNumber"]);
				if (startNumber > limitNumber)
				{
					return BadRequest($"The startNumber can't be greater than limitNumber: {limitNumber}");
				}
				_logger.LogInformation($"FizzBuzz Operation with startNumber: {startNumber} and limitNumber: {limitNumber} Started");
				var fizzBuzzResult = await _fizzBuzzAppService.GetFizzBuzzResult(startNumber, limitNumber);
				_logger.LogInformation("FizzBuzz Operation Completed");
				return Ok(fizzBuzzResult);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception.ToString());
				return Problem("A problem has happened...");
			}
		}
	}
}
