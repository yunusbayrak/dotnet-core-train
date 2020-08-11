using Core.Data.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public class IslemDurumu : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Adi { get; set; }
        public List<Faaliyet> Faaliyetler { get; set; }

    }
}
