using Core.Data.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entities
{
    public class Ihbar : BaseEntity
    {
        public int IhbarDurumuId { get; set; }
        [Required]
        [StringLength(5000)]
        public string Ozet { get; set; }
        [Required]
        public string Yer { get; set; }
        public DateTime Tarih { get; set; }
        public IhbarDurumu IhbarDurumu { get; set; }
        public List<OlayIhbar> OlayIhbarlar { get; set; }
        public List<PersonelIhbar> PersonelIhbarlar { get; set; }
    }
}
