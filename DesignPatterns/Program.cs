using System;

namespace DesignPatterns
{
    class DecoratorPattern
    {

    }
    interface IComponent
    {
        string Operation();        
    }

    class Component : IComponent
    {
        public string Operation()
        {
            return "I am Operation";
        }
    }

    class DecoratorA : IComponent
    {
        
            IComponent component;

            public DecoratorA(IComponent c)
            {
                component = c;
            }
        public string Operation()
        {
            string s = component.Operation();
            string st = s + " returned after modyfying from Decorator";
            return st;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Design Patterns");
            IComponent component = new Component();
            Console.WriteLine(component.Operation());
            Console.WriteLine(new DecoratorA(component).Operation());
        }
    }
}
