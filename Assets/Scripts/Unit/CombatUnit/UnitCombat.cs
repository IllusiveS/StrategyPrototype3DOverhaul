using System;
using UnityEngine;
using AdvancedInspector;
using System.Collections.Generic;

[System.Serializable, AdvancedInspector]
public class UnitCombat : ITurnObserver
{
	[Inspect, CreateDerived, SerializeField]
	protected AttackBase attackStrategy;

	[Inspect, CreateDerived, SerializeField]
	protected List<AttackBase> attacksStrategy;

	[Inspect, CreateDerived, SerializeField]
	protected RangeBase rangeStrategy;

	protected ICombatSituation situation;

	[Inspect, SerializeField]
	protected int XCoord;
	[Inspect, SerializeField]
	protected int YCoord;

	[Inspect, SerializeField]
    protected int Strength;
    [Inspect, SerializeField]
    protected int Attacks;
	[Inspect, SerializeField]
    protected int Glory;

	[Inspect, SerializeField]
	protected int Player;

    [Inspect, SerializeField]
	protected bool isAttackable = false;
	protected bool isDead = false;
    [Inspect, SerializeField]
	protected bool isSelectable = false;

	[Inspect]
	public bool isFragile;

	public bool getIsSelectable()
	{
		return isSelectable;
	}
	public void setIsSelectable(bool b)
	{
		isSelectable = b;
	}

	public bool getIsAttackable()
	{
		return isAttackable;
	}

	public bool getIsFragile ()
	{
		return isFragile;
	}

	public void setIsAttackable (bool b)
	{
		isAttackable = b;
	}

	public void setFragile(bool b)
	{
		isFragile = b;
	}
	public bool getFragile()
	{
		return isFragile;
	}

	public int getPlayer()
	{
		return Player;
	}
	public void setPlayer(int i)
	{
		Player = i;
	}

	public int getXCoord()
	{
		return XCoord;
	}
	public void setXCoord(int i)
	{
		XCoord = i;
	}
	
	public int getYCoord()
	{
		return YCoord;
	}
	public void setYCoord(int i)
	{
		YCoord = i;
	}
	
	public int getStrength()
	{
		return Strength;
	}
	public void setStrength(int i)
	{
		Strength = i;
		if (Strength <= 0)
			isDead = true;
	}
	public void Damage(int i)
	{
		if(isFragile)
		{
			setStrength(-1);
			return;
		}
		setStrength(getStrength() - i);
	}

	public int getGlory()
	{
		return Glory;
	}
	public void setGlory(int i)
	{
		Glory = i;
	}
	
	public bool canAttack(UnitCombat combat)
	{
		bool stuff = rangeStrategy.CanAttack (this, combat);
		return stuff;
	}
	
	public void attack(UnitCombat combat)
	{
		attackStrategy.Attack (this, combat);
        Attacks -= 1;
	}
	
	public void Select()
	{

	}
	public bool Die()
	{
		return isDead;
	}

    public AttackBase getCombatStrategy()
	{
		return attackStrategy;
	}
    public void setCombatStrategy(AttackBase a)
	{
		attackStrategy = (AttackNormal)a;
	}

    public RangeBase getRangeStrategy()
	{
		return rangeStrategy;
	}
	public void setRangeStrategy(RangeBase a)
	{
		rangeStrategy = (RangeBase)a;
	}

	public ICombatSituation getCombatSituation()
	{
		return situation;
	}
	public void setCombatSituation(ICombatSituation situation)
	{
		this.situation = situation;
	}
    public int getAttacks()
    {
        return Attacks;
    }
    public void setAttacks(int i)
    {
        Attacks = i;
		if(Attacks < 0)
			Attacks = 0;
    }
	public void Update (int turn)
	{
		isAttackable = false;

        if(situation == null)
        {
            if (turn == Player)
            {
                isSelectable = true;
            }
            else
            {
                isSelectable = false;
            }
        }
        else
        {
            if (turn == Player)
            {
                if (getAttacks() > 0)
                {
                    isSelectable = true;
                }
                else
                {
                    isSelectable = false;
                }
            }
            else
            {
                isSelectable = false;
            }
        }
	}

	public string getDescription ()
	{
		string str = "";
		str += rangeStrategy.getDescription ();
		str += attackStrategy.getDescription ();
		return str;
	}
}

