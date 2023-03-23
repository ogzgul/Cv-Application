using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Cv.Models
{
    public class Course
    {
        public int Id { get; set; }
        [DisplayName("Kurs Adı")]
        [Column(TypeName = "nchar(100)")]
        public string? CourseName { get; set; }
        [DisplayName("Kurum")]

        [Column(TypeName = "nchar(100)")]
        public string? Institution { get; set; }
        [DisplayName("Şehir")]

        [Column(TypeName = "nchar(50)")]
        public string? City { get; set; }
        [DisplayName("Ülke")]

        [Column(TypeName = "nchar(50)")]
        public string? Country { get; set; }
        [DisplayName("Başlangıç Tarihi")]
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [DisplayName("Bitiş Tarihi")]
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set;}

        [DisplayName("İçerik")]
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
    }
}
