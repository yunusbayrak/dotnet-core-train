using System.Collections.Generic;
using Business.Models;

namespace Business.Services.Bases
{
    public interface IPersonelService
    {
        void AddPersonel(PersonelModel personel);
        List<PersonelModel> GetPersoneller();
    }
}
