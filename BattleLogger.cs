namespace rpg_battle_system;

public static class BattleLogger
{
    public static void PrintHealth(Character character) =>
        Console.WriteLine($"{character.Name} has {character.Health} health");
    
    public static void PrintDamage(Character character, int damage) =>
        Console.WriteLine($"{character.Name} took {damage} damage");
    
    public static void PrintDeath(string name) =>
        Console.WriteLine($"{name} is dead");
}