using System;
using System.Collections.Generic;
using System.Text;

namespace CarComputerTelemetry
{
    class Simulation
    {
        CarComputer cc = new CarComputer();
        Random rand = new Random();

        int avgGear = 0;
        int avgRpm = 0;
        int avgSpeed = 0;
        int avgSWR = 0;
        int avgEngineTemperature = 0;

        
        public void ResetValues()
        {
            avgGear = 0;
            avgRpm = 0;
            avgSpeed = 0;
            avgSWR = 0;
            avgEngineTemperature = 0;

        }

        public void DoSimulation() ///funkcja symulacji
        {
           
            cc.WarmEngine(); //funkcja zmieniająca temperaturę silnika
            int actions = rand.Next(0, 4); //generowanie losowej akcji
            switch (actions)
            {
                case 0:
                    cc.Acceleration(); //funkcja przyśpieszania
                    break;
                case 1:
                    cc.PernamentDriving(); //funkcja stałej jazdy
                    break;
                case 2:
                    cc.Acceleration(); //kolejna funkcja przyśpieszania w celu uzyskania w symulacji lepszego efektu przyśpieszenia, ciekawsze wyniki
                    break;
                case 3:
                    cc.SlowingDown(); //funkcja zwalniania
                    break;
            }

            if (rand.Next(0, 2) == 0) //generowanie losowej akcji skrętu kierownicy
                cc.TurnRight();
            else
                cc.TurnLeft();

            CalculateSum(); //zliczanie sum poszczególnych pul dla kolejnych prób

        }

        public void CalculateSum() //funkcja zliczająca sumy
        {
            avgGear += cc.GetGear();
            avgRpm += cc.GetRpm();
            avgSpeed += cc.GetSpeed();
            avgSWR += cc.GetSteeringWheelRadius();
            avgEngineTemperature += cc.GetEngineTemperature();
        }

        public void CalculaterAvg(int sample) //funkcja obliczająca średnią wartość pul z wszystkich prób
        {
            avgGear /= sample;
            avgRpm /= sample;
            avgSpeed /= sample;
            avgSWR /= sample;
            avgEngineTemperature /= sample;
        }

        public int GetAvgGear()
        {
            return avgGear;
        }

        public int GetAvgRpm()
        {
            return avgRpm;
        }

        public int GetAvgSpeed()
        {
            return avgSpeed;
        }

        public int GetAvgSWR()
        {
            return avgSWR;
        }

        public int GetAvgEngineTemperature()
        {
            return avgEngineTemperature;
        }


    }
}
