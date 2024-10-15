using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        /// <summary>
        /// Creates a new to-do item.
        /// </summary>
        /// <param name="todoItem">The to-do item to create.</param>
        /// <returns>The created to-do item.</returns>
        [HttpPost]
        public ActionResult<TodoItem> CreateTodoItem([FromBody] TodoItem todoItem)
        {
            TodoItem createdItem = _todoService.CreateTodoItem(todoItem);
            return CreatedAtAction(nameof(GetTodoItemById), new { id = createdItem.Id }, createdItem);
        }

        /// <summary>
        /// Retrieves all to-do items.
        /// </summary>
        /// <returns>A list of all to-do items.</returns>
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAllTodoItems()
        {
            IEnumerable<TodoItem> items = _todoService.GetAllTodoItems();
            return Ok(items);
        }

        /// <summary>
        /// Retrieves a specific to-do item by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item.</param>
        /// <returns>The to-do item with the specified ID.</returns>
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItemById(Guid id)
        {
            TodoItem item = _todoService.GetTodoItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Updates an existing to-do item.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item to update.</param>
        /// <param name="todoItem">The updated to-do item.</param>
        [HttpPut("{id}")]
        public IActionResult UpdateTodoItem(Guid id, [FromBody] TodoItem todoItem)
        {
            _todoService.UpdateTodoItem(id, todoItem);
            return NoContent();
        }

        /// <summary>
        /// Deletes a to-do item by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item to delete.</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(Guid id)
        {
            _todoService.DeleteTodoItem(id);
            return NoContent();
        }

        /// <summary>
        /// Marks a to-do item as completed.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item to mark as completed.</param>
        [HttpPatch("{id}/complete")]
        public IActionResult MarkAsCompleted(Guid id)
        {
            _todoService.MarkAsCompleted(id);
            return NoContent();
        }

        /// <summary>
        /// Filters and sorts to-do items based on completion status and due date.
        /// </summary>
        /// <param name="completed">Filter for completed status.</param>
        /// <param name="dueDate">Filter for due date.</param>
        /// <param name="sortByDueDate">Indicates whether to sort by due date.</param>
        /// <returns>A filtered and sorted list of to-do items.</returns>
        [HttpGet("filter")]
        public ActionResult<IEnumerable<TodoItem>> FilterTodoItems(bool? completed, DateTime? dueDate, bool? sortByDueDate)
        {
            IEnumerable<TodoItem> items = _todoService.FilterByStatusAndDate(completed, dueDate, sortByDueDate);
            return Ok(items);
        }
    }
}
