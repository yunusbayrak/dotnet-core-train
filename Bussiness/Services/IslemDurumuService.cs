using System;
using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Business.Services.Bases;
using DataAccess.EntityFramework.Bases;
using Entity.Entities;

namespace Business.Services
{
    public class IslemDurumuService : IIslemDurumuService
    {
        private readonly IslemDurumuDalBase _islemDurumuDal;

        public IslemDurumuService(IslemDurumuDalBase islemDurumuDal)
        {
            _islemDurumuDal = islemDurumuDal;
        }

        public void AddIslemDurumu(IslemDurumuModel islemDurumu)
        {
            try
            {
                var islemDurumuEntity = new IslemDurumu
                {
                    Adi = islemDurumu.Adi
                };
                _islemDurumuDal.AddEntity(islemDurumuEntity);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void UpdateIslemDurumu(IslemDurumuModel islemDurumu)
        {
            try
            {
                var islemDurumuEntity = _islemDurumuDal.GetEntity(islemDurumu.Id);
                islemDurumuEntity.Adi = islemDurumu.Adi;
                _islemDurumuDal.UpdateEntity(islemDurumuEntity);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void DeleteIslemDurumu(int id)
        {
            try
            {
                _islemDurumuDal.DeleteEntity(id);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<IslemDurumuModel> GetIslemDurumlari()
        {
            try
            {
                var islemDurumlari = _islemDurumuDal.GetEntities().OrderBy(e => e.Adi).ToList();
                return islemDurumlari.Select(e => new IslemDurumuModel
                {
                    Id = e.Id,
                    Guid = e.Guid,
                    Adi = e.Adi
                }).ToList();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public bool IslemDurumuExists(IslemDurumuModel islemDurumu)
        {
            try
            {
                if (islemDurumu.Id == 0)
                    return _islemDurumuDal.EntityExists(e => e.Adi.ToLower() == islemDurumu.Adi.ToLower());
                return _islemDurumuDal.EntityExists(e => e.Adi.ToLower() == islemDurumu.Adi.ToLower() && e.Id != islemDurumu.Id);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public IslemDurumuModel GetIslemDurumu(int id)
        {
            try
            {
                var islemDurumu = _islemDurumuDal.GetEntity(id, "Faaliyetler");
                return new IslemDurumuModel
                {
                    Id = islemDurumu.Id,
                    Guid = islemDurumu.Guid,
                    Adi = islemDurumu.Adi,
                    FaaliyetSayisi = (islemDurumu.Faaliyetler == null || islemDurumu.Faaliyetler.Count == 0) ? 0 : islemDurumu.Faaliyetler.Count
                };
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
