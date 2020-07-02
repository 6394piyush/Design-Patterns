
using System;
using System.Collections.Generic;
using System.Text;

namespace FacadeLib{
    internal class SubsystemA
    {
        internal string A1()
        {
            return "Subsystem A Method A1";
        }
        internal string A2()
        {
            return "Subsystem A Method A2";
        }
        internal string A3()
        {
            return "Subsystem A Method A3";
        }
    }
    internal class SubsystemB
    {
        internal string B1()
        {
            return "Subsystem B Method B1";
        }
        internal string B2()
        {
            return "Subsystem B Method B2";
        }
    }
    internal class SubsystemC
    {
        internal string C1()
        {
            return "Subsystem C Method C1";
        }
    }
    public static class Facade 
    {
        static SubsystemA a = new SubsystemA();
        static SubsystemB b = new SubsystemB();
        static SubsystemC c = new SubsystemC();

        public static void Operation1()
        {
            Console.WriteLine("Operation 1:"+a.A1()+b.B1()+c.C1());
        }
        public static void Operation2()
        {
            Console.WriteLine("Operation 2:" + a.A2() + b.B2() + a.A3());
        }
    }
}

namespace DesignPatterns
{
    
   
   

    class Program
    {
        
            static void Main(string[] args)
            {
            Console.WriteLine("Hello Design Patterns");

            FacadeLib.Facade.Operation1();
            FacadeLib.Facade.Operation2();

            


            
        }   
    }
}
