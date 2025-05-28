﻿using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _cargoContext;

        public GenericRepository(CargoContext cargoContext)
        {
            _cargoContext = cargoContext;
        }

        public void Delete(int id)
        {
            var value = _cargoContext.Set<T>().Find(id);
            _cargoContext.Set<T>().Remove(value);
            _cargoContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            var values = _cargoContext.Set<T>().ToList();
            return values;
        }

        public T GetById(int id)
        {
            var value = _cargoContext.Set<T>().Find(id);
            return value;
        }

        public void Insert(T entity)
        {
            _cargoContext.Set<T>().Add(entity);
            _cargoContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _cargoContext.Set<T>().Update(entity);
            _cargoContext.SaveChanges();
        }
    }
}
