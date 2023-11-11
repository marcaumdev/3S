using Microsoft.AspNetCore.Mvc;

namespace api_3s.Controllers;

public class AuthController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
