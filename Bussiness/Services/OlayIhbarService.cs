using System;
using Business.Services.Bases;
using DataAccess.EntityFramework.Bases;
using Entity.Entities;

namespace Business.Services
{
    public class OlayIhbarService : IOlayIhbarService
    {
        private readonly OlayIhbarDalBase _olayIhbarDal;

        public OlayIhbarService(OlayIhbarDalBase olayIhbarDal)
        {
            _olayIhbarDal = olayIhbarDal;
        }

        public void AddOlayIhbar(OlayIhbar olayIhbar)
        {
            try
            {
                _olayIhbarDal.AddEntity(olayIhbar);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
