using Core.Data.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entities
{
    public class IslemDurumu : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Adi { get; set; }
        public List<Faaliyet> Faaliyetler { get; set; }

    }
}
