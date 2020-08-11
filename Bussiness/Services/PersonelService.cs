using System;
using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Business.Services.Bases;
using DataAccess.EntityFramework.Bases;
using Entity.Entities;

namespace Business.Services
{
    public class PersonelService : IPersonelService
    {
        private readonly PersonelDalBase _personelDal;

        public PersonelService(PersonelDalBase personelDal)
        {
            _personelDal = personelDal;
        }

        public void AddPersonel(PersonelModel personel)
        {
            try
            {
                var personelEntity = new Personel
                {
                    AdSoyad = personel.AdSoyad
                };
                _personelDal.AddEntity(personelEntity);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<PersonelModel> GetPersoneller()
        {
            try
            {
                return _personelDal.GetEntities().OrderBy(e => e.AdSoyad).Select(e => new PersonelModel
                {
                    Id = e.Id,
                    Guid = e.Guid,
                    AdSoyad = e.AdSoyad
                }).ToList();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
