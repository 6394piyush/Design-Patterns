
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace DesignPatterns
{

    class MonthIterator : IEnumerable
    {
        string[] months = { "January", "February","March","April","May","June","July","August","September","October","November","December" };
        public IEnumerator GetEnumerator()
        {
            foreach(string item in months)
            {
                yield return item;
            }
        }
    }


    class Program
        {


        static void Main(string[] args)
            {
                Console.WriteLine("Hello Design Patterns");
                MonthIterator month = new MonthIterator();
                foreach(string n in month)
                {
                    Console.WriteLine(n+" ");
                    Console.WriteLine();
                }
            }



        }
    }



