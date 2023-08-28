using System.Threading.Tasks;
using Application.Contracts.Dtos;
using Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApi.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class MeasurementPointController : ControllerBase
	{
		private readonly IMeasurementPointService _measurementPointService;

		public MeasurementPointController(IMeasurementPointService measurementPointService)
		{
			_measurementPointService = measurementPointService;
		}

		/// <summary>
		/// Добавить новую точку измерения
		/// </summary>
		/// <param name="MeasurementPointDto"><see cref="MeasurementPointDto"/></param>
		/// <returns>Идентификатор новой точки измерения</returns>
		[HttpPost]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
		public async Task<IActionResult> Post(MeasurementPointDto request)
		{
			try
			{
			return Ok(await _measurementPointService.AddMeasurementPointAsync(
				request.Name,
				request.ConsumerId,
				request.CurrentTransformerId,
				request.ElectricityMeterId,
				request.VoltageTransformerId));
			}
			catch (System.Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
