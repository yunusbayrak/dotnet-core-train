using System;
using Business.Services.Bases;
using DataAccess.EntityFramework.Bases;
using Entity.Entities;

namespace Business.Services
{
    public class FaaliyetService : IFaaliyetService
    {
        private readonly FaaliyetDalBase _faaliyetDal;

        public FaaliyetService(FaaliyetDalBase faaliyetDal)
        {
            _faaliyetDal = faaliyetDal;
        }

        public void AddFaaliyet(Faaliyet faaliyet)
        {
			try
			{
                _faaliyetDal.AddEntity(faaliyet);
			}
			catch (Exception exc)
			{
				throw exc;
			}
        }
    }
}
