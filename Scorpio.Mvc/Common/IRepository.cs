using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scorpio.Mvc.Common
{
    public interface IRepository<T> where T:class,new()
    {
        void GetModels(Expression<Func<T, bool>> whereLambda);
    }
}
