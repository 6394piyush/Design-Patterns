
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace DesignPatterns
{
    class Director
    {
        public void Construct(IBuilder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();


        }
    }
    interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();

        Product GetResult();
    }
    class Builder1 : IBuilder
    {
        Product product = new Product();
        public void BuildPartA()
        {
            product.Add("Part A");
        }

        public void BuildPartB()
        {
            product.Add("Part B");
        }

        public Product GetResult()
        {
            return product;
        }
    }
    class Builder2 : IBuilder
    {
        Product product = new Product();
        public void BuildPartA()
        {
            product.Add("Part X");
        }

        public void BuildPartB()
        {
            product.Add("Part Y");
        }

        public Product GetResult()
        {
            return product;
        }
    }
    class Product
    {
        List<string> parts = new List<string>();
        public void Add(string s)
        {
            parts.Add(s);
        }

        public void Display()
        {
            Console.WriteLine("\nProduct Parts -------");
            foreach (string part in parts)
                Console.Write(part);
            Console.WriteLine();

        }
    }

        class Program
        {

            static void Main(string[] args)
            {
                Console.WriteLine("Hello Design Patterns");
            Director director = new Director();
            IBuilder b1 = new Builder1();
            IBuilder b2 = new Builder2();

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Display();
            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Display();



            }



        }
    }


