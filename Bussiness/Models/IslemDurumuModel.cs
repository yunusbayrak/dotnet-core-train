using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Data.Bases;

namespace Business.Models
{
    public class IslemDurumuModel : BaseEntity
    {
        private string _adi;

        [Required(ErrorMessage = "{0} girilmesi gereklidir!")]
        [StringLength(100)]
        [DisplayName("Adı")]
        public string Adi
        {
            get { return _adi; }
            set { _adi = value.Trim(); }
        }

        public int FaaliyetSayisi { get; set; }
    }
}
