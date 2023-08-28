using System;
using System.Threading.Tasks;
using Application.Contracts.Dtos;
using Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApi.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class DevicesController : ControllerBase
	{
		private readonly IVerificationService _verificationService;

		public DevicesController(IVerificationService verificationService)
		{
			_verificationService = verificationService;
		}
		/// <summary>
		/// Устройства с истекшим сроком поверки
		/// </summary>
		/// <param name="deviceCategory"></param>
		/// <param name="consumerId"></param>
		/// <returns>ExpiredDeviceDto</returns>
		[HttpGet("expired/{deviceCategory}/{consumerId:int?}")]
		[ProducesResponseType(typeof(ExpiredDeviceDto), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll([FromRoute]string deviceCategory, int? consumerId = null)
		{
			try
			{
				return Ok(await _verificationService.GetDevicesWithExpiredVerification(deviceCategory, consumerId));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
