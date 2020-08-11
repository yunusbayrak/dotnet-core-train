using Business.Services.Bases;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Models;
using DataAccess.EntityFramework.Bases;

namespace Business.Services
{
    public class IhbarDurumuService : IIhbarDurumuService
    {
        private readonly IhbarDurumuDalBase _ihbarDurumuDal;

        public IhbarDurumuService(IhbarDurumuDalBase ihbarDurumuDal)
        {
            _ihbarDurumuDal = ihbarDurumuDal;
        }

        public void AddIhbarDurumu(IhbarDurumu ihbarDurumu)
        {
            try
            {
                _ihbarDurumuDal.AddEntity(ihbarDurumu);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<IhbarDurumuModel> GetIhbarDurumlari()
        {
            try
            {
                return _ihbarDurumuDal.GetEntities().OrderBy(e => e.Adi).Select(e => new IhbarDurumuModel
                {
                    Id = e.Id,
                    Adi = e.Adi
                }).ToList();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
