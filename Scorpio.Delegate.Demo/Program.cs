using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorpio.Delegate.Demo
{
    class Program
    {
        //Delegate至少0个参数，至多32个参数，可以无返回值，也可以指定返回值类型

        //Func可以接受0个至16个传入参数，必须具有返回值

        //Action可以接受0个至16个传入参数，无返回值
        //Delegate  Action Fun
        protected delegate int ClassDelegate(int x, int y);
        static void Main(string[] args)
        {
            var cd = new ClassDelegate(Add);
            cd(1, 2);


            Action<int, int> ac = new Action<int, int>(ShowAddResult);
            ac(1, 2);
            Action<int, int> ac2 = ((a, b) => Console.Write(a + b));
            ac2(1, 2);


            Action<string> ac3 = (p => Console.Write(p));
            Test(ac3, "参数");


            Func<string> fc1 = new Func<string>(ShowAddResult);//实例化一个委托
            string result = fc1();//调用委托



            //实例化一个委托,注意不加大括号，写的值就是返回值，不能带return
            Func<string> fc11 = () => "地球是圆的";

            //实例化另一个委托,注意加大括号后可以写多行代码，但是必须带return
            Func<string> fc2 = () =>
            {
                return "地球是圆的";
            };

            string result1 = fc11();//调用委托
            string result2 = fc2();//调用委托


            //实例化一个委托,注意不加大括号，写的值就是返回值，不能带return
            Func<int, string> fc12 = (p) => "传入参数" + p + ",地球是圆的";

            //实例化另一个委托,注意加大括号后可以写多行代码，但是必须带return
            Func<string, string> fc22 = (p) =>
            {
                return "传入参数" + p + ",地球是圆的";
            };

            string result12 = Test<int>(fc12, 1);//调用委托
            string result22 = Test<string>(fc22, "1");//调用委托





            Console.ReadKey();
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        //Action 可以传入参数，没有返回值的委托
        static void ShowAddResult(int a, int b)
        {
            //
        }

        static void Test<T>(Action<T> ac, T input)
        {
            ac(input);
        }





        //Fun
        static string ShowAddResult()
        {
            return "地球是圆的";
        }

        static string Test<T>(Func<T, string> fc, T inputParam)
        {
            return fc(inputParam);
        }
    }
}
