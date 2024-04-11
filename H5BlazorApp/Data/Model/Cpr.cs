using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5BlazorApp.Data.Model
{
    public class Cpr
    {
        [Key]
        public int CprId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string User { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string CprNr { get; set; } 

    }
}
