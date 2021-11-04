using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomerByID(int id) => CustomerDAO.Instance.GetCustomerByID(id);
        public void InsertCustomer(Customer cus) => CustomerDAO.Instance.AddNew(cus);
        public void UpdateCustomer(Customer cus) => CustomerDAO.Instance.Update(cus);
        public void DeleteCustomer(int id) => CustomerDAO.Instance.Remove(id);
    }
}
