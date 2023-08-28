using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Application.Contracts.Dtos;
using Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountingController : ControllerBase
	{
		private readonly IAccountingService _accountingService;

		public AccountingController(IAccountingService accountingService)
		{
			_accountingService = accountingService;
		}

		/// <summary>
		/// Рассчётные приборы учёта за период
		/// </summary>
		/// <param name="PeriodDto"><see cref="PeriodDto"/></param>
		/// <returns>AccountingUnitDto</returns>
		[HttpGet]
		[ProducesResponseType(typeof(AccountingUnitDto), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll([FromQuery] PeriodDto query)
		{
			if (query.Start > query.End)
				return BadRequest("Неправильный интервал");

			try
			{
				return Ok(await _accountingService.GetByDateAsync(query.Start, query.End).ConfigureAwait(false));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
