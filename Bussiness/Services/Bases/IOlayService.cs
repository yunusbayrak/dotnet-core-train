using Business.Models;
using System.Collections.Generic;

namespace Business.Services.Bases
{
    public interface IOlayService
    {
        List<OlayModel> GetOlaylar();
        OlayModel GetOlay(int id);
        void AddOlay(OlayModel olay, bool seedContext = false);
        void UpdateOlay(OlayModel olay);
        void DeleteOlay(int id);
    }
}
