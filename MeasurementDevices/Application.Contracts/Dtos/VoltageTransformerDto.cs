namespace Application.Contracts.Dtos
{
    /// <summary>
    /// Трансформатор напряжения
    /// </summary>
    public class VoltageTransformerDto : TransformerDto
    {
        /// <summary>
        /// Тип трансформатора напряжения
        /// </summary>
        public string Type { get; set; }
    }
}