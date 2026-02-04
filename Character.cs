namespace rpg_battle_system;

public class Character
{
    private const int MaxHealth = 100;
    public required string Name { get; set; }
    private int _health;
    public required int Health
    {
        get => _health;
        init => _health = value > MaxHealth ? MaxHealth : value;
    }

    public required int AttackPower { get; set; }
    
    public delegate void HealthChangedDelegate(Character character, int damage);
    
    public event HealthChangedDelegate? OnHealthChanged;
    public event EventHandler<AttackEventArgs>? OnAttack;
    public required Action<string> OnDeath;
    public required Func<int, int?> DamageModifier;
    public required Predicate<Character> CanAttack;

    public void TakeDamage(int damage)
    {
        if (_health <= 0) OnDeath.Invoke(Name);
        
        _health -= damage;
        if (_health <= 0)
        {
            OnDeath.Invoke(Name);
        }
        OnHealthChanged?.Invoke(this, damage);
    }
    
    public void Attack(Character target)
    {
        if(!CanAttack.Invoke(this)) return;
        
        var rnd = Random.Shared.Next(1, 5);
        var damage = rnd > 2 ? AttackPower * 2 : AttackPower;
        var actualDamage = target.DamageModifier.Invoke(damage) ?? damage;
        
        OnAttack?.Invoke(this, new AttackEventArgs
        {
            Attacker = this,
            Target = target,
            Damage = actualDamage,
            IsCritical = rnd > 2
        });
        target.TakeDamage(actualDamage);
    }
}