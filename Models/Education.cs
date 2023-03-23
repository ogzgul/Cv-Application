using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cv.Models
{
    public class Education
    {
        public int Id { get; set; }

        [DisplayName("Derece")]
        [Column(TypeName = "nchar(50)")]
        public string? Degree { get; set; }

        [DisplayName("Okul Adı")]
        [Column(TypeName = "nchar(100)")]
        public string? SchoolName { get; set; }

        [DisplayName("Bölüm")]
        [Column(TypeName = "nchar(100)")]
        public string? SchoolSection { get; set; }

        [DisplayName("Ortalama")]
        [Column(TypeName = "nchar(10)")]
        public string? GNO { get; set; }

        [DisplayName("Şehir")]
        [Column(TypeName = "nchar(50)")]
        public string? City { get; set; }

        [DisplayName("Ülke")]
        [Column(TypeName = "nchar(50)")]
        public string? Country { get; set; }

        [DisplayName("Başlangıç Tarihi")]
        [Column(TypeName = "date")]
        public DateTime? StartTime { get; set; }
        [Column(TypeName = "date")]
        [DisplayName("Bitiş Tarihi")]
        public DateTime? EndTime { get; set;}

        [DisplayName("İçerik(Opsiyonel)")]
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
    }
}
