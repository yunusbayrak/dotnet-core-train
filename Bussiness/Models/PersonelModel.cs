using System.ComponentModel.DataAnnotations;
using Core.Data.Bases;

namespace Business.Models
{
    public class PersonelModel : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string AdSoyad { get; set; }
    }
}
