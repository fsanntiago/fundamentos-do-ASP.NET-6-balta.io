using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    [Route("/")]
    public List<TodoModel> Get([FromServices]AppDbContext context)
    {
        return context.TodoModels.ToList();
    }
    
    [HttpPost]
    [Route("/")]
    public TodoModel Post([FromBody]TodoModel todo, [FromServices]AppDbContext context)
    {
        context.TodoModels.Add(todo);
        context.SaveChanges();
        return todo;
    }
}