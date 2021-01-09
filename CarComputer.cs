using System;
using System.Collections.Generic;
using System.Text;

namespace CarComputerTelemetry
{
    class CarComputer
    {
        int speed = 0; // początkowa prędkość równa 0
        int gear = 1; // początkowy bieg to 1
        int rpm = 800; //początkowe obroty silnika
        int engineTemperature = 0; //początkowa temperatura silnika w stopniach Celcjusza
        int steeringWheelRadius = 0; //0 - kierownica w pozycji wyjściowej, gdy wartość kąta jest dodatnia oznaca skręt w prawo, gdy ujemna skręt w lewo
        
        public int GetSpeed()
        {
            return speed;
        }

       public int GetGear()
        {
            return gear;
        }

        public int GetRpm()
        {
            return rpm;
        }

        public int GetEngineTemperature()
        {
            return engineTemperature;
        }

        public int GetSteeringWheelRadius()
        {
            return steeringWheelRadius;
        }

        public void ShiftUp() // skrzynia w aucie jest 6 stopniowa, gdy zostanie wbity 6 bieg, nie można wbić wyższego biegu
        {
            gear++;
            if(gear >6)
            {
                gear = 6;
            }
        }

        public void ShiftDown() //gdy auto jest na 1 biegu nie można wbić niższego biegu
        {
            gear--;
            if(gear<1)
            {
                gear = 1;
            }
        }
        public void CalculateSpeed() //przybliżona wartość prędkości na podstawie obecnego biegu oraz obrotów silnika
        {
            if (gear > 1)
            {
                speed = (rpm * (gear - 1)) / 100;
            }
            else
            {
                speed = (rpm * (gear)) / 100;
            }
        }

        public void Acceleration()
        {
            if(rpm<4800) //dla symulacji wybrany został samochód z silnikiem Diesla, dlatego maksymalne obroty to 4800
                rpm += 100; //obroty jednorazowo rosną o 100
            
            if(rpm>2500) //zmiana biegu na wyższy po przekroczeniu 2500 obrotów
            {
                ShiftUp();
                rpm = 1700; //po zmianie biegu obroty spadają do 1700
            }
            CalculateSpeed();         //obliczanie prędkości dla obecnego biegu oraz prędkości

        }

        public void SlowingDown()
        {
            if(rpm>500) //przyjęte mimalne obroty żeby silnik nie zgasł
                rpm -= 100; //obroty jednorazowo maleją o 100

            if(rpm<1000)
            {
                ShiftDown();
                rpm = 1700;  //po zmianie biegu obroty rosną do 1700

            }
            CalculateSpeed(); //obliczanie prędkości dla obecnego biegu oraz prędkości
        }

        public void PernamentDriving() //jazda stała
        {
            CalculateSpeed();
        }



        public void WarmEngine()
        {
            engineTemperature += 2; //silnik grzeje się o 2 stopnie Celcjusza
            if (engineTemperature > 90) //maksymalna temperatura do jakiej rozgrzewa się silnik w symulacji
                engineTemperature = 90;
        }

        public void TurnRight()
        {
            steeringWheelRadius += 10; //skręt kierownicy w prawo jednorazowo o 10 stopni
            if (steeringWheelRadius > 360) //maksymalny promień skrętu w prawo to 360 stopni, zgodnie z warunkami przyjętymi na początku
                steeringWheelRadius = 360;
        }

        public void TurnLeft()
        {
            steeringWheelRadius -= 10; //skręt kierownicy w lewo jednorazowo o 10 stopni
            if (steeringWheelRadius < -360) //maksymalny promień skrętu w lewo to -360 stopni, zgodnie z warunkami przyjętymi na początku
                steeringWheelRadius = -360;
        }


    }
}
