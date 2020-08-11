using System;
using Business.Models;
using Business.Services.Bases;
using DataAccess.EntityFramework.Bases;
using Entity.Entities;

namespace Business.Services
{
    public class KullaniciService : IKullaniciService
    {
        private readonly KullaniciDalBase _kullaniciDal;

        public KullaniciService(KullaniciDalBase kullaniciDal)
        {
            _kullaniciDal = kullaniciDal;
        }

        public void AddKullanici(KullaniciModel kullanici)
        {
			try
            {
                Kullanici kullaniciEntity = new Kullanici
                {
                    KullaniciAdi = kullanici.KullaniciAdi,
                    Sifre = kullanici.Sifre,
                    Aktif = kullanici.Aktif,
                    PersonelId = kullanici.PersonelId,
                    RolId = kullanici.RolId
                };
                _kullaniciDal.AddEntity(kullaniciEntity);
			}
			catch (Exception exc)
			{
				throw exc;
			}
        }

        public KullaniciModel GetKullanici(string kullaniciAdi, string sifre)
        {
            try
            {
                Kullanici kullaniciEntity = _kullaniciDal.GetEntity(e => e.KullaniciAdi == kullaniciAdi && e.Sifre == sifre && e.Aktif, "Rol", "Personel");
                KullaniciModel kullanici = null;
                if (kullaniciEntity != null)
                {
                    kullanici = new KullaniciModel
                    {
                        Id = kullaniciEntity.Id,
                        Guid = kullaniciEntity.Guid,
                        KullaniciAdi = kullaniciEntity.KullaniciAdi,
                        Sifre = kullaniciEntity.Sifre,
                        Aktif = kullaniciEntity.Aktif,
                        PersonelId = kullaniciEntity.PersonelId,
                        Personel = kullaniciEntity.Personel == null
                            ? null
                            : new PersonelModel
                            {
                                Id = kullaniciEntity.Personel.Id,
                                Guid = kullaniciEntity.Personel.Guid,
                                AdSoyad = kullaniciEntity.Personel.AdSoyad
                            },
                        RolId = kullaniciEntity.RolId,
                        Rol = new RolModel
                        {
                            Id = kullaniciEntity.Rol.Id,
                            Guid = kullaniciEntity.Rol.Guid,
                            Adi = kullaniciEntity.Rol.Adi
                        }
                    };
                }
                return kullanici;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public bool KullaniciExists(KullaniciModel kullanici)
        {
            try
            {
                return _kullaniciDal.EntityExists(e => e.KullaniciAdi.ToLower().Equals(kullanici.KullaniciAdi.ToLower().Trim()));
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public bool PersonelExists(KullaniciModel kullanici)
        {
            try
            {
                if (kullanici.PersonelId.HasValue)
                    return _kullaniciDal.EntityExists(e => e.PersonelId == kullanici.PersonelId.Value);
                return false;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
