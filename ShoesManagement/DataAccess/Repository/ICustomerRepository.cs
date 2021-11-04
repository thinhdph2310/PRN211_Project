using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomerByID(int id);
        void InsertCustomer(Customer cus);
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer cus);
    }
}
