
using System;
using System.Collections.Generic;
using System.Text;


namespace DesignPatterns
{
    class Adaptee
    {
        public double SpecificRequest(double a,double b)
        {
            return a / b;
        }

    }
    interface ITarget
    {
        string Request(int i);
    }

    class Adapter : Adaptee, ITarget
    {
        public string Request(int i)
        {
            string s = "Rough Estimate is " + (int)Math.Round((SpecificRequest(i, 3)));
            return s;
        }
    }


    class Program
    {
        
            static void Main(string[] args)
            {

            Console.WriteLine("Hello Design Patterns");
            Adaptee first = new Adaptee();
            Console.WriteLine("Before new instruction pricing");
            Console.WriteLine(first.SpecificRequest(5,3));

            //what client really wants
            ITarget second = new Adapter();
            Console.WriteLine("New Standard");
            Console.WriteLine(second.Request(5));
            

            }   
    }
}
