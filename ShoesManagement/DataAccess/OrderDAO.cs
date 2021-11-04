using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public Order GetOrderByID(int id)
        {
            Order order = null;
            try
            {
                using var context = new ShoeManagementContext();
                order = context.Orders.SingleOrDefault(order => order.OrderId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public void AddNew(Order order)
        {
            try
            {
                Order result = GetOrderByID(order.OrderId);
                if (result == null)
                {
                    using var context = new ShoeManagementContext();
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Order is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Order order)
        {
            try
            {
                Order result = GetOrderByID(order.OrderId);
                if (result != null)
                {
                    using var context = new ShoeManagementContext();
                    context.Orders.Update(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Order does not already exist");
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
                Order result = GetOrderByID(id);
                if (result != null)
                {
                    using var context = new ShoeManagementContext();
                    context.Orders.Remove(result);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Order does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
