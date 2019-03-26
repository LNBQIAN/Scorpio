using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorpio.MyWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client _client = new ServiceReference1.Service1Client();
            _client.GetData(11); 
        }
    }
}
