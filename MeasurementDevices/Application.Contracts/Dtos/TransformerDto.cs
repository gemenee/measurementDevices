using System;

namespace Application.Contracts.Dtos
{
    public abstract class TransformerDto
    {
        /// <summary>
        /// Номер
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Дата следующей поверки
        /// </summary>
        public DateTime NextVerificationDate { get; set; }
        /// <summary>
        /// Коэффициент трансформации
        /// </summary>
        public decimal TransformationRatio { get; set; }
    }
}