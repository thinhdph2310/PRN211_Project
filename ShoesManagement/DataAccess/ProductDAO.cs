﻿using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public Product GetProductByID(int id)
        {
            Product pro = null;
            try
            {
                using var context = new ShoeManagementContext();
                pro = context.Products.SingleOrDefault(pro => pro.ProductId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return pro;
        }

        public void AddNew(Product pro)
        {
            try
            {
                Product result = GetProductByID(pro.ProductId);
                if (result == null)
                {
                    using var context = new ShoeManagementContext();
                    context.Products.Add(pro);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Product pro)
        {
            try
            {
                Product result = GetProductByID(pro.ProductId);
                if (result != null)
                {
                    using var context = new ShoeManagementContext();
                    context.Products.Update(pro);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product does not already exist");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remove(int id)
        {
            try
            {
                Product result = GetProductByID(id);
                if (result != null)
                {
                    using var context = new ShoeManagementContext();
                    context.Products.Remove(result);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
