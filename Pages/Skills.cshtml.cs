using Microsoft.AspNetCore.Mvc.RazorPages;
using tester.Models;
using tester.Services;


namespace tester.Pages;

public class SkillsPageModel : PageModel
{
    private readonly ICosmosService _cosmosService;

    public IEnumerable<Skill>? Skill { get; set; }


[Microsoft.AspNetCore.Mvc.BindProperty(SupportsGet = true)]
   public string? q { get; set; }

   // public Microsoft.AspNetCore.Mvc.Rendering.SelectList? Genres { get; set; }





    public SkillsPageModel(ICosmosService cosmosService)
    {
        _cosmosService = cosmosService;
    }

  

    public async Task OnGetAsync()
    {

        var data1 = "social"; 
        data1=q;
           // if (q is not null) {
        Skill ??= await _cosmosService.RetrieveActiveSkillsAsync(data1);
         //   }
            

    }
}