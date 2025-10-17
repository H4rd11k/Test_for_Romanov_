using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Managment.Models;

namespace Task_Managment.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly TaskContext _context;

    public TasksController(TaskContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IEnumerable<TaskItem>> Get() =>
        await _context.TaskItems.ToListAsync();
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> Get(int id)
    {
        var task = await _context.TaskItems.FindAsync(id);
        if (task == null) return NotFound();
        return task;
    }
    
    [HttpPost]
    public async Task<ActionResult<TaskItem>> Post(TaskItem item)
    {
        if (string.IsNullOrWhiteSpace(item.Title))
            return BadRequest("Title обязателен");

        item.CreatedAt = DateTime.UtcNow;
        _context.TaskItems.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, TaskItem item)
    {
        if (id != item.Id) return BadRequest();
        if (string.IsNullOrWhiteSpace(item.Title))
            return BadRequest("Title обязателен");

        var exist = await _context.TaskItems.FindAsync(id);
        if (exist == null) return NotFound();

        exist.Title = item.Title;
        exist.Description = item.Description;
        exist.IsCompleted = item.IsCompleted;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _context.TaskItems.FindAsync(id);
        if (task == null) return NotFound();
        _context.TaskItems.Remove(task);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}