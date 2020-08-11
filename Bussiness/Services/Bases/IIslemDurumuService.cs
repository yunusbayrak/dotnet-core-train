using System.Collections.Generic;
using Business.Models;
using Entity.Entities;

namespace Business.Services.Bases
{
    public interface IIslemDurumuService
    {
        void AddIslemDurumu(IslemDurumuModel islemDurumu);
        void UpdateIslemDurumu(IslemDurumuModel islemDurumu);
        void DeleteIslemDurumu(int id);
        List<IslemDurumuModel> GetIslemDurumlari();
        IslemDurumuModel GetIslemDurumu(int id);
        bool IslemDurumuExists(IslemDurumuModel islemDurumu);
    }
}
