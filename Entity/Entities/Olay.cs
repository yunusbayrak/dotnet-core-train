using Core.Data.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Entities
{
    public class Olay : BaseEntity
    {
        public string IlkNeden { get; set; }
        [Required]
        [StringLength(500)]
        public string OlusSekli { get; set; }
        [Required]
        [StringLength(100)]
        public string Yer { get; set; }
        public DateTime Tarih { get; set; }

        public List<OlayIhbar> OlayIhbarlar { get; set; }
    }
}
