﻿using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        Product GetProductByID(int id);
        void InsertProduct(Product pro);
        void DeleteProduct(int id);
        void UpdateProduct(Product pro);
    }
}
