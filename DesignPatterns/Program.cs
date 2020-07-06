
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace DesignPatterns
{
    interface IFactory<Brand> where Brand : IBrand
    {
        IShoes CreateShoes();
        IBag CreateBag();
    }

    class Factory<Brand>: IFactory<Brand> where Brand:IBrand ,new()
    {
        public IBag CreateBag()
        {
            return new Bag<Brand>();
        }
        public IShoes CreateShoes()
        {
            return new Shoes<Brand>();
        }
    }
    interface IShoes
    {
        int Price { get; }
    }

    interface IBag
    {
        string Material { get; }
    
    }


class Bag<Brand> : IBag where Brand : IBrand, new()
    { 
     private Brand brand; 
        public Bag() 
        { 
            brand = new Brand();
        }
    public string Material { get { return brand.Material; } 

    }
}

class Shoes<Brand> : IShoes where Brand : IBrand, new() 
    { 
        private Brand mybrand; 
        public Shoes()
        {
            mybrand = new Brand();
        }

    public int Price { get { return mybrand.Price; } }
    }


interface IBrand
{
    int Price { get; }
    string Material { get; }
}

    class Gucci : IBrand
    {
        public int Price { get { return 1000; } }

        public string Material { get { return "crocodile skin"; } }
    }

    class Poochi : IBrand
    {
        public int Price { get { return new Gucci().Price / 3; } }

        public string Material { get { return "Plastic"; } }
    }

    class Client<Brand> where Brand : IBrand, new()
    {
        public void ClientMain()
        {
            IFactory<Brand> factory = new Factory<Brand>();
            IShoes shoes = factory.CreateShoes();
            IBag bag = factory.CreateBag();

            Console.WriteLine("I brought bag made from "+bag.Material);
            Console.WriteLine("I brought shoes at price " + shoes.Price);
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Design Patterns");
            new Client<Gucci>().ClientMain();
            new Client<Poochi>().ClientMain();
        }



    }      
}
