using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Bases;

namespace Entity.Entities
{
    public class Rol : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Adi { get; set; }

        public List<Kullanici> Kullanicilar { get; set; }
    }
}
