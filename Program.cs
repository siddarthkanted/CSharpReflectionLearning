using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaPractice
{
    class Program
    {
  
        static void Main(string[] args)
        {
            //Func<int, double> f = r => 3.14 * r * r;
            //Console.WriteLine(f(4));
            //Action<string> a = pp => Console.WriteLine("hello" + pp);
            //a("sid");
            //Predicate<int> p = aa => aa > 5;
            //Console.WriteLine(p(9));
            CustomSerialization();
            Console.WriteLine("Finished");
            Console.ReadKey();
        }

        static void CustomSerialization()
        {
            Address address = new Address("cbe", "ind");
            Student s= new Student("sid", "sid", address);
            ReflectionLearning reflectionLearning = new ReflectionLearning();
            reflectionLearning.WriteObject(s);
            //reflectionLearning.CustomAttributes(s.GetType(), s);
        }
    }
}
