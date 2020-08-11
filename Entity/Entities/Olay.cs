using Core.Data.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entities
{
    public class Olay : BaseEntity
    {
        public string IlkNeden { get; set; }
        [Required]
        [MaxLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string OlusSekli { get; set; }
        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string Yer { get; set; }
        public DateTime Tarih { get; set; }

        public List<OlayIhbar> OlayIhbarlar { get; set; }
    }
}
