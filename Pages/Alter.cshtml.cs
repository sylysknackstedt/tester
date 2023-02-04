using Microsoft.AspNetCore.Mvc.RazorPages;
using tester.Models;
using tester.Services;

namespace tester.Pages;

public class AlterPageModel : PageModel
{
    private readonly ICosmosService _cosmosService;

    public IEnumerable<Character>? Characters { get; set; }

    public AlterPageModel(ICosmosService cosmosService)
    {
        _cosmosService = cosmosService;
    }

    public async Task OnGetAsync()
    {
        Characters ??= await _cosmosService.ReplaceCharacterAsync();

      

    }
}