using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Cv.Models
{
    public class Member
    {
        public short Id { get; set; }

        [Column(TypeName = "nchar(100)")]
        [Required(ErrorMessage = "Bu alan gerekli")]
        [DisplayName("İsim")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter")]
        public string Name { get; set; }
        [Column(TypeName = "nchar(100)")]
        [Required(ErrorMessage = "Bu alan gerekli")]
        [DisplayName("Soyisim")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter")]
        public string Surname { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Meslek")]
        [Column(TypeName = "nvarchar(50)")]
        public string? JobTitle { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Adres")]
        [Column(TypeName = "nchar(500)")]
        [StringLength(500, ErrorMessage = "En fazla 500 karakter")]
        public string Address { get; set; }
        [Display(Name = "Hakkımda")]
        [Column(TypeName = "ntext")]
        public string? About { get; set; }


    }
}
