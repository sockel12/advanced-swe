using Microsoft.AspNetCore.Mvc;

namespace Adapter_Administration;

public class TestEntityController : Controller
{
    // GET
    public IActionResult Index()
    {
        return new AcceptedResult();
    }
}