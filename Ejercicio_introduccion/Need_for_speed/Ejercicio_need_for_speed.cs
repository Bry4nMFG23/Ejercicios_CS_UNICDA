using System;

class RemoteControlCar
{
    private int _speed;
    private int _batteryDrain;
    private int _metersDriven;
    private int _batteryPercentage = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return _batteryPercentage < _batteryDrain;
    }

    public int DistanceDriven()
    {
        return _metersDriven;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            _metersDriven += _speed;
            _batteryPercentage -= _batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }

    public int Speed => _speed;
    public int BatteryDrain => _batteryDrain;
}

class RaceTrack
{
    private int _distance;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int maxDrives = 100 / car.BatteryDrain;
        
        int maxDistance = maxDrives * car.Speed;

        return maxDistance >= _distance;
    }
}

class Program
{
    static void Main()
    {
        var car = new RemoteControlCar(5,2);
        

        car.Drive();

        Console.WriteLine(car.DistanceDriven());
        Console.WriteLine(car.BatteryDrained());

        var car2 = RemoteControlCar.Nitro();
        car2.Drive();
        Console.WriteLine(car2.DistanceDriven());

        var racetrack = new RaceTrack(800);

        Console.WriteLine(racetrack.TryFinishTrack(car2));


            
        

    }
}























