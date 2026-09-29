using System;

public class SimpleOperationException : Exception
{
    public SimpleOperationException(string message) : base(message)
    {
    }

    public SimpleOperationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class CalculatorConundrum
{
    public string Calculate(int operand1, int operand2, string operation)
    {
        //Validar si la operación es null
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation), "Operation cannot be null");
        }

        //Validar si está vacía
        if (operation == string.Empty)
        {
            throw new ArgumentException("Operation cannot be empty");
        }

        int result;

        //Evaluar la operación
        switch (operation)
        {
            case "+":
                result = operand1 + operand2;
                break;
            case "*":
                result = operand1 * operand2;
                break;
            case "/":
                try
                {
                    result = operand1 / operand2;
                }
                catch (DivideByZeroException e)
                {
                    throw new SimpleOperationException("Division by zero is not allowed", e);
                }
                break;
            default:
                throw new SimpleOperationException($"Operation '{operation}' does not exist");
        }

        //Retorna el formato que necesitamos: 16 + 51 = 67
        return $"{operand1} {operation} {operand2} = {result}";
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        var calculator = new CalculatorConundrum();

        //Operaciones exitosas
        Console.WriteLine(calculator.Calculate(16, 51, "+")); // Imprime: 67
        Console.WriteLine(calculator.Calculate(32, 6, "*"));  // Imprime: 192
        Console.WriteLine(calculator.Calculate(512, 4, "/")); // Imprime: 128

        Console.WriteLine("\n--- Pruebas de Excepciones ---");

        //Prueba de null
        try
        {
            calculator.Calculate(10, 1, null);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine($"Error capturado (null): {e.ParamName}");
        }

        //Prueba de operación vacía
        try
        {
            calculator.Calculate(10, 1, "");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Error capturado (vacío): {e.Message}");
        }

        //Prueba de operación inexistente
        try
        {
            calculator.Calculate(10, 1, "-");
        }
        catch (SimpleOperationException e)
        {
            Console.WriteLine($"Error capturado (operación no válida): {e.Message}");
        }

        //Prueba de división por cero
        try
        {
            calculator.Calculate(512, 0, "/");
        }
        catch (SimpleOperationException e)
        {
            Console.WriteLine($"Error capturado (división / 0): {e.Message}");
            Console.WriteLine($"Causa interna: {e.InnerException?.Message}");
        }
    }
}