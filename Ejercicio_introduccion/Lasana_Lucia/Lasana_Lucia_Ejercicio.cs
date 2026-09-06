/*¡La novia de Lucian está de camino a casa y él aún no ha preparado la cena de su aniversario!

En este ejercicio, vas a escribir un código para ayudar a Lucian a cocinar una exquisita lasaña siguiendo su libro de cocina favorito.

Tienes cuatro tareas, todas relacionadas con el tiempo que dediques a cocinar la lasaña.*/

class Lasagna
{
    public int ExpectedMinutesInOven()
    {
        return 40;
    }

    public int RemainingMinutesInOven(int actualMinutesInOven)
    {
        return ExpectedMinutesInOven() - actualMinutesInOven;
    }

    public int PreparationTimeInMinutes(int capas)
    {
        return capas * 2;
    }

    public int ElapsedTimeInMinutes(int capas, int actualMinutesInOven)
    {
        return PreparationTimeInMinutes(capas) + actualMinutesInOven;
    }
}








