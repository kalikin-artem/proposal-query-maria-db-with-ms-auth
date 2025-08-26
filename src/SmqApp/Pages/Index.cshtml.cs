using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmqApp.Data;
namespace SmqApp.Pages;
[Authorize(Policy = "AllowedGroup")]
public class IndexModel : PageModel
{
    private readonly IWidgetRepository _repo;
    public List<Widget> Widgets { get; private set; } = new();
    public IndexModel(IWidgetRepository repo) => _repo = repo;
    public async Task OnGet() => Widgets = (await _repo.GetWidgetsAsync()).ToList();
}
