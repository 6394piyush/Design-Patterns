
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace DesignPatterns
{
    public abstract class PastaDish
    {
      public void MakeRecipe()
        {
            boilWater();
            addPasta();
            cookPasta();

        }

        public abstract void AddPasta();
        public abstract void AddSauce();
        public abstract void AddGarnish();
        private void boilWater()
        {
            Console.WriteLine("Boiling water");
        }
        private void addPasta()
        {
            Console.WriteLine("Adding Pasta");
        }
        private void cookPasta()
        {
            Console.WriteLine("Cooking Pasta");
        }
    }

    class Sphagetti : PastaDish
    {
        public override void AddGarnish()
        {
            Console.WriteLine("Garnish Added");
        }

        public override void AddPasta()
        {
            Console.WriteLine("Pasta Added");
        }

        public override void AddSauce()
        {
            Console.WriteLine("Sauce Added");
        }
    }

    class Program
        {

            static void Main(string[] args)
            {
            Sphagetti ob = new Sphagetti();
            ob.MakeRecipe();
            ob.AddSauce();
            ob.AddGarnish();
            
            


            }



        }
    }


