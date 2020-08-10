using Core.Data.Bases;

namespace Entity.Entities
{
    public class OlayIhbar : BaseEntity
    {
        public int OlayId { get; set; }
        public int IhbarId { get; set; }
        public Olay Olay { get; set; }
        public Ihbar Ihbar { get; set; }
    }
}
