using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Cv.Models
{
    public class Reference
    {
        public int Id { get; set; }
        [Display(Name = "İsim")]
        [Column(TypeName = "nchar(100)")]
        public string Name { get; set; }
        [Display(Name = "Soyisim")]
        [Column(TypeName = "nchar(50)")]
        public string SurName { get; set; }
        [Display(Name = "Ünvanı")]
        [Column(TypeName = "nchar(50)")]
        public string JobTitle { get; set; }
        [Display(Name = "Çalıştığı Kurum")]
        [Column(TypeName = "nchar(100)")]
        public string Organisation { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Numarası")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
    }
}
