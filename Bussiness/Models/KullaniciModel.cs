using System.ComponentModel;
using Core.Business.Models.Security.Identity;

namespace Business.Models
{
    public class KullaniciModel : KullaniciParentModel
    {
        [DisplayName("Personel")]
        public int? PersonelId { get; set; }
        public PersonelModel Personel { get; set; }
    }
}
