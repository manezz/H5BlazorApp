using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5BlazorApp.Data.Model
{
    public class Todolist
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Cpr.Id")]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Item { get; set; }

        public Cpr Cpr { get; set; }
    }
}
