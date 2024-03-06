namespace Alicunde.PruebaTecnica.Services
{
    public class EsettService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<EsettService> _logger;

        public EsettService(HttpClient httpClient, IConfiguration configuration, ILogger<EsettService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger;

            var baseUrl = _configuration["EsettApiBaseUrl"];
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new InvalidOperationException("La configuración de la URL base de la API de Esett no se encontró en el archivo de configuración.");
            }

            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        /// <summary>
        /// Retrieves fees asynchronously from the Esett API.
        /// </summary>
        /// <returns>A string containing the fetched fees.</returns>
        /// <exception cref="HttpRequestException">Thrown when an error occurs during the HTTP request to the Esett API.</exception>
        public async Task<string> GetFeesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("EXP05/Fees");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error calling Esett API");
                throw;
            }
        }


    }
}
