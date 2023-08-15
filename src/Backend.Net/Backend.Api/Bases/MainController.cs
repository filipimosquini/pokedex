using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Bases;

[ApiController]
public class MainController : Controller
{
    protected ICollection<string> Erros = new List<string>();
}