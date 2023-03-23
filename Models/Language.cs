using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cv.Models
{
    public class Language
    {
        public int Id { get; set; }
        [DisplayName("Diller")]
        [Column(TypeName = "nchar(50)")]
        public string? Languages { get; set; }
        [DisplayName("Ek Bilgiler")]
        [Column(TypeName = "ntext")]
        public string? Information { get; set; }
        [DisplayName("Language Level")]
        [Column(TypeName = "nchar(10)")]
        public string? Level { get; set; }
    }
}
