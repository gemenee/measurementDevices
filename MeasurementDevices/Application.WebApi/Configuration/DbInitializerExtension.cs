using System.Threading.Tasks;
using System;
using Persistance;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Persistance.Entities;

namespace Application.WebApi.Configuration
{
	public static class DbInitializerExtension
	{
		public static async Task InitialiseDatabaseAsync(this IServiceProvider serviceProvider)
		{
			using var scope = serviceProvider.CreateScope();
			var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();

			await initialiser.SeedAsync();
		}
	}

	public sealed class AppDbContextInitialiser
	{
		private readonly AppDbContext _context;

		public AppDbContextInitialiser(AppDbContext context)
			=> _context = context;

		public async Task SeedAsync()
		{
			if (!_context.HeadOrganizations.Any())
			{
				_context.HeadOrganizations.Add(
					new HeadOrganization
					{
						Id = -1,
						Name = "Первая головная организация",
						Address = "Адрес первой головной организации"
					});

				await _context.SaveChangesAsync();
			}

			if (!_context.ChildOrganizations.Any())
			{
				_context.ChildOrganizations.Add(
					new ChildOrganization
					{
						Id = -2,
						Name = "Дочерняя организация первой головной организации",
						Address = "Адрес дочерней организации первой головной организации",
						HeadOrganizationId = -1,
					});

				await _context.SaveChangesAsync();
			}

			if (!_context.Consumers.Any())
			{
				_context.Consumers.Add(
					new Consumer
					{
						Id = -1,
						Address = "Адрес потребителя 1",
						Name = "Потребитель 1",
						OwnerOrganizationId = -1,
					});

				await _context.SaveChangesAsync();
			}

			if (!_context.MeasurementPoints.Any())
			{
				_context.MeasurementPoints.AddRange(
					new MeasurementPoint
					{
						Id = -1,
						Name = "Точка измерения 1",
						ConsumerId = -1,
					},
				new MeasurementPoint
				{
					Id = -2,
					Name = "Точка измерения 2",
					ConsumerId = -1,
				});

				await _context.SaveChangesAsync();
			}

			if (!_context.DeliveryPoints.Any())
			{
				_context.DeliveryPoints.Add(new DeliveryPoint
				{
					Name = "Точка поставки электроэнергии",
					MaximumPowerOutputInKilowatts = 1000,
					ConsumerId = -1,
				});

				await _context.SaveChangesAsync();
			}

			if (!_context.AccountingUnits.Any())
			{
				_context.AccountingUnits.AddRange(
					new AccountingUnit
					{
						Id = -33,
					},
					new AccountingUnit
					{
						Id = -31
					},
					new AccountingUnit
					{
						Id = -32
					});

				await _context.SaveChangesAsync();
			}

			if (!_context.MeasurementPeriods.Any())
			{
				_context.MeasurementPeriods.AddRange(
					new MeasurementPeriod
					{
						AccountingUnitId = -33,
						MeasurementPointId = -1,
						Start = new DateTime(2018, 1, 1),
						End = new DateTime(2018, 12, 31)
					},
					new MeasurementPeriod
					{
						AccountingUnitId = -32,
						MeasurementPointId = -1,
						Start = new DateTime(2019, 1, 1),
						End = new DateTime(2019, 12, 31)
					});

				await _context.SaveChangesAsync();
			}

			if (!_context.ElectricityMeters.Any())
			{
				_context.ElectricityMeters.AddRange(
					new ElectricityMeter
					{
						Id = -11,
						MeasurementPointId = -2,
						NextVerificationDate = new DateTime(2022, 1, 1),
						Number = "321654981",
						Type = MeterType.ThreePhase
					},
					new ElectricityMeter
					{
						Id = -12,
						MeasurementPointId = -1,
						NextVerificationDate = new DateTime(2024, 1, 1),
						Number = "321654982",
						Type = MeterType.ThreePhase
					},
					new ElectricityMeter
					{
						Id = -13,
						NextVerificationDate = new DateTime(2024, 1, 1),
						Number = "321654983",
						Type = MeterType.ThreePhase
					});

				await _context.SaveChangesAsync();
			}

			if (!_context.CurrentTransformers.Any())
			{
				_context.CurrentTransformers.AddRange(
					new CurrentTransformer
					{
						Id = -11,
						MeasurementPointId = -1,
						NextVerificationDate = new DateTime(2022, 1, 1),
						Number = "987654321",
						TransformationRatio = 20m,
						Type = CurrentTransformerType.Intervening
					},
					new CurrentTransformer
					{
						Id = -12,
						MeasurementPointId = -2,
						NextVerificationDate = new DateTime(2024, 1, 1),
						Number = "987654322",
						TransformationRatio = 20m,
						Type = CurrentTransformerType.Intervening
					},
					new CurrentTransformer
					{
						Id = -13,
						NextVerificationDate = new DateTime(2024, 1, 1),
						Number = "987654323",
						TransformationRatio = 20m,
						Type = CurrentTransformerType.Intervening
					});

				await _context.SaveChangesAsync();
			}

			if (!_context.VoltageTransformers.Any())
			{
				_context.VoltageTransformers.AddRange(
					new VoltageTransformer
					{
						Id = -11,
						MeasurementPointId = -1,
						NextVerificationDate = new DateTime(2022, 1, 1),
						Number = "789456121",
						TransformationRatio = 20m,
						Type = VoltageTransformerType.Capacitor
					},
					new VoltageTransformer
					{
						Id = -12,
						MeasurementPointId = -2,
						NextVerificationDate = new DateTime(2024, 1, 1),
						Number = "789456122",
						TransformationRatio = 20m,
						Type = VoltageTransformerType.Capacitor
					},
					new VoltageTransformer
					{
						Id = -13,
						NextVerificationDate = new DateTime(2024, 1, 1),
						Number = "789456123",
						TransformationRatio = 20m,
						Type = VoltageTransformerType.Capacitor
					});

				await _context.SaveChangesAsync();
			}

		}
	}
}
