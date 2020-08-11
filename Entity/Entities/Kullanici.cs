using Core.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public class Kullanici : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifre { get; set; }

        public bool Aktif { get; set; }

        public int? PersonelId { get; set; }
        public Personel Personel { get; set; }

        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
