
using System;
using System.Collections.Generic;
using System.Text;


namespace DesignPatterns
{

    // ITarget interface
    public interface IAircraft
    {
        bool Airborne { get; }
        void TakeOff();
        int Height { get; }
    }
    public sealed class Aircraft : IAircraft
    {
        int h;
        bool a;
        public Aircraft()
        {
            h= 0;
            a = false;
        }
        public void TakeOff()
        {
            Console.WriteLine("Aircraft engine takeoff");
            a = true;
            h = 200; // Meters
        }
        public bool Airborne
        {
            get { return a; }
        }
        public int Height
        {
            get { return h; }
        }
    }

    // Adaptee interface
    public interface ISeacraft
    {
        int Speed { get; }
        void IncreaseRevs();
    }
    // Adaptee implementation
    public class Seacraft : ISeacraft
    {
        int speed = 0;
        public virtual void IncreaseRevs()
        {
            speed += 10;
            Console.WriteLine("Seacraft engine increases revs to " + speed + " knots");
        }
        public int Speed
        {
            get { return speed; }
        }
    }

    class Seabird : Seacraft, IAircraft
    {
        int h = 0;

        public void TakeOff()
        {
            while(!Airborne)
            {
                IncreaseRevs();
            }
        }
        public int Height
        {
            get { return h; }
        }

        public override void IncreaseRevs()
        {
            base.IncreaseRevs();
            if(Speed>40)
            {
                h += 100;
            }
        }
        public bool Airborne
        {
            get { return h > 50; }
        }
    }

    class Program
    {
        
            static void Main(string[] args)
            {

            Console.WriteLine("Hello Design Patterns");
            Console.WriteLine("Aircraft Engine");
            IAircraft aircraft = new Aircraft();
            aircraft.TakeOff();
            if(aircraft.Airborne)
                Console.WriteLine("Aircraft Flying at "+aircraft.Height+" meters");
            Console.WriteLine("Use the engine of seabird");
            Seabird seabird = new Seabird();
            seabird.TakeOff();
            Console.WriteLine("The Seabird Took off");

            Console.WriteLine("Increase the speed of seabird");
            (seabird as ISeacraft).IncreaseRevs();
            (seabird as ISeacraft).IncreaseRevs();
            (seabird as ISeacraft).IncreaseRevs();
            if(seabird.Airborne)
                Console.WriteLine("Seabird is flying at height "+seabird.Height+" meters and speed "+(seabird as ISeacraft).Speed+" knots");
            Console.WriteLine("Experiment successfull seabird flies");



        }   
    }
}
