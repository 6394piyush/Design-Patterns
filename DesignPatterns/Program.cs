
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;


namespace DesignPatterns
{
    class Handler
    {
        Handler next;
        int id;
        int Limit { get; set; }
        public Handler(int id,Handler hdl)
        {
            this.id = id;
            Limit = id * 1000;
            next = hdl;
        }

        public string HandleRequest(int data)
        {
            if (data < Limit)
                return "Reuest for " + data + " handled at level " + id;
            else if (next != null)
                return next.HandleRequest(data);
            else return ("Request for " + data + " handled BY DEEFAULT at level " + id);
        
        }
    }

    class Program
        {

            static void Main(string[] args)
            {
            Handler start = null;
            for(int i=5;i>0;i--)
            {
                Console.WriteLine("Handler "+i+" deals up to  a limit of "+i*1000);
                start = new Handler(i,start);
            }

            int[] a = { 50, 1000, 1500, 10000, 175, 4500 };
            foreach(int i in a)
            {
                Console.WriteLine(start.HandleRequest(i));
            }
            


            }



        }
    }


