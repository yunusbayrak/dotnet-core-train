using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Data.Bases;

namespace Core.Business.Models.Security.Identity.Bases
{
    public abstract class KullaniciModelBase : BaseEntity
    {
        [Required(ErrorMessage = "{0} girilmesi gereklidir!")]
        [StringLength(50)]
        [DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "{0} girilmesi gereklidir!")]
        [StringLength(50)]
        [DisplayName("Şifre")]
        public string Sifre { get; set; }

        public bool Aktif { get; set; }

        public int RolId { get; set; }
        public RolModelBase Rol { get; set; }
    }
}
