using Microsoft.AspNetCore.Mvc;

public class ExternalApiController : Controller
{
    private readonly ExternalApiService _externalApiService;

    public ExternalApiController(ExternalApiService externalApiService)
    {
        _externalApiService = externalApiService;
    }

    [HttpGet]
    public async Task<IActionResult> FetchData()
    {
        try
        {
            // Replace this with the actual API endpoint you're targeting
            string apiUrl = "https://chitfundapi-z0se.onrender.com/Person";
            var apiData = await _externalApiService.GetApiDataAsync(apiUrl);

            // Pass the API data to the view (if using MVC) or return as JSON
            return Content(apiData, "application/json");
        }
        catch (HttpRequestException e)
        {
            // Handle HTTP errors here (e.g., log the error, return a custom error page, etc.)
            return Content($"Error calling external API: {e.Message}");
        }
    }
}
