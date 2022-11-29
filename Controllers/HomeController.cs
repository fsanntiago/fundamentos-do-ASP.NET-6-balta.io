using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public List<TodoModel> Get([FromServices] AppDbContext context)
    {
        return context.TodoModels.ToList();
    }

    [HttpGet("/{id:int}")]
    public TodoModel GetById([FromRoute] int id, [FromServices] AppDbContext context)
    {
        return context.TodoModels.FirstOrDefault(x => x.Id == id);
    }

    [HttpPost("/")]
    public TodoModel Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
        context.TodoModels.Add(todo);
        context.SaveChanges();
        return todo;
    }
    
    [HttpPut("/{id:int}")]
    public TodoModel Put([FromRoute]int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
        var model = context.TodoModels.FirstOrDefault(x => x.Id ==  id);
        if (model == null)
            return todo;
        
        // Comparar os valores que vem da tabela com que veio do banco 
        model.Title = todo.Title;
        model.Done = todo.Done;

        context.TodoModels.Update(model);
        context.SaveChanges();
        return model;
    }
    
    [HttpDelete("/{id:int}")]
    public TodoModel Delete([FromRoute]int id, [FromServices] AppDbContext context)
    {
        var model = context.TodoModels.FirstOrDefault(x => x.Id ==  id);
        context.TodoModels.Remove(model);
        context.SaveChanges();
        return model;
    }
}