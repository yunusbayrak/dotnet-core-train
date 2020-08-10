using Core.Data.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entities
{
    public class IhbarDurumu : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Adi { get; set; }
        public List<Ihbar> Ihbarlar { get; set; }
    }
}
