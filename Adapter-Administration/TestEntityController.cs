using Application_Code.Interfaces;
using Domain_Code;
using Microsoft.AspNetCore.Mvc;

namespace Adapter_Administration;

[Route("api/[controller]")]
[ApiController]
public class TestEntityController(IEntityManager entityManager) : Controller
{
    private readonly IRepository<Customer>  _customers = entityManager.GetRepository<Customer>();
    // GET
    public IActionResult Index()
    {
        return Json(_customers.GetAll());
    }
}