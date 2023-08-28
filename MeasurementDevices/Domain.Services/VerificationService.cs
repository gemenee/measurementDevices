using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Dtos;
using Application.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Domain.Services
{
    public class VerificationService : IVerificationService
	{
		private readonly AppDbContext _appDbContext;

		public VerificationService(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<IEnumerable<ExpiredDeviceDto>> GetDevicesWithExpiredVerification(string deviceCategory, int? consumerId)
		{
			if (Enum.TryParse(deviceCategory, out DeviceCategory category))
			{
				return category switch
				{
					DeviceCategory.CurrentTransformer => (await GetDevicesWithExpiredVerification<CurrentTransformer>(consumerId))
						.Select(vt => new ExpiredDeviceDto
						{
							DeviceCategory = category.ToString(),
							DeviceNumber = vt.Number,
							VerificationExpiredAt = vt.NextVerificationDate
						}).ToList(),
					DeviceCategory.VoltageTransformer => (await GetDevicesWithExpiredVerification<VoltageTransformer>(consumerId))
						.Select(vt => new ExpiredDeviceDto
						{
							DeviceCategory = category.ToString(),
							DeviceNumber = vt.Number,
							VerificationExpiredAt = vt.NextVerificationDate
						}).ToList(),
					DeviceCategory.ElectricityMeter => (await GetDevicesWithExpiredVerification<ElectricityMeter>(consumerId))
						.Select(vt => new ExpiredDeviceDto
						{
							DeviceCategory = category.ToString(),
							DeviceNumber = vt.Number,
							VerificationExpiredAt = vt.NextVerificationDate
						}).ToList(),
					_ => throw new ArgumentException("Device category not found."),
				};
			}
			else
				throw new ArgumentException("Device category not imlemented.");
		}

		private async Task<IEnumerable<TDevice>> GetDevicesWithExpiredVerification<TDevice>(int? consumerId )
			where TDevice : EntityBase, IVerificationExpirable, IDevice
		{
			var currentDate = DateTime.Now;
			return await _appDbContext.Set<TDevice>()
				.Where(vt => (vt.MeasurementPoint.ConsumerId == consumerId || !consumerId.HasValue) && vt.NextVerificationDate < currentDate)
				.ToListAsync().ConfigureAwait(false);
		}
	}
}
