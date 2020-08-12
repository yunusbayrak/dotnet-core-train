using Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Models
{
    public class KullaniciRegisterViewModel
    {
        public KullaniciModel Kullanici { get; set; }
        public SelectList Personeller { get; set; }
    }
}
