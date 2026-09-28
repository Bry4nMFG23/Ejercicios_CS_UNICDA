using System;


public enum TravelMethod
{
    Walking,
    Horseback
}

public class Character
{
    public string Class { get; set; } = string.Empty;
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

public class Destination
{
    public string Name { get; set; } = string.Empty;
    public int Inhabitants { get; set; }
}


public static class GameMaster
{
    public static string Describe(Character character)
    {
        return $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points.";
    }

    public static string Describe(Destination destination)
    {
        return $"You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }

    public static string Describe(TravelMethod travelMethod)
    {
        return travelMethod switch
        {
            TravelMethod.Walking => "You're traveling to your destination by walking.",
            TravelMethod.Horseback => "You're traveling to your destination on horseback.",
            _ => throw new ArgumentOutOfRangeException(nameof(travelMethod))
        };
    }

    public static string Describe(Character character, Destination destination, TravelMethod travelMethod = TravelMethod.Walking)
    {
        return $"{Describe(character)} {Describe(travelMethod)} {Describe(destination)}";
    }
}


class Program
{
    static void Main()
    {
        var character = new Character
        {
            Class = "Wizard",
            Level = 4,
            HitPoints = 28
        };

        var destination = new Destination
        {
            Name = "Muros",
            Inhabitants = 732
        };

        Console.WriteLine("--- Prueba 1: Describe Personaje ---");
        Console.WriteLine(GameMaster.Describe(character));

        Console.WriteLine("\n--- Prueba 2: Describe Destino ---");
        Console.WriteLine(GameMaster.Describe(destination));

        Console.WriteLine("\n--- Prueba 3: Describe Método de Viaje ---");
        Console.WriteLine(GameMaster.Describe(TravelMethod.Horseback));

        Console.WriteLine("\n--- Prueba 4: Personaje viajando a caballo ---");
        Console.WriteLine(GameMaster.Describe(character, destination, TravelMethod.Horseback));

        Console.WriteLine("\n--- Prueba 5: Personaje viajando (método omitido -> Walking) ---");
        Console.WriteLine(GameMaster.Describe(character, destination));
    }
}