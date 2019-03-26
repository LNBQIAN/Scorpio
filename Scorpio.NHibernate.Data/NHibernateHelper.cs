using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorpio.NHibernate.Data
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory == null ? (new Configuration()).Configure().BuildSessionFactory() : _sessionFactory;
            }
        }
    }
}
