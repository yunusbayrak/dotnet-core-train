using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Models;
using DataAccess.EntityFramework.Context;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    public class ContextController : Controller
    {
        private JkiContext _db;
        private readonly IMapper _mapper;
        public ContextController(DbContext db, IMapper mapper)
        {
            _db = db as JkiContext;
            _mapper = mapper;
        }
        public IActionResult Seed()
        {
            string message;

            try
            {
                //resetdb
                string sql = @"DELETE FROM IslemDurumu " +
                              "DELETE FROM Ihbar " +
                              "DELETE FROM IhbarDurumu " +
                              "DELETE FROM Faaliyet " +
                              "DELETE FROM OlayIhbar " +
                              "DELETE FROM Olay " +
                              "DELETE FROM Personel " +
                              "DELETE FROM Kullanici " +
                              "DELETE FROM Rol ";

                string sql2 = @"DBCC CHECKIDENT ('IslemDurumu', RESEED, 0) " +
                              "DBCC CHECKIDENT ('Ihbar', RESEED, 0) " +
                              "DBCC CHECKIDENT ('IhbarDurumu', RESEED, 0) " +
                              "DBCC CHECKIDENT ('Faaliyet', RESEED, 0) " +
                              "DBCC CHECKIDENT ('OlayIhbar', RESEED, 0) " +
                              "DBCC CHECKIDENT ('Olay', RESEED, 0) " +
                              "DBCC CHECKIDENT ('Personel', RESEED, 0) " +
                              "DBCC CHECKIDENT ('Kullanici', RESEED, 0) " +
                              "DBCC CHECKIDENT ('Rol', RESEED, 0)";

                _db.Database.ExecuteSqlRaw(sql);
                _db.Database.ExecuteSqlRaw(sql2);


                // lists:
                List<IhbarDurumu> ihbarDurumlari = new List<IhbarDurumu>
                {
                    new IhbarDurumu { Id = 1, Adi = "Açık" },
                    new IhbarDurumu { Id = 2, Adi = "Kapalı" }
                };

                List<OlayIhbar> olayIhbarlar = new List<OlayIhbar>
                {
                    new OlayIhbar { Id = 1, IhbarId = 1, OlayId = 1 },
                    new OlayIhbar { Id = 2, IhbarId = 2, OlayId = 2 },
                    new OlayIhbar { Id = 3, IhbarId = 2, OlayId = 3 },
                    new OlayIhbar { Id = 4, IhbarId = 3, OlayId = 4 }
                };

                List<Faaliyet> faaliyetler = new List<Faaliyet>
                {
                    new Faaliyet
                    {
                        Id = 1, Aciklama = "Şüpheli gözaltına alındı.", IhbarId = 1, IslemDurumuId = 1, PersonelId = 1, Tarih = DateTime.Parse("03.08.2020"), Yer = "Ankara"
                    },
                    new Faaliyet
                    {
                        Id = 2, Aciklama = "Şüpheli tutuklandı.", IhbarId = 1, IslemDurumuId = 2, PersonelId = 2, Tarih = DateTime.Parse("03.08.2020"), Yer = "Ankara"
                    },
                    new Faaliyet
                    {
                        Id = 3, Aciklama = "Şüpheli tutuklandı.", IhbarId = 2, IslemDurumuId = 2, PersonelId = 3, Tarih = DateTime.Parse("21.07.2020"), Yer = "İstanbul"
                    },
                    new Faaliyet
                    {
                        Id = 4, Aciklama = "Şüpheli gözaltına alındı.", IhbarId = 3, IslemDurumuId = 1, PersonelId = 1, Tarih = DateTime.Parse("01.08.2020"), Yer = "İzmir"
                    },
                    new Faaliyet
                    {
                        Id = 5, Aciklama = "Şüpheli serbest bırakıldı.", IhbarId = 3, IslemDurumuId = 3, PersonelId = 1, Tarih = DateTime.Parse("02.08.2020"), Yer = "İzmir"
                    }
                };

                List<PersonelModel> personeller = new List<PersonelModel>
                {
                    new PersonelModel
                    {
                        Id = 1,
                        AdSoyad = "Ali Tan"
                    },
                    new PersonelModel
                    {
                        Id = 2,
                        AdSoyad = "Zeki Kılıç"
                    },
                    new PersonelModel
                    {
                        Id = 3,
                        AdSoyad = "Ayşe Yılmaz"
                    },
                    new PersonelModel
                    {
                        Id = 4,
                        AdSoyad = "Metin Öztürk"
                    },
                    new PersonelModel
                    {
                        Id = 5,
                        AdSoyad = "Zeynep Kaya"
                    }
                };

                List<IhbarModel> ihbarlar = new List<IhbarModel>
                {
                    new IhbarModel
                    {
                        Id = 1, IhbarDurumuId = 1, Ozet = "Araba Kaçırma", Tarih = DateTime.Parse("03.08.2020"), Yer = "Ankara"
                    },
                    new IhbarModel
                    {
                        Id = 2, IhbarDurumuId = 2, Ozet = "Adam Öldürme", Tarih = DateTime.Parse("20.07.2020"), Yer = "İstanbul"
                    },
                    new IhbarModel
                    {
                        Id = 3, IhbarDurumuId = 1, Ozet = "Trafik Kuralları Çiğneme", Tarih = DateTime.Parse("01.08.2020"), Yer = "İzmir"
                    }
                };

                List<OlayModel> olaylar = new List<OlayModel>
                {
                    new OlayModel
                    {
                        Id = 1, IlkNeden = "Parasızlık", OlusSekli = "Şüpheli komşusunun arabasını çaldı.", Tarih = DateTime.Parse("02.08.2020"), Yer = "Ankara"
                    },
                    new OlayModel
                    {
                        Id = 2, IlkNeden = "Anlaşamama", OlusSekli = "Şüpheli arkadaşıyla tartıştı.", Tarih = DateTime.Parse("17.07.2020"), Yer = "İstanbul"
                    },
                    new OlayModel
                    {
                        Id = 3, OlusSekli = "Şüpheli arkadaşını bıçakladı.", Tarih = DateTime.Parse("18.07.2020"), Yer = "İstanbul"
                    },
                    new OlayModel
                    {
                        Id = 4, IlkNeden = "Alkollü araba kullanma", OlusSekli = "Şüpheli alkol alarak hız kurallarını çiğnedi.", Tarih = DateTime.Parse("01.08.2020"), Yer = "İzmir"
                    }
                };

                List<IslemDurumuModel> islemDurumlari = new List<IslemDurumuModel>
                {
                    new IslemDurumuModel
                    {
                        Id = 1, Adi = "Gözaltı"
                    },
                    new IslemDurumuModel
                    {
                        Id = 2, Adi = "Tutuklama"
                    },
                    new IslemDurumuModel
                    {
                        Id = 3, Adi = "Serbest bırakma"
                    }
                };

                List<KullaniciModel> kullanicilar = new List<KullaniciModel>
                {
                    new KullaniciModel
                    {
                        Id = 1,
                        KullaniciAdi = "cagil",
                        Sifre = "123",
                        Aktif = true,
                        RolId = 1
                    },
                    new KullaniciModel
                    {
                        Id = 2,
                        KullaniciAdi = "ali",
                        Sifre = "321",
                        Aktif = true,
                        RolId = 2,
                        PersonelId = 1
                    }
                };

                List<RolModel> roller = new List<RolModel>
                {
                    new RolModel
                    {
                        Id = 1,
                        Adi = "Admin"
                    },
                    new RolModel
                    {
                        Id = 2,
                        Adi = "Kullanici"
                    }
                };
                // context update:
                foreach (var islemDurumu in islemDurumlari)
                {
                    islemDurumu.Id = 0;
                    _db.IslemDurumu.Add(_mapper.Map<IslemDurumu>(islemDurumu));
                }

                foreach (var ihbarDurumu in ihbarDurumlari)
                {
                    ihbarDurumu.Id = 0;
                    _db.IhbarDurumu.Add(ihbarDurumu);
                }
                _db.SaveChanges();

                foreach (var personel in personeller)
                {
                    personel.Id = 0;
                    _db.Personel.Add(_mapper.Map<Personel>(personel));
                }

                foreach (var ihbar in ihbarlar)
                {
                    ihbar.Id = 0;
                    _db.Ihbar.Add(_mapper.Map<Ihbar>(ihbar));
                }
                _db.SaveChanges();

                foreach (var olay in olaylar)
                {
                    olay.Id = 0;
                    _db.Olay.Add(_mapper.Map<Olay>(olay));
                }

                foreach (var faaliyet in faaliyetler)
                {
                    faaliyet.Id = 0;
                    _db.Faaliyet.Add(faaliyet);
                }
                _db.SaveChanges();

                foreach (var olayIhbar in olayIhbarlar)
                {
                    olayIhbar.Id = 0;
                    _db.OlayIhbar.Add(olayIhbar);
                }

                foreach (var rol in roller)
                {
                    rol.Id = 0;
                    _db.Rol.Add(_mapper.Map<Rol>(rol));
                }
                _db.SaveChanges();

                foreach (var kullanici in kullanicilar)
                {
                    kullanici.Id = 0;
                    _db.Kullanici.Add(_mapper.Map<Kullanici>(kullanici));
                }
                //_db.ChangeTracker.AutoDetectChangesEnabled = false;
                _db.SaveChanges();
                message = "Veriler oluşturuldu!";
            }
            catch (Exception exc)
            {
                message = "Veriler oluşturulurken hata meydana geldi: " + exc.Message + ": " + exc.InnerException?.Message;
            }

            return View("Seed", message);
        }
    }
}
