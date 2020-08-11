using Core.Data.Bases;

namespace Business.Models.Filters
{
    public class IhbarFilterModel : BaseEntity
    {
        public int? IhbarDurumuId { get; set; }
        public string Ozet { get; set; }
        public string Yer { get; set; }
        public string TarihBaslangic { get; set; }
        public string TarihBitis { get; set; }
    }
}
