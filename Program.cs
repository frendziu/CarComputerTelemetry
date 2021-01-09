using System;

namespace CarComputerTelemetry
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation simulation = new Simulation();
            Random rand = new Random();
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(1);


            Console.WriteLine("Car simulator");
                       
            var timer = new System.Threading.Timer((e) => //funkcja wykonująca symulację co sekundę
            {
                int sampleRate = rand.Next(1, 10); //losowanie losowej liczby częstotliwość próbkowania
                Console.WriteLine("Sample Quantity: " + sampleRate + " Hz");
                for (int i = 0; i < sampleRate; i++)
                {
                    simulation.DoSimulation(); //wykonywanie symulacji tyle razy jaka częstotliwość w ciągu jednej sekundy


                }
                simulation.CalculaterAvg(sampleRate); //obliczanie średniej
                Console.WriteLine("Gear: " + simulation.GetAvgGear() + " RPM: " + simulation.GetAvgRpm() + " Speed: " + simulation.GetAvgSpeed() + " Steering Wheel Radius: " + simulation.GetAvgSWR() + " Engine Temperature: " + simulation.GetAvgEngineTemperature());
                simulation.ResetValues(); //resetowanie wartości średnich przed wykonaniem kolejnych symulacji dla następnej sekundy

            }, null, startTimeSpan, periodTimeSpan);

            Console.ReadLine();
          
        }
    }
}
