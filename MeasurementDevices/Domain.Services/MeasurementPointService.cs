using System;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Domain.Services
{
    public class MeasurementPointService : IMeasurementPointService
	{
		private readonly AppDbContext _appDbContext;
		public MeasurementPointService(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public async Task<int> AddMeasurementPointAsync(
			string name,
			int consumerId,
			int currentTransformerId,
			int electricityMeterId,
			int voltageTransformerId)
		{
			await using var transaction = await _appDbContext.Database.BeginTransactionAsync().ConfigureAwait(false);
			await CheckMeasurementPointConstraints(consumerId, voltageTransformerId, currentTransformerId, electricityMeterId).ConfigureAwait(false);

			var measurementPoint = new MeasurementPoint
			{
				ConsumerId = consumerId,
				CurrentTransformer = await _appDbContext.CurrentTransformers.FindAsync(currentTransformerId).ConfigureAwait(false),
				ElectricityMeter = await _appDbContext.ElectricityMeters.FindAsync(electricityMeterId).ConfigureAwait(false),
				VoltageTransformer = await _appDbContext.VoltageTransformers.FindAsync(voltageTransformerId).ConfigureAwait(false),
				Name = name
			};

			await _appDbContext.MeasurementPoints.AddAsync(measurementPoint).ConfigureAwait(false);
			await _appDbContext.SaveChangesAsync().ConfigureAwait(false);
			await transaction.CommitAsync().ConfigureAwait(false);
			return measurementPoint.Id;
		}

		private async Task CheckMeasurementPointConstraints(int consumerId, int voltageTransformerId, int currentTransformerId, int electricityMeterId)
		{
			if (!await _appDbContext.VoltageTransformers.AnyAsync(t => t.Id == voltageTransformerId).ConfigureAwait(false))
				throw new ArgumentException($"{nameof(VoltageTransformer)} with id {voltageTransformerId} not found");

			if (!await _appDbContext.CurrentTransformers.AnyAsync(t => t.Id == currentTransformerId).ConfigureAwait(false))
				throw new ArgumentException($"{nameof(CurrentTransformer)} with id {currentTransformerId} not found");

			if (!await _appDbContext.Consumers.AnyAsync(t => t.Id == consumerId).ConfigureAwait(false))
				throw new ArgumentException($"{nameof(Consumer)} with id {consumerId} not found");

			if (await _appDbContext.MeasurementPoints.AnyAsync(mp => mp.VoltageTransformer.Id == voltageTransformerId).ConfigureAwait(false))
				throw new InvalidOperationException($"{nameof(MeasurementPoint)} with {nameof(VoltageTransformer)} (id: {voltageTransformerId}) already exists.");

			if (await _appDbContext.MeasurementPoints.AnyAsync(mp => mp.CurrentTransformer.Id == currentTransformerId).ConfigureAwait(false))
				throw new InvalidOperationException($"{nameof(MeasurementPoint)} with {nameof(CurrentTransformer)} (id: {currentTransformerId}) already exists.");

			if (await _appDbContext.MeasurementPoints.AnyAsync(mp => mp.ElectricityMeter.Id == electricityMeterId).ConfigureAwait(false))
				throw new InvalidOperationException($"{nameof(MeasurementPoint)} with {nameof(ElectricityMeter)} (id: {electricityMeterId}) already exists.");
		}
	}
}
