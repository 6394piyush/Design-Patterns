using System;

namespace DesignPatterns
{
    class AbstractionBridge
    {
        Bridge bridge;
        public AbstractionBridge(Bridge implementation)
        {
            bridge = implementation;
        }
        public string Operation()
        {
            return "Abstraction" + "<<<<Bridge>>>>>" + bridge.OperationImp();
        }
    }
    interface Bridge
    {
        string OperationImp();        
    }

    class ImplementationA:Bridge
    {
        public string OperationImp()
        {
            return "returned Implementation A";
        }
    }

    class ImplementationB : Bridge
    {
        
        public string OperationImp()
        {
            
            
           return "returned Implementation B";
     
        }
    }
    static class SuperOperation //Extention Method
    {
        public static void SupOp(this AbstractionBridge abg)
        {
            Console.WriteLine(abg.Operation());
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Design Patterns");
            AbstractionBridge aabg = new AbstractionBridge(new ImplementationA());
            aabg.SupOp();
            Console.WriteLine(new AbstractionBridge(new ImplementationA()).Operation());
            
            Console.WriteLine(new AbstractionBridge(new ImplementationB()).Operation());
        }
    }
}
