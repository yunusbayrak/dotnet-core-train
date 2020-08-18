using Business.Models;
using Business.Services.Bases;
using Core.DataAccess.EntityFramework.Bases;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ContextController : ControllerBase
    {
        private readonly IFaaliyetService _faaliyetService;
        private readonly IIhbarService _ihbarService;
        private readonly IIhbarDurumuService _ihbarDurumuService;
        private readonly IIslemDurumuService _islemDurumuService;
        private readonly IOlayService _olayService;
        private readonly IOlayIhbarService _olayIhbarService;
        private readonly IPersonelService _personelService;
        private readonly IKullaniciService _kullaniciService;
        private readonly IRolService _rolService;
        private readonly SqlBase _sql;

        public ContextController(IFaaliyetService faaliyetService, IIhbarService ihbarService, IIhbarDurumuService ihbarDurumuService, IIslemDurumuService islemDurumuService,
            IOlayService olayService, IOlayIhbarService olayIhbarService, IPersonelService personelService, 
            IKullaniciService kullaniciService, IRolService rolService, SqlBase sql)
        {
            _faaliyetService = faaliyetService;
            _ihbarService = ihbarService;
            _ihbarDurumuService = ihbarDurumuService;
            _islemDurumuService = islemDurumuService;
            _olayService = olayService;
            _olayIhbarService = olayIhbarService;
            _personelService = personelService;
            _kullaniciService = kullaniciService;
            _rolService = rolService;
            _sql = sql;
        }

        [HttpGet("Seed")]
        public IActionResult Seed()
        {
            string message;
            try
            {
                // database clear:
                _sql.ExecuteSql("delete from Faaliyet");
                _sql.ExecuteSql("delete from OlayIhbar");
                _sql.ExecuteSql("delete from IslemDurumu");
                _sql.ExecuteSql("delete from Ihbar");
                _sql.ExecuteSql("delete from IhbarDurumu");
                _sql.ExecuteSql("delete from Olay");
                _sql.ExecuteSql("delete from Kullanici");
                _sql.ExecuteSql("delete from Rol");
                _sql.ExecuteSql("delete from Personel");

                _sql.ExecuteSql("DBCC CHECKIDENT ('Kullanici', RESEED, 0)");
                _sql.ExecuteSql("DBCC CHECKIDENT ('Rol', RESEED, 0)");
                _sql.ExecuteSql("DBCC CHECKIDENT ('Personel', RESEED, 0)");
                _sql.ExecuteSql("DBCC CHECKIDENT ('Faaliyet', RESEED, 0)");
                _sql.ExecuteSql("DBCC CHECKIDENT ('IslemDurumu', RESEED, 0)");
                _sql.ExecuteSql("DBCC CHECKIDENT ('Olay', RESEED, 0)");
                _sql.ExecuteSql("DBCC CHECKIDENT ('Ihbar', RESEED, 0)");
                _sql.ExecuteSql("DBCC CHECKIDENT ('OlayIhbar', RESEED, 0)");
                _sql.ExecuteSql("DBCC CHECKIDENT ('IhbarDurumu', RESEED, 0)");

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
                    _islemDurumuService.AddIslemDurumu(islemDurumu);
                }

                foreach (var ihbarDurumu in ihbarDurumlari)
                {
                    ihbarDurumu.Id = 0;
                    _ihbarDurumuService.AddIhbarDurumu(ihbarDurumu);
                }

                foreach (var personel in personeller)
                {
                    personel.Id = 0;
                    _personelService.AddPersonel(personel);
                }

                foreach (var ihbar in ihbarlar)
                {
                    ihbar.Id = 0;
                    _ihbarService.AddIhbar(ihbar);
                }

                foreach (var olay in olaylar)
                {
                    olay.Id = 0;
                    _olayService.AddOlay(olay, true);
                }

                foreach (var faaliyet in faaliyetler)
                {
                    faaliyet.Id = 0;
                    _faaliyetService.AddFaaliyet(faaliyet);
                }

                foreach (var olayIhbar in olayIhbarlar)
                {
                    olayIhbar.Id = 0;
                    _olayIhbarService.AddOlayIhbar(olayIhbar);
                }

                foreach (var rol in roller)
                {
                    rol.Id = 0;
                    _rolService.AddRol(rol);
                }

                foreach (var kullanici in kullanicilar)
                {
                    kullanici.Id = 0;
                    _kullaniciService.AddKullanici(kullanici);
                }

                message = "Veriler oluşturuldu!";
            }
            catch (Exception exc)
            {
                message = "Veriler oluşturulurken hata meydana geldi: " + exc.Message + ": " + exc.InnerException?.Message;
            }

            return Ok(message);
        }
    }
}