using UnityEngine;
using System.Collections;
using AdvancedInspector;

[System.Serializable, AdvancedInspector]
public class Unit : IUnit{

	public UUnit unityUnit;

	public UArmy owner;

	[Inspect]
	public string name;
	[Inspect]
	public string description
	{
		get
		{
			string str = "";
			if(combatModule.getIsFragile())
				str += "fragile\n";
			str += combatModule.getDescription();
			str += armyModule.getDescription();
			return str;
		}
	}
	[Inspect]
	public UnitCombat combatModule;
	[Inspect]
	public UnitArmy armyModule;

	[Inspect]
	public Sprite sprite;
	public Sprite desaturated;

	public Unit()
	{
	}

	public bool getIsSelectable()
	{
		return combatModule.getIsSelectable();
	}
	public void setIsSelectable(bool b)
	{
		combatModule.setIsSelectable (b);
	}

	public bool getIsAttackable()
	{
		return combatModule.getIsAttackable ();
	}

	public void setFragile(bool b)
	{
		combatModule.setFragile (b);
	}
	public bool getFragile()
	{
		return combatModule.getFragile ();
	}
	
	public int getPlayer()
	{
		return combatModule.getPlayer ();
	}
	public void setPlayer(int i)
	{
		combatModule.setPlayer (i);
	}
	
	public int getXCoord()
	{
		return combatModule.getXCoord ();
	}
	public void setXCoord(int i)
	{
		combatModule.setXCoord (i);
	}
	
	public int	getYCoord()
	{
		return combatModule.getYCoord ();
	}
	public void setYCoord(int i)
	{
		combatModule.setYCoord (i);
	}
	
	public int getStrength()
	{
		return combatModule.getStrength ();
	}
	public void setStrength(int i)
	{
		combatModule.setStrength (i);
	}
	
	public void Damage(int i)
	{
		combatModule.Damage (i);
	}
    public int getAttacks()
    {
        return combatModule.getAttacks();
    }
	public int getGlory()
	{
		return combatModule.getGlory ();
	}
	public void setGlory(int i)
	{
		combatModule.setGlory (i);
	}
	
	public bool canAttack(UnitCombat combat)
	{
		return combatModule.canAttack (combat);
	}
	
	public void attack(UnitCombat combat)
	{
		combatModule.attack (combat);
	}
	
	public void Select()
	{
		combatModule.Select ();
	}
	public bool Die()
	{
		return combatModule.Die ();
	}

    public AttackBase getCombatStrategy()
	{
		return combatModule.getCombatStrategy ();
	}
	public void setCombatStrategy(AttackBase a)
	{
		combatModule.setCombatStrategy (a);
	}

    public RangeBase getRangeStrategy()
	{
		return combatModule.getRangeStrategy ();
	}
    public void setRangeStrategy(RangeBase a)
	{
		combatModule.setRangeStrategy (a);
	}
	
	public ICombatSituation getCombatSituation()
	{
		return combatModule.getCombatSituation ();
	}
	public void setCombatSituation(ICombatSituation situation)
	{
		combatModule.setCombatSituation (situation);
	}

}
