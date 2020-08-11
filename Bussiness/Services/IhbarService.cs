using Business.Models;
using Business.Models.Filters;
using Business.Services.Bases;
using DataAccess.EntityFramework.Bases;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class IhbarService : IIhbarService
    {
        private readonly IhbarDalBase _ihbarDal;
        private readonly OlayIhbarDalBase _olayIhbarDal;

        public IhbarService(IhbarDalBase ihbarDal, OlayIhbarDalBase olayIhbarDal)
        {
            _ihbarDal = ihbarDal;
            _olayIhbarDal = olayIhbarDal;
        }

        public bool AddIhbar(IhbarModel ihbar, bool seedContext = false)
        {
            try
            {
                Ihbar ihbarEntity = new Ihbar
                {
                    IhbarDurumuId = ihbar.IhbarDurumuId.Value,
                    Ozet = ihbar.Ozet,
                    Yer = ihbar.Yer,
                    Tarih = ihbar.Tarih.Value
                };
                _ihbarDal.AddEntity(ihbarEntity);
                ihbar.Id = ihbarEntity.Id;
                if (!seedContext)
                {
                    AddOlayIhbarlar(ihbar);
                }
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        public bool UpdateIhbar(IhbarModel ihbar)
        {
            try
            {
                var ihbarEntity = _ihbarDal.GetEntity(ihbar.Id);
                ihbarEntity.IhbarDurumuId = ihbar.IhbarDurumuId.Value;
                ihbarEntity.Ozet = ihbar.Ozet;
                ihbarEntity.Yer = ihbar.Yer;
                ihbarEntity.Tarih = ihbar.Tarih.Value;
                _ihbarDal.UpdateEntity(ihbarEntity);
                UpdateOlayIhbarlar(ihbar);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        public bool DeleteIhbar(int id)
        {
            try
            {
                DeleteOlayIhbarlar(id);
                _ihbarDal.DeleteEntity(id);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        private void UpdateOlayIhbarlar(IhbarModel ihbar)
        {
            DeleteOlayIhbarlar(ihbar.Id);
            AddOlayIhbarlar(ihbar);
        }

        private void AddOlayIhbarlar(IhbarModel ihbar)
        {
            List<OlayIhbar> olayIhbarlar;
            OlayIhbar olayIhbarEntity;
            int sira;
            if (ihbar.OlayIdleri != null && ihbar.OlayIdleri.Count > 0)
            {
                foreach (var olayId in ihbar.OlayIdleri)
                {
                    sira = 1;
                    olayIhbarlar = _olayIhbarDal.GetEntities(e => e.IhbarId == ihbar.Id).ToList();

                    olayIhbarEntity = new OlayIhbar
                    {
                        OlayId = olayId,
                        IhbarId = ihbar.Id
                    };
                    _olayIhbarDal.AddEntity(olayIhbarEntity);
                }
            }
        }

        private void DeleteOlayIhbarlar(int ihbarId)
        {
            List<OlayIhbar> olayIhbarlar = _olayIhbarDal.GetEntities(e => e.IhbarId == ihbarId).ToList();
            if (olayIhbarlar != null && olayIhbarlar.Count > 0)
            {
                _olayIhbarDal.Commit = false;
                foreach (var olayIhbar in olayIhbarlar)
                {
                    _olayIhbarDal.DeleteEntity(olayIhbar);
                }
                _olayIhbarDal.SaveChanges();
            }
        }

        public List<IhbarModel> GetIhbarlar()
        {
            try
            {
                List<IhbarModel> ihbarlar = _ihbarDal.Include(x=>x.IhbarDurumu).OrderBy(i => i.Tarih).ThenBy(i => i.Yer).Select(i => new IhbarModel
                {
                    Id = i.Id,
                    Guid = i.Guid,
                    Ozet = i.Ozet,
                    Tarih = i.Tarih,
                    Yer = i.Yer,
                    IhbarDurumuId = i.IhbarDurumuId,
                    IhbarDurumu = i.IhbarDurumu.Adi
                }).ToList();
                return ihbarlar;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<IhbarModel> GetIhbarlar(IhbarFilterModel filter)
        {
            try
            {
                var query = _ihbarDal.GetEntityQuery("IhbarDurumu", "OlayIhbarlar");
                if (filter.Id != 0)
                    query = query.Where(e => e.Id == filter.Id);
                if (filter.IhbarDurumuId.HasValue)
                    query = query.Where(e => e.IhbarDurumuId == filter.IhbarDurumuId.Value);
                if (!String.IsNullOrWhiteSpace(filter.Ozet))
                    query = query.Where(e => e.Ozet.ToLower().Contains(filter.Ozet.ToLower().Trim()));
                if (!String.IsNullOrWhiteSpace(filter.Yer))
                    query = query.Where(e => e.Yer.ToLower().Contains(filter.Yer.ToLower().Trim()));
                if (!String.IsNullOrWhiteSpace(filter.TarihBaslangic))
                {
                    var value = DateTime.Parse(filter.TarihBaslangic + " 00:00:00");
                    query = query.Where(e => e.Tarih >= value);
                }
                if (!String.IsNullOrWhiteSpace(filter.TarihBitis))
                {
                    var value = DateTime.Parse(filter.TarihBitis + " 23:59:59");
                    query = query.Where(e => e.Tarih <= value);
                }
                var ihbarlar = query.Select(i => new IhbarModel
                {
                    Id = i.Id,
                    Guid = i.Guid,
                    Ozet = i.Ozet,
                    Yer = i.Yer,
                    Tarih = i.Tarih,
                    TarihText = i.Tarih.ToShortDateString() + " " + i.Tarih.ToLongTimeString(),
                    IhbarDurumuId = i.IhbarDurumuId,
                    IhbarDurumu = i.IhbarDurumu.Adi,
                    OlayIdleri = (i.OlayIhbarlar == null || i.OlayIhbarlar.Count == 0)
                        ? null
                        : i.OlayIhbarlar.Select(oi => oi.OlayId).ToList()
                }).ToList();
                return ihbarlar;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        public IhbarModel GetIhbar(int id)
        {
            try
            {
                var ihbarEntity = _ihbarDal.GetEntity(id, "IhbarDurumu", "OlayIhbarlar");
                var ihbar = new IhbarModel();
                ihbar.Id = ihbarEntity.Id;
                ihbar.Guid = ihbarEntity.Guid;
                ihbar.Ozet = ihbarEntity.Ozet;
                ihbar.Yer = ihbarEntity.Yer;
                ihbar.Tarih = ihbarEntity.Tarih;
                ihbar.TarihText = ihbarEntity.Tarih.ToShortDateString() + " " + ihbarEntity.Tarih.ToLongTimeString();
                ihbar.IhbarDurumuId = ihbarEntity.IhbarDurumuId;
                ihbar.IhbarDurumu = ihbarEntity.IhbarDurumu.Adi;
                ihbar.OlayIdleri = (ihbarEntity.OlayIhbarlar == null || ihbarEntity.OlayIhbarlar.Count == 0)
                    ? null
                    : ihbarEntity.OlayIhbarlar.Select(e => e.OlayId).ToList();
                return ihbar;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}
