using rpg_battle_system;

var player1 = new Character
{
    Name = "Player1",
    AttackPower = 10,
    Health = 120,
    CanAttack = character => character.Health > 0,
    OnDeath = BattleLogger.PrintDeath,
    DamageModifier = damage => (int)(damage * 0.5),
};

player1.OnAttack += (_, _) => SoundManager.PlaySound("Hit by player1");
player1.OnAttack += (_, eventArgs) => BattleLogger.PrintDamage(eventArgs.Target, eventArgs.Damage);
player1.OnHealthChanged += (character, _) => BattleLogger.PrintHealth(character);

var player2 = new Character
{
    Name = "Player2",
    AttackPower = 15,
    Health = 100,
    CanAttack = character => character.Health > 0,
    OnDeath = BattleLogger.PrintDeath,
    DamageModifier = _ => null,
};

player2.OnAttack += (_, _) => SoundManager.PlaySound("Hit by player2");
player2.OnAttack += (_, eventArgs) => BattleLogger.PrintDamage(eventArgs.Target, eventArgs.Damage);
player2.OnHealthChanged += (character, _) => BattleLogger.PrintHealth(character);

Console.WriteLine("--- Fight Begins ---");

while (player1.Health > 0 && player2.Health > 0)
{
    player1.Attack(player2);
    Console.WriteLine("----------------------");
    Thread.Sleep(1000);
    player2.Attack(player1);
}

Console.WriteLine("--- Fight End ---");
