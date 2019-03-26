using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorpio.WCFService
{
    public class HelloService : IHelloService
    {
        public string SayHello(string name)
        {
            return "Hello " + name;
        }
    }
}
