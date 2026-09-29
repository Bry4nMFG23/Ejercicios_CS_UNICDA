using System;
using System.Collections.Generic;

namespace RemoteControlCompetition
{
    //Definición de la interfaz
    public interface IRemoteControlCar
    {
        int DistanceTravelled { get; }
        void Drive();
    }

    //Auto de producción
    public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
    {
        public int DistanceTravelled { get; private set; }
        public int NumberOfVictories { get; set; }

        public void Drive()
        {
            DistanceTravelled += 10;
        }

        //Comparación por número de victorias
        public int CompareTo(ProductionRemoteControlCar other)
        {
            if (other == null) return 1;
            return this.NumberOfVictories.CompareTo(other.NumberOfVictories);
        }
    }

    //Auto de prueba
    public class ExperimentalRemoteControlCar : IRemoteControlCar
    {
        public int DistanceTravelled { get; private set; }

        public void Drive()
        {
            DistanceTravelled += 20;
        }
    }

    // Pista de pruebas
    public static class TestTrack
    {
        public static void Race(IRemoteControlCar car)
        {
            car.Drive();
        }

        public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1, ProductionRemoteControlCar prc2)
        {
            var cars = new List<ProductionRemoteControlCar> { prc1, prc2 };
            cars.Sort();
            return cars;
        }
    }

    // Clase principal para ejecutar la prueba
    internal class Program
    {
        static void Main(string[] args)
        {
            // Probar la conducción y la distancia en la pista
            var prodCar = new ProductionRemoteControlCar();
            var expCar = new ExperimentalRemoteControlCar();

            TestTrack.Race(prodCar);
            TestTrack.Race(expCar);

            Console.WriteLine("--- Prueba de Carrera ---");
            Console.WriteLine($"Distancia auto de producción: {prodCar.DistanceTravelled} m"); 
            Console.WriteLine($"Distancia auto experimental: {expCar.DistanceTravelled} m");    

            // Probar la clasificación por número de victorias
            var prc1 = new ProductionRemoteControlCar { NumberOfVictories = 3 };
            var prc2 = new ProductionRemoteControlCar { NumberOfVictories = 2 };

            List<ProductionRemoteControlCar> rankings = TestTrack.GetRankedCars(prc1, prc2);

            Console.WriteLine("\n--- Clasificación de Autos ---");
            Console.WriteLine($"1º lugar con menos victorias: {rankings[0].NumberOfVictories} victorias"); 
            Console.WriteLine($"2º lugar con más victorias: {rankings[1].NumberOfVictories} victorias");  
        }
    }
}