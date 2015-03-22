using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UCombatStart : MonoBehaviour, ITurnSubject {
	public UArmy Attackers;
	public UArmy Defenders;

	public float offset;

	public List<ITurnObserver> units = new List<ITurnObserver> ();
	public int currentPlayer;

	// Use this for initialization
	void Start () {
        foreach(FormationDropper drop in GetComponentsInChildren<FormationDropper>())
        {
            drop.setCombatController(this);
        }
	}

	public void setUp(UArmy attackers, UArmy defenders, List<ITurnObserver> units)
	{
		Attackers = attackers;
		Defenders = defenders;

		this.units = units;
        
		currentPlayer = attackers.army.getPlayer ();

        Notify(currentPlayer);
	}

	public void PlaceUnit()
	{
		if(allUnitsArePlaced())
		{
			startCombat();
		}
		if(otherPlayerPlacedAll())
		{
			return;
		}
		if(currentPlayer == Attackers.army.getPlayer())
		{
			currentPlayer = Defenders.army.getPlayer();
		}
		else
		{
			currentPlayer = Attackers.army.getPlayer();
		}
		Notify (currentPlayer);
	}

	bool otherPlayerPlacedAll()
	{
		List<UnitCombat> lista = new List<UnitCombat> ();

		UArmy otherArmy;

		if(currentPlayer == Attackers.army.getPlayer())
		{
			otherArmy = Defenders;
		}
		else
		{
			otherArmy = Attackers;
		}

		foreach(Unit un in otherArmy.army.getUnits())
		{
			lista.Add(un.combatModule);
		}

		bool allPlaced = true;

		foreach(UnitCombat un in lista)
		{
			if (un.getXCoord() == -1 && un.getYCoord() == -1)
				allPlaced = false;
		}

		return allPlaced;
	}

	bool allUnitsArePlaced()
	{
		List<UnitCombat> lista = new List<UnitCombat> ();

		foreach(Unit un in Attackers.army.getUnits())
		{
			lista.Add(un.combatModule);
		}
		foreach(Unit un in Defenders.army.getUnits())
		{
			lista.Add(un.combatModule);
		}
		
		bool allPlaced = true;
		
		foreach(UnitCombat un in lista)
		{
			if (un.getXCoord() == -1 && un.getYCoord() == -1)
				allPlaced = false;
		}
		
		return allPlaced;
	}

	void startCombat()
	{
		foreach(ArmyDisplayer disp in GetComponentsInChildren<ArmyDisplayer>())
		{
			Destroy(disp.gameObject);
		}

		UCombat.getSingleton ().startCombat ();
	}

	public void Attach(ITurnObserver obs)
	{
		units.Add (obs);
	}
	public void Detach(ITurnObserver obs)
	{
		units.Remove (obs);
	}
	
	public void Notify(int turn)
	{
		foreach(ITurnObserver obs in units)
		{
			obs.Update (turn);
		}
	}
}
