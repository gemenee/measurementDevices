namespace Application.Contracts.Dtos
{

    /// <summary>
    /// Трансформатор тока
    /// </summary>
    public class CurrentTransformerDto : TransformerDto
    {
        /// <summary>
        /// Тип трансформатора тока
        /// </summary>
        public string Type { get; set; }
    }
}