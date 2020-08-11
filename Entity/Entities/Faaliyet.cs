using Core.Data.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace Entity.Entities
{
    public class Faaliyet : BaseEntity
    {
        public int IhbarId { get; set; }
        public Ihbar Ihbar { get; set; }
        public int IslemDurumuId { get; set; }
        public int PersonelId { get; set; }
        [Required]
        [MaxLength(5000)]
        [Column(TypeName = "varchar(5000)")]
        public string Aciklama { get; set; }
        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string Yer { get; set; }
        public DateTime Tarih { get; set; }
        public Personel Personel { get; set; }
        public IslemDurumu IslemDurumu { get; set; }
    }
}
