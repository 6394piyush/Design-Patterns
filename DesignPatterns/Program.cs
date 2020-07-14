
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace DesignPatterns
{




    class Program
    {
        class Mediator
        {
            public delegate void Callback(string msg, string from);
            Callback respond;
            public void SignOn(Callback method)
            {
                respond += method;
            }
            public void Block(Callback method)
            {
                respond -= method;
            }
            public void Unblock(Callback method)
            {
                respond += method;
            }
            public void Send(string msg, string from)
            {
                respond(msg, from);
                Console.WriteLine();
            }
        }

        class Colleague
        {
            Mediator mediator;
            public string name;
            public Colleague(Mediator med,string name)
            {
                mediator = med;
                mediator.SignOn(Recieve);
                this.name = name;
            }
            public virtual void Recieve(string msg,string from)
            {
                Console.WriteLine(name+" Recieved From "+from+" -> "+msg);
            }
            public void Send(string msg)
            {
                Console.WriteLine("Send from "+name+" -> "+msg);
                mediator.Send(msg,name);
            }
        }


        static void Main(string[] args)
            {
                Console.WriteLine("Hello Design Patterns");
            Mediator m = new Mediator();
            Colleague cl = new Colleague(m,"Piyush");
            cl.Send("Hello This is sent from delegates");
            cl.Send("waiting for more messages");

            }
                



        }
    }



