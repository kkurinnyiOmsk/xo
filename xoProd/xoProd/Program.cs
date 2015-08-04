using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace xoProd
{
    class Program
    {
        static void Main(string[] args)
        {
            //todo добавить несколько игр подряд - турнир и вести статистику игр
            Game game1=new Game(new SimpleBotFactory());

            Console.ReadLine();
        }
    }
}
