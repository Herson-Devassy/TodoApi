using TodoApi.Models;

namespace TodoApi.Services
{
    /// <summary>
    /// Interface defining the contract for managing to-do items.
    /// </summary>
    public interface ITodoService
    {
        /// <summary>
        /// Creates a new to-do item.
        /// </summary>
        /// <param name="todoItem">The to-do item to create.</param>
        /// <returns>The created to-do item.</returns>
        TodoItem CreateTodoItem(TodoItem todoItem);

        /// <summary>
        /// Retrieves all to-do items.
        /// </summary>
        /// <returns>A list of all to-do items.</returns>
        IEnumerable<TodoItem> GetAllTodoItems();

        /// <summary>
        /// Retrieves a specific to-do item by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item.</param>
        /// <returns>The to-do item with the specified ID.</returns>
        TodoItem GetTodoItemById(Guid id);

        /// <summary>
        /// Updates an existing to-do item.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item to update.</param>
        /// <param name="todoItem">The updated to-do item.</param>
        void UpdateTodoItem(Guid id, TodoItem todoItem);

        /// <summary>
        /// Deletes a to-do item by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item to delete.</param>
        void DeleteTodoItem(Guid id);

        /// <summary>
        /// Marks a to-do item as completed.
        /// </summary>
        /// <param name="id">The unique identifier of the to-do item to mark as completed.</param>
        void MarkAsCompleted(Guid id);

        /// <summary>
        /// Filters and sorts to-do items based on completion status and due date.
        /// </summary>
        /// <param name="completed">Filter for completed status.</param>
        /// <param name="dueDate">Filter for due date.</param>
        /// <param name="sortByDueDate">Indicates whether to sort by due date.</param>
        /// <returns>A filtered and sorted list of to-do items.</returns>
        IEnumerable<TodoItem> FilterByStatusAndDate(bool? completed, DateTime? dueDate, bool? sortByDueDate);
    }
}
