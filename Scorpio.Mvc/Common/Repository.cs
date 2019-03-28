using Scorpio.Mvc.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web;

namespace Scorpio.Mvc.Common
{
    public class Repository<T> where T : class, IDisposable, new()
    {
        private readonly static DbContext _dbContext = new NorthwindEntities();

       /// <summary>
       /// 添加
       /// </summary>
       /// <param name="Entity"></param>
       /// <returns></returns>
        public bool Add(T Entity)
        {
            using (TransactionScope Ts = new TransactionScope(TransactionScopeOption.Required))
            {
                _dbContext.Set<T>().Add(Entity);
                int Count = _dbContext.SaveChanges();
                Ts.Complete();
                return Count > 0;
            }
        }
        //释放
        public void Dispose()
        {
            _dbContext.Dispose();
            //throw new NotImplementedException();
        }
    }
}