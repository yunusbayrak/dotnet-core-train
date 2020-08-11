using System.Collections.Generic;
using Business.Models;
using Entity.Entities;

namespace Business.Services.Bases
{
    public interface IIhbarDurumuService
    {
        void AddIhbarDurumu(IhbarDurumu ihbarDurumu);
        List<IhbarDurumuModel> GetIhbarDurumlari();
    }
}
