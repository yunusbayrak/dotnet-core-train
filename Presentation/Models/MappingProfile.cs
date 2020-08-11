using AutoMapper;
using Business.Models;
using Entity.Entities;

namespace Presentation.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Rol, RolModel>();
            CreateMap<IslemDurumu, IslemDurumuModel>();
            CreateMap<Kullanici, KullaniciModel>();
            CreateMap<Olay, OlayModel>();
            CreateMap<Ihbar, IhbarModel>();
            CreateMap<Personel, PersonelModel>();

            CreateMap<RolModel, Rol>();
            CreateMap<IslemDurumuModel, IslemDurumu>();
            CreateMap<KullaniciModel, Kullanici>();
            CreateMap<OlayModel, Olay>();
            CreateMap<IhbarModel, Ihbar>();
            CreateMap<PersonelModel, Personel>();
        }
    }
}
