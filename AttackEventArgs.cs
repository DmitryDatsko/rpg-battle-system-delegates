namespace rpg_battle_system;

public class AttackEventArgs : EventArgs
{
    public required Character Attacker { get; set; }
    public required Character Target { get; init; }
    public int Damage { get; init; }
    public bool IsCritical { get; set; }
}