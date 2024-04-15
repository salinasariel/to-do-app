using System.ComponentModel.DataAnnotations;

namespace simple_to_do.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }

        public bool State {  get; set; }

    }
}
