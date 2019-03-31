using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    #region AA, BB
    public class AA
    {
        public AA()
        {
            Console.WriteLine("Конструктор класса AA");
        }

        public virtual void Print()
        {
            Console.WriteLine("Class AA");
        }
    }

    public class BB : AA
    {
        public BB()
        {
            Console.WriteLine("Конструктор класса BB");
        }

        public override void Print()
        {
            Console.WriteLine("Class BB");
        }
    }
    #endregion

    #region A, B, C
    public class A
    {
        public A()
        {
            Console.WriteLine("Конструктор класса A без параметров");
        }

        public A(object a, object b)
        {
            Console.WriteLine("Конструктор класса A c параметрами a,b");
        }

        public A(object a, object b, object c)
        {
            Console.WriteLine("Конструктор класса A c параметрами a,b,c");
        }

        public virtual void Print1()
        {
            Console.WriteLine("A");
        }

        public void Print2()
        {
            Console.WriteLine("A");
        }
    }

    public class B : A
    {
        public B()
        {
            Console.WriteLine("Конструктор класса B без параметров");
        }

        public B(object a, object b)
        {
            Console.WriteLine("Конструктор класса B c параметрами a,b");
        }

        public B(object a, object b, object c) :
            base(a, b, c)
        {
            Console.WriteLine("Конструктор класса B c параметрами a,b,c");
        }

        public override void Print1()
        {
            Console.WriteLine("B");
        }
    }

    public class C : B
    {
        public C()
        {
            Console.WriteLine("Конструктор класса C без параметров");
        }

        public C(object a, object b)
        {
            Console.WriteLine("Конструктор класса C c параметрами a,b");
        }

        public C(object a, object b, object c) :
            base(a, b, c)
        {
            Console.WriteLine("Конструктор класса C c параметрами a,b,c");
        }

        new public void Print2()
        {
            Console.WriteLine("C");
        }

        new public void Print1()
        {
            Console.WriteLine("C");
        }
    }
    #endregion

    #region AAA, BBB, CCC, DDD
    public class AAA
    {
        public virtual void Foo() { Console.WriteLine("AAA virtual Foo"); }
        public virtual void Print() { Console.WriteLine("AAA virtual Print"); }
        public void Display() { Console.WriteLine("AAA Display"); }
        public void Print1() { Console.WriteLine("AAA Print1"); }
    }

    public class BBB: AAA
    {
        public override void Foo() { Console.WriteLine("BBB override Foo"); }
        public override void Print() { Console.WriteLine("BBB override Print"); }
        public new void Display() { Console.WriteLine("BBB Display"); }
    }
    
    public class CCC: BBB
    {
        public override void Foo() { Console.WriteLine("CCC override Foo"); }
        public new void Display() { Console.WriteLine("CCC Display"); }
        public new void Print() { Console.WriteLine("CCC new Print"); }
        public new void Print1() { Console.WriteLine("CCC Print1"); }
    }

    public class DDD: CCC
    {
        public override void Foo() { Console.WriteLine("DDD override Foo"); }
        public new void Display() { Console.WriteLine("DDD Display"); }
        public new void Print1() { Console.WriteLine("DDD Print1"); }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Console.ReadLine();
        }

        static void Task3()
        {
            var a = new AAA();
            var b = new BBB();
            var c = new CCC();
            var d = new DDD();
            
            Console.WriteLine("---");
            // Вызов метода Foo класса А
            a.Foo();
            a.Display();
            a.Print();
            a.Print1();
            Console.WriteLine("---");
            
            // Вызов метода Foo класса В
            b.Foo();
            b.Display();
            b.Print();
            b.Print1();
            Console.WriteLine("---");
            
            // Вызов метода Foo класса С
            c.Foo();
            c.Display();
            c.Print();
            c.Print1();
            Console.WriteLine("---");

            // Вызов метода Foo класса D
            d.Foo();
            d.Display();
            // Вызываем метод класса С, последний в иерархии наследования
            d.Print();
            d.Print1();
            Console.WriteLine("---");

            // Приводим объект типа DDD к базовому классу AAA
            // Идем по иерархии наследования A -> B -> C -> D и вызываем наиболее подходящий метод, т.е. D.Foo()
            var obj1 = (AAA)d;
            obj1.Foo();
            obj1.Display();
            obj1.Print(); // A -> B
            obj1.Print1();
            Console.WriteLine("---");

            var obj2 = (BBB)d;
            obj2.Foo();
            obj2.Display();
            obj2.Print(); // A -> B
            obj2.Print1();
            Console.WriteLine("---");

            var obj3 = (CCC)d;
            obj3.Foo();
            obj3.Display();
            obj3.Print(); // A -> B -> C
            obj3.Print1();
            Console.WriteLine("---");

            
        }

        static void Task2()
        {
            Console.WriteLine("---");
            var c = new C();
            Console.WriteLine("---");
            var c1 = new C(new Object(), new Object(), new Object());
            Console.WriteLine("---");
            var c2 = new C(new Object(), new Object());
            Console.WriteLine("---");
            A a = c; // Приведение к A

            // Вызываем метод Print2 класса А
            a.Print2(); // A
            ((A)c).Print2(); // A

            // Вызываем метод Print1 класса C
            c.Print1(); // C

            // Идем по иерархии наследования и находим более подходящую перегрузку (в методе В)
            a.Print1(); // B
            ((A)c).Print1(); // B

            // Вызываем метод Print2 класса C
            c.Print2();
        }

        static void Task1()
        {
            // Не скомпилируется, т.к. нельзя привести AA к BB
            //BB obj1 = new AA();
            //obj1.Print();

            BB obj2 = new BB();
            obj2.Print();

            // Неявное приведение к типу BB
            AA obj3 = new BB();
            obj3.Print();

            AA a = new AA();
            BB b = new BB();
            a.Print();
            b.Print();
            ((AA)b).Print();

            // Ошибка приведения объекта родительского типа к дочернему типу (AA к BB)
            try
            {
                ((BB)a).Print();
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
