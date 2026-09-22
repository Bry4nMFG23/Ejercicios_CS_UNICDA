using System;

using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    
    public static int[] LastWeek()
    {
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }

 
    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

   
    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1]++;
    }


    public bool HasDayWithoutBirds()
    {
        foreach (int count in birdsPerDay)
        {
            if (count == 0)
            {
                return true;
            }
        }
        return false;
    }

  
    public int CountForFirstDays(int numberOfDays)
    {
        int total = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            total += birdsPerDay[i];
        }
        return total;
    }


    public int BusyDays()
    {
        int busyDaysCount = 0;
        foreach (int count in birdsPerDay)
        {
            if (count >= 5)
            {
                busyDaysCount++;
            }
        }
        return busyDaysCount;
    }
}

class Program
{
    static void Main()
    {
        int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
        BirdCount birdCount = new BirdCount(birdsPerDay);

        Console.WriteLine($"Aves hoy: {birdCount.Today()}");
        
        birdCount.IncrementTodaysCount();
        Console.WriteLine($"Aves vista hoy: {birdCount.Today()}");

        Console.WriteLine($"Día sin aves?: {birdCount.HasDayWithoutBirds()}");
        Console.WriteLine($"Conteo primeros 4 días: {birdCount.CountForFirstDays(4)}");
        Console.WriteLine($"Días ocupados: {birdCount.BusyDays()}");
    }
}



