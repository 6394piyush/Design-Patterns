
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace DesignPatterns
{
    public abstract class IPrototype<T>
    {
        //shallow Copy
        public T Clone()
        {
            return (T)this.MemberwiseClone();
        }

        //Deep Copy
        public T DeepCopy()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(ms, this);
            ms.Seek(0, SeekOrigin.Begin);
            T copy = (T)bf.Deserialize(ms);
            ms.Close();
            return copy;
        }
    }
    [Serializable()]
    class Prototype:IPrototype<Prototype>
    {
        public string Country { get; set; }
        public string Capital { get; set; }
        public DeeperData Language { get; set; }

        public Prototype(string ctry,string cap,string lang)
        {
            Country = ctry;
            Capital = cap;
            Language = new DeeperData(lang);
        }

        public override string ToString()
        {
             return Country + "\t\t" + Capital + "\t\t->" + Language;
        }
    }

    [Serializable()]
    class DeeperData
    {
        public string data { get; set; }
        public DeeperData(string s)
        {
            data = s;
        }
        public override string ToString()
        {
            return data;
        }
    }

    class PrototypeManager:IPrototype<Prototype>
    {
        public Dictionary<string, Prototype> prototypes = new Dictionary<string, Prototype>
        {
            { "Germany",new Prototype("Germany","Berlin","Germen") },
            { "Italy",new Prototype("Italy","Rome","Italian") },
            { "Australia",new Prototype("Australia","Canberra","English") }
        };
    }

    class PrototypeClient:IPrototype<Prototype>
    {
        static void Report(string s,Prototype p,Prototype q)
        {
            Console.WriteLine("Prototye "+p+"\nClone "+q);
        }
    }
        
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Design Patterns");
            PrototypeManager pm = new PrototypeManager();
            Prototype c2, c3;
            c2 = pm.prototypes["Australia"].Clone();
            Console.WriteLine("Clonning Australia "+"Prototye " + pm.prototypes["Australia"] + "\nClone " + c2);
            c2.Capital = "Sydney";
            Console.WriteLine("Altering Australia shallow state " + "Prototye " + pm.prototypes["Australia"] + "\nClone " + c2);
            c2.Language.data = "Chinese";
            Console.WriteLine("Altering Australia Deep state " + "Prototye " + pm.prototypes["Australia"] + "\nClone " + c2);
        }


            
        }   
    }
