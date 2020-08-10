using Core.Data.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entities
{
    public class Personel : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string AdSoyad { get; set; }
        //public int PBIK { get; set; }
        //public DateTime DogumTarihi { get; set; }

        public List<Faaliyet> Faaliyetler { get; set; }

        public List<PersonelIhbar> PersonelIhbarlar { get; set; }
    }
}
