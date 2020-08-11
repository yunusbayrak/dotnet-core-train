using Core.Data.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public class Ihbar : BaseEntity
    {
        public int IhbarDurumuId { get; set; }
        [Required]
        [MaxLength(5000)]
        [Column(TypeName = "varchar(5000)")]
        public string Ozet { get; set; }
        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string Yer { get; set; }
        public DateTime Tarih { get; set; }
        public IhbarDurumu IhbarDurumu { get; set; }
        public List<OlayIhbar> OlayIhbarlar { get; set; }
    }
}
