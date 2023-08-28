namespace Application.Contracts.Dtos
{
    /// <summary>
    /// Точка измерения электроэнергии
    /// </summary>
    public class MeasurementPointDto
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Потребитель
        /// </summary>
        public int ConsumerId { get; set; }
        /// <summary>
        /// Счётчик электроэнергии
        /// </summary>
        public int ElectricityMeterId { get; set; }
        /// <summary>
        /// Трансформатор тока
        /// </summary>
        public int CurrentTransformerId { get; set; }
        /// <summary>
        /// Трансформатор напряжения
        /// </summary>
        public int VoltageTransformerId { get; set; }
    }
}
