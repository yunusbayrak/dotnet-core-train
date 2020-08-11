using DataAccess.EntityFramework.Bases;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class OlayIhbarDal : OlayIhbarDalBase
    {
        public OlayIhbarDal(DbContext context) : base(context)
        {

        }
    }
}
