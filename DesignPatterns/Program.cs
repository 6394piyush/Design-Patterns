
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace DesignPatterns
{
    public class Client
    {
        IStrategy strategy = new StrategyA();
        public int count = 5;
        
         public int Algorithm()
        {
            return strategy.Move(this);
        }

        public void SwitchStrategies()
        {
            if (strategy is StrategyA)
            {
                strategy= new StrategyB();
            }
            else if (strategy is StrategyB)
            {
                strategy = new StrategyA();
            }
        }
    }
    public interface IStrategy //what alogo does
    {
        public int Move(Client c);
    }

    class StrategyA : IStrategy
    {
        public int Move(Client c)
        {
            return ++c.count;
        }
    }

    class StrategyB : IStrategy
    {
        public int Move(Client c)
        {
            return --c.count;
        }
    }

    class Program
        {

            static void Main(string[] args)
            {
                Console.WriteLine("Hello Design Patterns");
            Client c = new Client();
            Random r = new Random();
            for(int i=5;i<=20;i++)
            {
                if(r.Next(3)==2)
                {
                    Console.WriteLine(" || ");
                    c.SwitchStrategies();
                }
                Console.WriteLine(c.Algorithm()+ " ");

            }
            Console.WriteLine();

            }



        }
    }


