
using System;
using System.Collections.Generic;
using System.Text;
using static DesignPatterns.FlyweightFactory;

namespace DesignPatterns
{
    public interface IFlyweight
{

    void AddPeople(Person p); //add people with name and age
    
        void GetPeople(Person p); //Intrisic State
        
        void GetFullDetails(Person p);//Extrinsic State

    
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }
    public string Education { get; set; }
    public string Hobby { get; set; }
}
public class Flyweight : IFlyweight
{
        List<Person> people;
        public Flyweight()
        {
            people = new List<Person>();
        }
        
    public void GetFullDetails(Person p)
    {
        
             
                Console.WriteLine("Name : " +p.Name);
                Console.WriteLine("Age : " + p.Age);
                Console.WriteLine("Country : " + p.Country);
                Console.WriteLine("Education : " + p.Education);
                Console.WriteLine("Hobby : " + p.Hobby); 
            
    }

    public void AddPeople(Person p)
    {
            var e = new Person() { Name = p.Name, Age = p.Age, Country = p.Country, Education = p.Education, Hobby = p.Hobby };
            people.Add(e);
    }

    public void GetPeople(Person p)
    { 
                Console.WriteLine("Name : " + p.Name);        
    }

    }
    public class FlyweightFactory
    {

        Dictionary<Person, IFlyweight> flyweights = new Dictionary<Person, IFlyweight>();

        public FlyweightFactory()
        {
            flyweights.Clear();
        }
        public int ObjectCount()
        {
            return flyweights.Count;
        }

        public IFlyweight this[Person index]
        {
            get
            {
                if (!flyweights.ContainsKey(index))
                    flyweights[index] = new Flyweight();
                return flyweights[index];
            }
        }
    }
        
    public class Client
    {
        //shared state --The People
        public static FlyweightFactory groups = new FlyweightFactory();
        static Dictionary<string, List<Person>> allGroups = new Dictionary<string, List<Person>>();

        public void LoadPeopleGroups()
        {
            var peopleGroups = new[]
            {
                new
                {
                    GName = "P",
                    Members = new[] {
                        new Person { Name = "Piyush", Age = 23, Country = "India", Education = "Graduation", Hobby = "Football" },
                        new Person { Name = "Palash", Age = 23, Country = "India", Education = "Graduation", Hobby = "Chess" },
                        new Person { Name = "Pankaj", Age = 23, Country = "India", Education = "Graduation", Hobby = "Badminton" },
                    }
                },
                new
                {
                    GName = "A",
                    Members = new[] {
                        new Person { Name = "Ajinkya", Age = 23, Country = "India", Education = "Graduation", Hobby = "Cricket" },
                        new Person { Name = "Aashish", Age = 23, Country = "India", Education = "Graduation", Hobby = "Swimming" },
                        new Person { Name = "Arun", Age = 23, Country = "India", Education = "Graduation", Hobby = "Running" },
                    }
                }
            };

            foreach(var g in peopleGroups)
            {
                allGroups.Add(g.GName, new List<Person>());
                foreach(var n in g.Members)
                {
                    allGroups[g.GName].Add(n);
                    groups[n].AddPeople(n);
                }
            }

        }

        public void DisplayPeopleGroups()
        {
            foreach(string g in allGroups.Keys)
            {
                Console.WriteLine("People : " + g);
                    foreach(var n in allGroups[g])
                    {
                        groups[n].GetPeople(n);
                    }
                
            }
            Console.WriteLine("Please select a key to view its members");
            string x=Console.ReadLine();
            foreach(string s in allGroups.Keys)
            {
                if(s.Equals(x))
                {
                    foreach(var n in allGroups[s])
                    {
                        groups[n].GetFullDetails(n);
                    }
                }
            }
            
        }
    
}


    class Program
    {
        
            static void Main(string[] args)
            {

            Console.WriteLine("Hello Design Patterns");
            Client cl = new Client();
            cl.LoadPeopleGroups();
            cl.DisplayPeopleGroups();

            }   
    }
}
