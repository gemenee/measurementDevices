using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Persistance
{
	public interface IVerificationExpirable
	{
		/// <summary>
		/// Дата следующей поверки
		/// </summary>
		public DateTime NextVerificationDate { get; set; }
	}

	public interface IDevice
	{
		/// <summary>
		/// Точка измерения
		/// </summary>
		public MeasurementPoint MeasurementPoint { get; set; }
		/// <summary>
		/// Номер
		/// </summary>
		public string Number { get; set; }
	}
}
