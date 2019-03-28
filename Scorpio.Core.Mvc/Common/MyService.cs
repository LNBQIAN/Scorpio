using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scorpio.Core.Mvc.Common
{
    public class MyService : IMyService
    {
        public string GetString()
        {
            return "自定义服务";
        }
    }

    public static class MyServiceExtensions
    {
        public static void AddMyService(this IServiceCollection services)
        {
        //1、Transient：每次从容器 （IServiceProvider）中获取的时候都是一个新的实例

        //2、Singleton：每次从同根容器中（同根 IServiceProvider）获取的时候都是同一个实例

        //3、Scoped：每次从同一个容器中获取的实例是相同的、
            services.AddScoped<IMyService, MyService>();
            
        }
    }
}
