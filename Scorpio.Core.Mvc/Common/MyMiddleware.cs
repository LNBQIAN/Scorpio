using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scorpio.Core.Mvc.Common
{
    public class MyMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;
        //需要实现一个构造函数,参数为 RequestDelegate
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        //需要实现一个叫做 InvokeAsync 方法
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //throw new NotImplementedException();
            // 这里不对 request 做任何处理,直接调用下一个中间件
            await next(context);
        }
    }
}
