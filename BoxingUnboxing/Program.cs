using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Console.ReadLine();
        }

        static void Task1()
        {
            int i = 1;
            object obj = i;
            ++i;
            Console.WriteLine(i);
            Console.WriteLine(obj);
            try
            {
                // Распаковать можно только в тот же тип -> ошибка
                Console.WriteLine((short)obj);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
