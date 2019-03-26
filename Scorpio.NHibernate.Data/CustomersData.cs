using NHibernate;
using Scorpio.NHibernate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scorpio.NHibernate.Data
{
    public class CustomersData
    {
        public IList<Customers> GetCustomerList(Expression<Func<Customers, bool>> where)
        {

            try
            {
                using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
                {
                    return session.Query<Customers>().Where(where).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Customers GetModel(string Id)
        {
            try
            {
                using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
                {
                    return session.Get<Customers>(Id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Insert(Customers customer)
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var res = session.Save(customer);
                session.Flush();
                return string.IsNullOrEmpty(res.ToString());
            }
        }
        public void Update(Customers customer)
        {
            using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                session.SaveOrUpdate(customer);
                session.Flush();
            }
        }

        public void Delete(string Id)
        {
            try
            {
                using (ISession session = NHibernateHelper.SessionFactory.OpenSession())
                {
                    var model = session.Get<Customers>(Id);
                    session.Delete(model);
                    session.Flush();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
