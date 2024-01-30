﻿using BusinessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IRepository<T> where T : AEntity
    {
        public IEnumerable<T> GetAll();

        public IEnumerable<T> Get(int id);
    }
}