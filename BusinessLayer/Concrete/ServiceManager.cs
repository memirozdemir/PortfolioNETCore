﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;
        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void TAdd(Service t)
        {
            _serviceDal.Insert(t);
        }

        public List<Service> TGetByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public Service TGetByID(int id)
        {
            return _serviceDal.GetByID(id);
        }

        public List<Service> TGetList()
        {
            return _serviceDal.GetList();
        }

        public void TRemove(Service t)
        {
            _serviceDal.Delete(t);
        }

        public void TUpdate(Service t)
        {
            _serviceDal.Update(t);
        }
    }
}
