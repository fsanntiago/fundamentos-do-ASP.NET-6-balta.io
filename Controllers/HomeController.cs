using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Get([FromServices] AppDbContext context) 
        => Ok(context.TodoModels.ToList());

    [HttpGet("/{id:int}")]
    public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var todos = context.TodoModels.FirstOrDefault(x => x.Id == id);
        if (todos == null)
            return NotFound();

        return Ok(todos);
    }

    [HttpPost("/")]
    public IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
        context.TodoModels.Add(todo);
        context.SaveChanges();
        return Created($"/{todo.Id}",todo);
    }
    
    [HttpPut("/{id:int}")]
    public IActionResult Put([FromRoute]int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
        var model = context.TodoModels.FirstOrDefault(x => x.Id ==  id);
        if (model == null)
            return NotFound();
        
        // Comparar os valores que vem da tabela com que veio do banco 
        model.Title = todo.Title;
        model.Done = todo.Done;

        context.TodoModels.Update(model);
        context.SaveChanges();
        return Ok(model);
    }
    
    [HttpDelete("/{id:int}")]
    public IActionResult Delete([FromRoute]int id, [FromServices] AppDbContext context)
    {
        var model = context.TodoModels.FirstOrDefault(x => x.Id ==  id);
        if (model == null)
            return NotFound();
        
        context.TodoModels.Remove(model);
        context.SaveChanges();
        return Ok(model);
    }
}