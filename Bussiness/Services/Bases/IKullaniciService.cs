using Business.Models;

namespace Business.Services.Bases
{
    public interface IKullaniciService
    {
        void AddKullanici(KullaniciModel kullanici);
        KullaniciModel GetKullanici(string kullanciAdi, string sifre);
        bool KullaniciExists(KullaniciModel kullanici);
        bool PersonelExists(KullaniciModel kullanici);
    }
}
