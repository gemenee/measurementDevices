using System;

namespace Application.Contracts.Dtos
{
    public class ExpiredDeviceDto
    {
        /// <summary>
        /// Тип устройства
        /// </summary>
        public string DeviceCategory { get; set; }
        /// <summary>
        /// Номер устройства
        /// </summary>
        public string DeviceNumber { get; set; }
        /// <summary>
        /// Дата истечения срока поверки
        /// </summary>
        public DateTime VerificationExpiredAt { get; set; }
    }
}
