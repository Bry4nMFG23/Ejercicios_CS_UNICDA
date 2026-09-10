using System;
public class QuestLogic
{
        public static bool CanFastAttack(bool KnightIsAwake)
    {
        return !KnightIsAwake;
    }

    public static bool CanSpy(bool KnightIsAwake, bool ArcherIsAwake, bool PrisionerIsAwake)
    {
        return KnightIsAwake || ArcherIsAwake || PrisionerIsAwake;
    }
    
    public static bool CanSignalPrisioner(bool ArcherIsAwake, bool PrisionerIsAwake)
    {
        return ArcherIsAwake && !PrisionerIsAwake;
    }

    public static bool CanFreePrisioner(bool KnightIsAwake, bool ArcherIsAwake, bool PrisionerIsAwake, bool petDogIsPresent)
    {
        if (petDogIsPresent)
        {
            return !ArcherIsAwake;
        }

        return !KnightIsAwake && !ArcherIsAwake && PrisionerIsAwake;
    }
 


}

//Probar el programa 
/*public class Program
{
    public static void Main()
    {
        bool KnightIsAwake = false;
        bool ArcherIsAwake = true;
        bool PrisionerIsAwake = false;

        Console.WriteLine(QuestLogic.CanFastAttack(KnightIsAwake));
    }
}*/