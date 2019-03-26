using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Scorpio.WCFService
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string SayHello(string name);
    }
}
