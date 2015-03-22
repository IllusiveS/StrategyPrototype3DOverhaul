using UnityEngine;
using System.Collections;

public class Combat : ICombat, ICombatSituation{

	UCombat unityModule;

	Army atk;
	Army def;

	public void setUp(UCombat unity, Army atk, Army def)
	{
		unityModule = unity;
		this.atk = atk;
		this.def = def;
	}

	public Army CalculateWinner()
	{
		return null;
	}
	public void BeginCombat(Army atk, Army def)
	{

	}
	public void EndCombat()
	{

	}
	/// <summary>
	/// checks if the row of an army participating in combat is empty
	/// </summary>
	/// <returns><c>true</c>, if first row is empty, <c>false</c> otherwise.</returns>
	/// <param name="i">The player</param>
	public bool isFirstRowEmpty(int i)
	{
		bool empty = true;

		Army army;

		if(i == atk.getPlayer())
		{
			army = atk;
		}else
		{
			army = def;
		}

		foreach(Unit un in army.getUArmy().army.getUnits())
		{
			if(un.getXCoord() == 1)
			{
				empty = false;
			}
		}

		return empty;
	}
	
	public void FindAttackable(UnitCombat attacker)
	{
	}

	public Unit findUnit(int x, int y, int player)
	{
		Unit unit = null;

		Army army;

		if (player == this.atk.getPlayer ()) 
		{
			army = atk;
		}else
		{
			army = def;
		}

		foreach(Unit un in army.getUArmy().army.getUnits())
		{
			if(un.getXCoord() == x && un.getYCoord() == y)
			{
				unit = un;
			}
		}

		return unit;
	}

}
