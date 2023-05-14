internal class Program
{
    abstract class Vehicle
    {
        protected double speed;
        protected string color;

        public Vehicle(double Speed, string Color)
        {
            speed = Speed;
            color = Color;
        }

        public abstract void accelerate();
        public void reverse()
        {
            speed = speed - 10;
        }

        public void stop()
        {
            speed = 0;
        }

        public double getSpeed()
        {
            return speed;
        }
    }

    class Car : Vehicle
    {
        int passengers = 1;
        int nOfWheels;

        public Car(double Speed, string Color, int NOfWheels, int Passengers)
        : base(Speed, Color)
        {
            if(Passengers > 0)
            passengers = Passengers;

            nOfWheels = NOfWheels;
        }

        public override void accelerate()
        {
            speed = speed + ((double)20 / passengers);
        }
    }

    class Bike : Vehicle
    {
        bool turbo;

        public Bike(double Speed, string Color, bool Turbo)
        : base(Speed, Color)
        {
            turbo = Turbo;
        }

        public override void accelerate()
        {
            if (turbo == true)
            {
                speed = speed + 20;
            }
            else
            {
                speed = speed + 10;
            }
        }

    }

    class GrandRace
    {
        Vehicle[] racers;
        static int indx = 0;

        public GrandRace(int Count)
        {
            racers = new Vehicle[Count];
        }

        public void addRacer(Vehicle racer)
        {
            if (indx == racers.Length)
            {
                Console.WriteLine("No more racers can participate");
                return;
            }

            racers[indx] = racer;
            ++indx;
        }

        public void startRace()
        {
            int winner = 0;
            if (indx < racers.Length)
            {
                Console.WriteLine($"Waiting for another {racers.Length - indx} racer(s) in our Grand Race");
                return;
            }
            else
            {
                double maxSpeed = racers[0].getSpeed();
                for (int i = 0; i < racers.Length; ++i)
                {
                    if (racers[i].getSpeed() > maxSpeed)
                    {
                        maxSpeed = racers[i].getSpeed();
                        winner = i;
                    }
                }
            }

            Console.WriteLine($"Winner is Racer number {winner+1} with speed of {racers[winner].getSpeed()}km/h");

        }
    }

    public static void Main(string[] args)
    {
        Vehicle r1 = new Car(200, "Red", 4, 1);
        Vehicle r2 = new Car(210, "Blue", 4, 1);
        Vehicle r3 = new Car(230, "Green", 6, 1);
        Vehicle r4 = new Bike(150, "Blue", true);

        GrandRace race = new GrandRace(4);
        race.addRacer(r1);
        race.addRacer(r2);
        race.addRacer(r3);
        race.addRacer(r4);
        r4.accelerate(); r4.accelerate(); r4.accelerate(); r4.accelerate(); r4.accelerate();

        race.startRace();
    }
}
