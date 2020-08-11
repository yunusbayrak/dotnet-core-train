using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Data.Bases
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Guid { get; set; }
    }
}
