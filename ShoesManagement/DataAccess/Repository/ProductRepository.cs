﻿using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProductByID(int id) => ProductDAO.Instance.GetProductByID(id);
        public void InsertProduct(Product pro) => ProductDAO.Instance.AddNew(pro);
        public void UpdateProduct(Product pro) => ProductDAO.Instance.Update(pro);
        public void DeleteProduct(int id) => ProductDAO.Instance.Remove(id);
    }
}
