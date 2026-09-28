using System;

abstract class Character
{
    private readonly string _characterType;

    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }

    public virtual bool Vulnerable()
    {
        return false;
    }

    public abstract int DamagePoints(Character target);
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool _spellPrepared = false;

    public Wizard() : base("Wizard")
    {
    }

    public void PrepareSpell()
    {
        _spellPrepared = true;
    }

    public override bool Vulnerable()
    {
        return !_spellPrepared;
    }

    public override int DamagePoints(Character target)
    {
        return _spellPrepared ? 12 : 3;
    }
}

class Program
{
    static void Main()
    {
        var warrior = new Warrior();
        var wizard = new Wizard();

        Console.WriteLine(warrior.ToString()); 
        Console.WriteLine(wizard.ToString());  

        Console.WriteLine($"¿Wizard vulnerable antes de preparar hechizo?: {wizard.Vulnerable()}"); 
        Console.WriteLine($"Daño de Warrior a Wizard sin hechizo: {warrior.DamagePoints(wizard)}"); 

        wizard.PrepareSpell();

        Console.WriteLine($"¿Wizard vulnerable tras preparar hechizo?: {wizard.Vulnerable()}"); 
        Console.WriteLine($"Daño de Wizard a Warrior: {wizard.DamagePoints(warrior)}"); 
        Console.WriteLine($"Daño de Warrior a Wizard con hechizo: {warrior.DamagePoints(wizard)}"); 
    }
}
