using System;

namespace Ejercicio_Log_level
{
    static class LogLine{

        public static string Message(string logLine)
        {
            return logLine.Split(':')[1].Trim();
        }

        public static string LogLevel(string logLine)
        {
            int start = logLine.IndexOf('[') + 1;
            int end = logLine.IndexOf(']');

            string level = logLine.Substring(start, end - start);
            return level.ToLower();
        }

        public static string Reformat(string logLine)
        {
            string msg = Message(logLine);
            string level = LogLevel(logLine);

            return $"{msg} ({level})";
        }

      
    }

     class Program
    {
        static void Main()
        {
            string mensaje = LogLine.Message("[ERROR]: Invalid operation");
            Console.WriteLine(mensaje);

            string nivel = LogLine.LogLevel("[ERROR]: Invalid operation");
            Console.WriteLine(nivel);

            string reformateado = LogLine.Reformat("[ERROR]: Invalid operation");
            Console.WriteLine(reformateado);
        }
    }



}