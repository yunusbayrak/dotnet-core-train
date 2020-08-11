using Core.Data.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public class Personel : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        [Column(TypeName = "varchar(250)")]
        public string AdSoyad { get; set; }
        //public int PBIK { get; set; }
        //public DateTime DogumTarihi { get; set; }

        public List<Faaliyet> Faaliyetler { get; set; }

    }
}
