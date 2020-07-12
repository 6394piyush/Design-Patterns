
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace DesignPatterns
{
    


       
        class Program
        {

        delegate void Invoker();
        static Invoker Execute, Undo, Redo;

        class Command
        {
            public Command(Reciever r)
            {
                Execute = r.Action;
                Undo = r.Reverse;
                Redo = r.Action;
            }
        }

        class Reciever
        {
            string build, oldbuild;
            string s = "Some String";
            public void Action()
            {
                oldbuild = build;
                build += s;
                Console.WriteLine("Reciever is adding " + build);
            }
            public void Reverse()
            {
                build = oldbuild;
                Console.WriteLine("Reciever is reverting to " + build);
            }
        }

        static void Main(string[] args)
            {
                Console.WriteLine("Hello Design Patterns");
            new Command(new Reciever());
            Execute();
            Redo();
            Undo();
            Execute();
                
            }



        }
    }



