using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        Order GetOrderByID(int id);
        void InsertOrder(Order order);
        void DeleteOrder(int id);
        void UpdateOrder(Order order);
    }
}
