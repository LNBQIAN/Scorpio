using Scorpio.NHibernate.Data;
using Scorpio.NHibernate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scorpio.NHibernate.Business
{
    public class CustomersBusiness
    {
        private CustomersData _customersData;
        public CustomersBusiness()
        {
            _customersData = new CustomersData();
        }

        public IList<Customers> GetCustomerList(Expression<Func<Customers, bool>> where)
        {
            return _customersData.GetCustomerList(where);
        }
    }
}
