
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace DesignPatterns
{
    public class Client
    {
        IState strategy = new StateA();

        public IState state { get; set; }
        public const int limit = 10;
        public int count = limit;
        

        
         public int Request(int n)
        {
            if(n==2)
                return state.MoveUp(this);
            return state.MoveDown(this);
            
        }

        
    }
    public interface IState //what alogo does
    {
        public int MoveUp(Client c);
        public int MoveDown(Client c);
    }

    class StateA : IState
    {
        public int MoveDown(Client c)
        {
            if(c.count > Client.limit)
            {
                c.state = new StateB();
                Console.WriteLine(" || ");
            }
            return c.count-=2;
            
        }

        public int MoveUp(Client c)
        {
            return c.count+=2;
        }
    }

    class StateB : IState
    {
        public int MoveDown(Client c)
        {
            if (c.count > Client.limit)
            {
                c.state = new StateA();
                Console.WriteLine(" || ");
            }
            return --c.count;

        }

        public int MoveUp(Client c)
        {
            return ++c.count;
        }
    }

    class Program
        {

            static void Main(string[] args)
            {
            Console.WriteLine("Hello Design Patterns");
            Client c = new Client();
            c.state = new StateA();
            Random r = new Random();
            for(int i=5;i<=20;i++)
            {
                Console.WriteLine(c.Request(r.Next(3)));

            }
            Console.WriteLine();

            }



        }
    }


