namespace NetTechnicalTest.Utilities
{
    /// <summary>
    /// Clase para los métodos de extensión de la clase DateTime
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Tranforma un obeto DateTime a una string con formato ISO 8601
        /// </summary>
        /// <param name="date">Fecha a transformar</param>
        /// <returns>Codena con el formato yyyy-MM-ddTHH:mm:ss.fffZ</returns>
        public static string ToDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
        }
    }
}
