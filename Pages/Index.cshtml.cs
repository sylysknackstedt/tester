using Microsoft.AspNetCore.Mvc.RazorPages;
using tester.Models;
using tester.Services;


namespace tester.Pages;

public class IndexPageModel : PageModel
{
    private readonly ICosmosService _cosmosService;

    public IEnumerable<Character>? Characters { get; set; }

    public IndexPageModel(ICosmosService cosmosService)
    {
        _cosmosService = cosmosService;
    }

    public async Task OnGetAsync()
    {



        Characters ??= await _cosmosService.RetrieveActiveProductsAsync();
    }
}