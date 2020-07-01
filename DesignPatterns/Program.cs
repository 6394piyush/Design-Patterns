
using System;
using System.Collections.Generic;
using System.Text;


namespace DesignPatterns
{
    class Adaptee
    {   //existing way req are implemented
        public double precise(double a,double b)
        {
            return a / b;
        }
    }

    class Target
    {
        //new standard for requests
        public string Estimate(int i)
        {
            return "estimate is " + (int)Math.Round(i / 3.0);
        }
    }
    class Adaptor:Adaptee
    {
        public Func<int, string> Request;  //string Estimate(Int i) method signature
        public Adaptor(Adaptee adaptee)
        {
            Request = delegate (int i)
            {
                return "Estimate based in Precision is " + (int)Math.Round(precise(i, 3));
            };
        }
        public Adaptor(Target target)
        {
            Request = target.Estimate;
        }
    }
   
   

    class Program
    {
        
            static void Main(string[] args)
            {

            Console.WriteLine("Hello Design Patterns");

            Adaptor adapter1 = new Adaptor(new Adaptee());
             Console.WriteLine(adapter1.Request(5));
            
            Adaptor adapter2 = new Adaptor(new Target());
            Console.WriteLine(adapter2.Request(5));

        }   
    }
}
