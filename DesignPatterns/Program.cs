using CompositePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public interface IComponent<T>
    {
        void Add(IComponent<T> c);
        IComponent<T> Remove(T s);
        IComponent<T> Find(T s);
        string Display(int depth);
        T Name { get; set; }

    }
    public class Component<T> : IComponent<T>
    {
        public T Name { get; set; }

        public void Add(IComponent<T> c)
        {
            Console.WriteLine("Cannot Add Directly");
        }

        public string Display(int depth)
        {
            return new string(depth + "-" + Name);
        }

        public IComponent<T> Find(T s)
        {
            if(s.Equals(Name))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        public IComponent<T> Remove(T s)
        {
            Console.WriteLine("Cannot remove directly");
            return this;
        }
    }
    public class Composite<T> : IComponent<T>
    {
        List <IComponent<T>> list;
        public T Name { get; set; }
        IComponent<T> holder = null;
        public Composite(T name)
        {
            Name = name;
            list = new List<IComponent<T>>();
        }

        public void Add(IComponent<T> c)
        {
            list.Add(c);
        }

        public string Display(int depth)
        {
            StringBuilder sb = new StringBuilder(new String('-',depth));
            sb.Append("Set " + Name + " Length " + list.Count + "\n");
            foreach (IComponent<T> component in list)
            {
                sb.Append(component.Display(depth + 2));
            }
            return sb.ToString();

        }

        public IComponent<T> Find(T s)
        {
            IComponent<T> found = null;
            holder = this;
            if (Name.Equals(s))
                return this;
            foreach (IComponent<T> c in list)
            {
                found = c.Find(s);
                if (found != null)
                    break;
            }
            return found;
        }

        public IComponent<T> Remove(T s)
        {
            holder = this;
            IComponent<T> p = holder.Find(s);
            if(holder!=null)
            {
                (holder as Composite<T>).list.Remove(p); //casting of holder to composite from Icomposite
                return holder;
            }
            else
            {
                return this;
            }

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
            string param = "Piyush";
            IComponent<string> names = new Composite<string>("Name with surname");
            IComponent<string> surnames = names;
            for(int i=0;i<=5;i++)
            { 
                IComponent<string> c = new Composite<string>(param + i);
                surnames.Add(c);
                surnames = c;

            }
            
            Console.WriteLine(names.Display(0));

            

            
        }
    }
}
