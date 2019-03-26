using Scorpio.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Scorpio.WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HelloProxy proxy = new HelloProxy())
            {
                //利用代理调用方法  
                Console.WriteLine(proxy.Say("郑少秋"));
                Console.ReadLine();
            }
        }
    }

    [ServiceContract]
    interface IService
    {
        [OperationContract]
        string Say(string name);
    }

    class HelloProxy : ClientBase<IHelloService>, IService
    {
        public static readonly Binding HelloBinding = new NetNamedPipeBinding();  //硬编码定义绑定  
        //硬编码定义地址 注意：这里要和之前服务定义的地址保持一直  
        public static readonly EndpointAddress HelloAddress = new EndpointAddress(new Uri("net.pipe://localhost/Hello"));
        public HelloProxy() : base(HelloBinding, HelloAddress) { } //构造方法  

        public string Say(string name)
        {
            return Channel.SayHello(name);
        }
    }
}
