using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers;

[ApiController]
[Route("home")]
public class HomeController : ControllerBase
{
    [HttpGet]
    [Route("/")]
    public string Get()
    {
        return "Hello World";
    }
}