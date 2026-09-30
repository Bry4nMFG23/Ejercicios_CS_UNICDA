using System;

class RemoteControlCar
{
    private int _distanceDriven = 0;
    private int _batteryPercentage = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Manejado {_distanceDriven} metros";
    }

    public string BatteryDisplay()
    {
        if (_batteryPercentage == 0)
        {
            return "Bateria vacia";
        }

        return $"Bateria al {_batteryPercentage}%";
    }

    public void Drive()
    {
        if (_batteryPercentage > 0)
        {
            _distanceDriven += 20;
            _batteryPercentage -= 1;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Comprar un carro nuevo
        RemoteControlCar car = RemoteControlCar.Buy();

        //Mostrar estado inicial
        Console.WriteLine(car.DistanceDisplay()); 
        Console.WriteLine(car.BatteryDisplay());  

        //Manejar el carro
        car.Drive();
        car.Drive();

        //Verificar la distancia y la batería actualizadas
        Console.WriteLine(car.DistanceDisplay()); 
        Console.WriteLine(car.BatteryDisplay());  

        //Para agotar la batería por completo
        for (int i = 0; i < 100; i++)
        {
            car.Drive();
        }

        //Verificamos el comportamiento con la batería vacía
        Console.WriteLine(car.DistanceDisplay()); 
        Console.WriteLine(car.BatteryDisplay());  

        //Intentamos manejar sin batería no cambiará nada
        car.Drive();
        Console.WriteLine(car.DistanceDisplay()); 
    }
}