using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    class Program
    {
        private static Object syncObject = new Object();

        private static void Write()
        {
            lock (syncObject)
            {
                Console.WriteLine("test");
            }
        }
        static void Main(string[] args)
        {
            lock (syncObject)
            {
                Write();
            }
            Console.ReadLine();
        }
    }
}
