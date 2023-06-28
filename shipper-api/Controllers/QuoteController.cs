using Microsoft.AspNetCore.Mvc;
using shipper_api.DTO;

namespace Shipper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {
        private const string quotableUrl = "https://api.quotable.io/";
        private readonly HttpClient _httpClient;

        public QuoteController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet("random")]
        public async Task<IActionResult> Random()
        {
            var res = await _httpClient.GetAsync(quotableUrl + "random");
            return Ok(await res.Content.ReadFromJsonAsync<Quote>());
        }

        [HttpGet("getByAuthor/{authorName}")]
        public async Task<IActionResult> GetByAuthorNameAsync(string authorName)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{quotableUrl}quotes?limit=30&author={authorName}");
                if (response.IsSuccessStatusCode)
                {
                    var quotes = await response.Content.ReadFromJsonAsync<PaginatedQuoteResponse>();
                    var groupedQuotes = GroupQuotesByLength(quotes.Results);
                    return Ok(groupedQuotes);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while retrieving quotes.", ex.Message);
            }
        }

        private Dictionary<string, List<Quote>> GroupQuotesByLength(List<Quote> quotes )
        {
            var groupedQuotes = quotes.GroupBy(q =>
            {
                if (q.Length < 10)
                    return "short";
                else if (q.Length <= 20)
                    return "medium";
                else
                    return "long";
            }).ToDictionary(g => g.Key, g => g.ToList());

            // Ensure all list names are included even if empty
            var lengthCategories = new[] { "short", "medium", "long" };
            foreach (var category in lengthCategories)
            {
                if (!groupedQuotes.ContainsKey(category))
                    groupedQuotes[category] = new List<Quote>();
            }
            return groupedQuotes;
        }

    }


}
