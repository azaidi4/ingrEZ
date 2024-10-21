using Algolia.Search.Clients;
using Algolia.Search.Models.Search;

namespace ingrEZ;

public class IngredientSearch(string? applicationId, string? apiKey)
{
  readonly SearchClient client = new SearchClient(applicationId, apiKey);

  private record IngredientResult
  {
    public required string IdIngredient { get; set; }
    public required string ObjectID { get; set; }

    public required string StrIngredient { get; set; }
    public string? StrType { get; set; }
    public string? StrDescription { get; set; }
  }

  public async Task<IEnumerable<string>> SearchIngredients(string query, CancellationToken token)
  {
    try
    {
      var search = await client.SearchSingleIndexAsync<IngredientResult>("ingredients",
      new SearchParams(new SearchParamsObject
      {
        Query = query
      }), cancellationToken: token);
      return search.Hits.Select(i => i.StrIngredient).ToArray();
    }
    catch (Algolia.Search.Exceptions.AlgoliaApiException ex)
    {
      // Handle exceptions from the Algolia API here
      // Log the exception message: ex.Message
      Console.WriteLine(ex.Message);
      return [];
    }
  }
}