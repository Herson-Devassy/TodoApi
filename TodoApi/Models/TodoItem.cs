using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    /// <summary>
    /// Represents a to-do item with properties for title, description, due date, and completion status.
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the to-do item.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the title of the to-do item.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the to-do item.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the due date of the to-do item.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the to-do item is completed.
        /// </summary>
        public bool Completed { get; set; } = false;
    }
}
