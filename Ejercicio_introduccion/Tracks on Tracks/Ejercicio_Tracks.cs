using System;
using System.Collections.Generic;
using System.Linq;

public static class Languages
{
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        return new List<string> { "C#", "Clojure", "Elm" };
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        if (languages.Count == 0)
        {
            return false;
        }

        // Condición 1: El primero es C#
        if (languages[0] == "C#")
        {
            return true;
        }

        if (languages.Count >= 2 && languages.Count <= 3 && languages[1] == "C#")
        {
            return true;
        }

        return false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        return languages.Distinct().Count() == languages.Count;
    }
}

class Program
{
    static void Main()
    {
        List<string> Lista1 = Languages.NewList();

        Console.WriteLine(string.Join(", ", Lista1));
        Console.WriteLine(string.Join(", ", Languages.GetExistingLanguages()));

        Console.WriteLine(string.Join(", ", Languages.AddLanguage(Lista1,"VBA")));
    }
}