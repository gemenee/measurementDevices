using System;

namespace Application.Contracts.Dtos
{
    /// <summary>
    /// Счётчик электроэнергии
    /// </summary>
    public class ElectricityMeterDto
    {
        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Тип счётчика
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Дата следующей поверки
        /// </summary>
        public DateTime NextVerificationDate { get; set; }
    }
}