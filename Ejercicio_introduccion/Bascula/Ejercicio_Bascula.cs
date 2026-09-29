using System;

public class WeighingMachine
{
    
    // Propiedad de solo lectura
    public int Precision { get; }

    //Propiedad con campo de respaldo y validación
    private double _weight;
    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "El peso no puede ser negativo.");
            }
            _weight = value;
        }
    }

    //Propiedad autoimplementada con valor por defecto 5.0
    public double TareAdjustment { get; set; } = 5.0;

    //Propiedad calculada con formato y unidad
    public string DisplayWeight
    {
        get
        {
            double adjustedWeight = Weight - TareAdjustment;
            return $"{adjustedWeight.ToString($"F{Precision}")} kg";
        }
    }

    //Constructor
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Crear báscula con precisión de 3 decimales
        var wm = new WeighingMachine(precision: 3);
        Console.WriteLine($"1. Precisión: {wm.Precision}"); 

        //Probar valor predeterminado del ajuste de tara
        Console.WriteLine($"2. TareAdjustment por defecto: {wm.TareAdjustment}"); 

        //Establece el peso y probar DisplayWeight con tara por defecto (60.567 - 5.0 = 55.567)
        wm.Weight = 60.567;
        Console.WriteLine($"3. DisplayWeight con tara por defecto: {wm.DisplayWeight}"); 

        //Modificar el ajuste de tara
        wm.TareAdjustment = 10;
        Console.WriteLine($"4. DisplayWeight con tara = 10: {wm.DisplayWeight}"); 

        //Probando el manejo de excepción con peso negativo
        try
        {
            Console.WriteLine("\nIntentando asignar un peso negativo (-10)...");
            wm.Weight = -10;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Excepción capturada con éxito: {ex.ParamName} -> {ex.Message.Split('\n')[0]}");
        }
    }
}