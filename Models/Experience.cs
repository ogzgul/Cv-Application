using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cv.Models
{
    public class Experience
    {
        public int Id { get; set; }
        [DisplayName("İşyeri Adı")]
        [Column(TypeName = "nchar(100)")]
        public string? Name { get; set; }
        [DisplayName("Ünvan")]
        [Column(TypeName = "nchar(50)")]
        public string? JobTitle { get; set; }
        [DisplayName("Başlangıç Tarihi")]
        [Column(TypeName = "date")]
        public DateTime? StartTime { get; set; }
        [DisplayName("Bitiş Tarihi")]
        [Column(TypeName = "date")]
        public DateTime? EndTime { get; set; }
        [DisplayName("İçerik")]
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
    }
}
