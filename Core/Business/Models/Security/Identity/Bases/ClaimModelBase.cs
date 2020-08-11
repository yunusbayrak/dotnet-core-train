using Core.Data.Bases;

namespace Core.Business.Models.Security.Identity.Bases
{
    public abstract class ClaimModelBase : BaseEntity
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
