using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urge.Service.Http;

namespace Urge.ListenerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StateListener.Start(8089);
            Console.ReadLine();
        }
    }
}
