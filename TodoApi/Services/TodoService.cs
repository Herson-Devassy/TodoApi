using TodoApi.Models;

namespace TodoApi.Services
{
    /// <summary>
    /// Provides methods for managing to-do items.
    /// </summary>
    public class TodoService : ITodoService
    {
        private readonly List<TodoItem> _todoItems = new List<TodoItem>();

        /// <summary>
        /// Creates a new to-do item.
        /// </summary>
        /// <param name="todoItem">The to-do item to create.</param>
        /// <returns>The created to-do item.</returns>
        public TodoItem CreateTodoItem(TodoItem todoItem)
        {
            _todoItems.Add(todoItem);
            return todoItem;
        }

        /// <summary>
        /// Retrieves all to-do items.
        /// </summary>
        /// <returns>A list of all to-do items.</returns>
        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _todoItems;
        }

        /// <summary>
        /// Retrieves a specific to-do item by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item.</param>
        /// <returns>The to-do item with the specified ID.</returns>
        public TodoItem GetTodoItemById(Guid id)
        {
            return _todoItems.FirstOrDefault(item => item.Id == id);
        }

        /// <summary>
        /// Updates an existing to-do item.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item to update.</param>
        /// <param name="todoItem">The updated to-do item.</param>
        public void UpdateTodoItem(Guid id, TodoItem todoItem)
        {
            TodoItem existingItem = GetTodoItemById(id);
            if (existingItem != null)
            {
                existingItem.Title = todoItem.Title;
                existingItem.Description = todoItem.Description;
                existingItem.DueDate = todoItem.DueDate;
                existingItem.Completed = todoItem.Completed;
            }
        }

        /// <summary>
        /// Deletes a to-do item by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item to delete.</param>
        public void DeleteTodoItem(Guid id)
        {
            TodoItem existingItem = GetTodoItemById(id);
            if (existingItem != null)
            {
                _todoItems.Remove(existingItem);
            }
        }

        /// <summary>
        /// Marks a to-do item as completed.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item to mark as completed.</param>
        public void MarkAsCompleted(Guid id)
        {
            TodoItem existingItem = GetTodoItemById(id);
            if (existingItem != null)
            {
                existingItem.Completed = true;
            }
        }

        /// <summary>
        /// Filters and sorts to-do items based on completion status and due date.
        /// </summary>
        /// <param name="completed">Filter for completed status.</param>
        /// <param name="dueDate">Filter for due date.</param>
        /// <param name="sortByDueDate">Indicates whether to sort by due date.</param>
        /// <returns>A filtered and sorted list of to-do items.</returns>
        public IEnumerable<TodoItem> FilterByStatusAndDate(bool? completed, DateTime? dueDate, bool? sortByDueDate)
        {
            IQueryable<TodoItem> query = _todoItems.AsQueryable();

            if (completed.HasValue)
            {
                query = query.Where(item => item.Completed == completed.Value);
            }

            if (dueDate.HasValue)
            {
                query = query.Where(item => item.DueDate == dueDate.Value);
            }

            if (sortByDueDate.HasValue && sortByDueDate.Value)
            {
                query = query.OrderBy(item => item.DueDate);
            }

            return query.ToList();
        }
    }
}
