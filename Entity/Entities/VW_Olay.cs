using Core.Data.Bases;
using System;

namespace Entity.Entities
{
    public class VW_Olay : BaseEntity
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public long Id { get; set; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public string Guid { get; set; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        public int? OlayId { get; set; }
        public string IlkNeden { get; set; }
        public string OlusSekli { get; set; }
        public string Yer { get; set; }
        public DateTime Tarih { get; set; }
        public int? IhbarId { get; set; }
        public string IhbarOzeti { get; set; }
    }
}
