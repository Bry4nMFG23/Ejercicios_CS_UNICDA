using System;

namespace Car_Assemble{
    static class AssemblyLine
    {
        
        public static double SuccessRate(int tasa)
        {
            if (tasa == 0)
            {
                return 0.0;
            }
            else if(tasa >=1 && tasa <= 4)
            {
                return 1.0;
            }
            else if(tasa >=5 && tasa <= 8)
            {
                return 0.9;
            }
            else if(tasa == 9)
            {
                return 0.8;
            }
            else if(tasa == 10)
            {
                return 0.77;
            }
            else
            {
                return 0.0;
            }

        }

        public static double ProductionRatePerHour(int tasa)
        {
            return tasa * 221 * SuccessRate(tasa);
        }

        public static int WorkingItemsPerMinute(int tasa)
        {
            return (int)(ProductionRatePerHour(tasa) / 60);
        }

    }


    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Ingrese la tasa de producción (0-10):");
            int tasa = Convert.ToInt32(Console.ReadLine());

            double successRate = AssemblyLine.SuccessRate(tasa);
            double productionRate = AssemblyLine.ProductionRatePerHour(tasa);
            int workingItems = AssemblyLine.WorkingItemsPerMinute(tasa);

            Console.WriteLine($"Tasa de éxito: {successRate}");
            Console.WriteLine($"Producción por hora: {productionRate}");
            Console.WriteLine($"Artículos trabajados por minuto: {workingItems}");
        }
    }

}