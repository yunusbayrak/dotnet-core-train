using System;
using Business.Models;
using Business.Services.Bases;
using DataAccess.EntityFramework.Bases;
using Entity.Entities;

namespace Business.Services
{
    public class RolService : IRolService
    {
        private readonly RolDalBase _rolDal;

        public RolService(RolDalBase rolDal)
        {
            _rolDal = rolDal;
        }

        public void AddRol(RolModel rol)
        {
			try
            {
                Rol rolEntity = new Rol
                {
                    Adi = rol.Adi
                };
                _rolDal.AddEntity(rolEntity);
            }
			catch (Exception exc)
			{
				throw exc;
			}
        }
    }
}
