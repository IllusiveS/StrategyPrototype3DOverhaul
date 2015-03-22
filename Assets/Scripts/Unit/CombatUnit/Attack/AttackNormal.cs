using System;
using AdvancedInspector;

[System.Serializable]
public class AttackNormal : AttackBase
{
    public override void Attack(UnitCombat attacker, UnitCombat defender)
    {
        defender.Damage(attacker.getStrength());
    }
}