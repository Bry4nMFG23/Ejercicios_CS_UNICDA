using System;
using System.Collections.Generic;

namespace InternationalCallingConnoisseur
{
    public static class DialingCodes
    {
        // Devuelve un diccionario vacío
        public static Dictionary<int, string> GetEmptyDictionary()
        {
            return new Dictionary<int, string>();
        }

        //Devuelve un diccionario precargado con EE. UU. (1), Brasil (55) e India (91)
        public static Dictionary<int, string> GetExistingDictionary()
        {
            return new Dictionary<int, string>
            {
                { 1, "United States of America" },
                { 55, "Brazil" },
                { 91, "India" }
            };
        }

        //Crea un diccionario y le agrega un país
        public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
        {
            var dict = GetEmptyDictionary();
            dict.Add(countryCode, countryName);
            return dict;
        }

        //Agrega un país a un diccionario existente
        public static Dictionary<int, string> AddCountryToExistingDictionary(
            Dictionary<int, string> existingDictionary, int countryCode, string countryName)
        {
            existingDictionary.Add(countryCode, countryName);
            return existingDictionary;
        }

        //Obtiene el nombre del país o string.Empty si no existe
        public static string GetCountryNameFromDictionary(
            Dictionary<int, string> existingDictionary, int countryCode)
        {
            if (existingDictionary.TryGetValue(countryCode, out string countryName))
            {
                return countryName;
            }
            return string.Empty;
        }

        //Verifica si una clave existe en el diccionario
        public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
        {
            return existingDictionary.ContainsKey(countryCode);
        }

        // Actualiza el nombre del país si el código existe
        public static Dictionary<int, string> UpdateDictionary(
            Dictionary<int, string> existingDictionary, int countryCode, string countryName)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary[countryCode] = countryName;
            }
            return existingDictionary;
        }

        // Elimina un registro del diccionario
        public static Dictionary<int, string> RemoveCountryFromDictionary(
            Dictionary<int, string> existingDictionary, int countryCode)
        {
            existingDictionary.Remove(countryCode);
            return existingDictionary;
        }

        //Encuentra el nombre del país más largo almacenado
        public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
        {
            string longestName = string.Empty;

            foreach (var countryName in existingDictionary.Values)
            {
                if (countryName.Length > longestName.Length)
                {
                    longestName = countryName;
                }
            }

            return longestName;
        }
    }

    //Programa de inicializacion del programa
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Pruebas de DialingCodes ---");

            //Prueba Diccionario precargado
            var dict = DialingCodes.GetExistingDictionary();
            Console.WriteLine($"Conteo inicial: {dict.Count} países");

            //Prueba agregar país
            DialingCodes.AddCountryToExistingDictionary(dict, 44, "United Kingdom");
            Console.WriteLine($"País con código 44: {DialingCodes.GetCountryNameFromDictionary(dict, 44)}");

            //Prueba verificar existencia
            Console.WriteLine($"¿Existe el código 55 (Brasil)?: {DialingCodes.CheckCodeExists(dict, 55)}");

            //Prueba actualizar nombre
            DialingCodes.UpdateDictionary(dict, 1, "Les États-Unis");
            Console.WriteLine($"Código 1 actualizado: {dict[1]}");

            //País con el nombre más largo
            string longest = DialingCodes.FindLongestCountryName(dict);
            Console.WriteLine($"Nombre más largo: {longest}");

            //Prueba eliminar país
            DialingCodes.RemoveCountryFromDictionary(dict, 91);
            Console.WriteLine($"¿Existe el código 91 tras eliminarlo?: {DialingCodes.CheckCodeExists(dict, 91)}");
        }
    }
}