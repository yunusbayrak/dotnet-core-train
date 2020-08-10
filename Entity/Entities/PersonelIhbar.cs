using Core.Data.Bases;

namespace Entity.Entities
{
    public class PersonelIhbar : BaseEntity
    {
        public int PersonelId { get; set; }
        public int IhbarId { get; set; }
        public Personel Personel { get; set; }
        public Ihbar Ihbar { get; set; }
    }
}
