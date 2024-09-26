public class ExternalApiService
{
    private readonly HttpClient _httpClient;

    public ExternalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Example method to call an external API
    public async Task<string> GetApiDataAsync(string endpoint)
    {
        // Replace with the actual external API endpoint
        var response = await _httpClient.GetAsync(endpoint);

        // Ensure the response is successful
        response.EnsureSuccessStatusCode();

        // Read and return the response content as a string
        return await response.Content.ReadAsStringAsync();
    }
}
