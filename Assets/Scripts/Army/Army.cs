using System;
using UnityEngine;
using AdvancedInspector;
using System.Collections.Generic;
using Zenject;

[System.Serializable, AdvancedInspector]
public class Army : ITurnObserver, IUnitContainer, IOwnable
{
	public static Army selected = null;

	public UArmy uArmy;

	protected Player player;

	public Player Player {
		get {
			return player;
		}
	}

	[Inspect]
	public List<UUnit> units = new List<UUnit>();

	public bool isActive;
	public bool isItsTurn;
    [Inspect]
	public bool canAttack = true;

	int iMove;
	[Inspect, SerializeField]int iMoveMax;
	[Inspect, SerializeField]int iPlayerOwner;

	Node currentNode;

	[Inspect]
	public Algorithm movingAlgorithm = new Algorithm ();

	[Inspect, SerializeField]
	protected ZoneOfControlModule zocModule;

	public Army()
	{
		iMove = iMoveMax;
		movingAlgorithm.armyOwner = uArmy;
	}

	public void controlTheZone()
	{
		zocModule.updateZOC (this);
	}

	public void setUnits()
	{
	
	}
	public Army (int i, int speed, UArmy arm)
	{
		//movingAlgorithm.armyOwner = this;
		uArmy = arm;
	}

	public void attachToPlayer()
	{
		if (iPlayerOwner >= 0)
		{
			Player player = uArmy.control.getPlayer(iPlayerOwner);
			this.player = player;
			player.Attach (this);
		}
	}
	public void detachFromPlayer()
	{
		if (iPlayerOwner >= 0)
		{
			Player player = uArmy.control.getPlayer(iPlayerOwner);
			player.Detach(this);
		}
	}

	public void Update(int turn)
	{
		int player = turn % GameControl.MAX_PLAYERS;
		if(player == iPlayerOwner)
		{
			setIsItsTurn(true);
			iMove = iMoveMax;
			setCanAttack(true);
		}
		else
		{
			setCanAttack(false);
			setIsItsTurn(false);
			iMove = 0;
		}
	}

	public void selectArmy(Army army)
	{
		try
		{
			selected.setIsActive (false);
		}
		catch (System.NullReferenceException)
		{

		}
		if(army != null && isItsTurn)
		{
			selected = army;
			movingAlgorithm.GenerateGrid (army.currentNode, army.iMove);
			setIsActive(true);
			//TODO unit display
		}
		else
		{
			selected = null;
			//TODO unit display
			setIsActive(false);
			movingAlgorithm.ResetAllNodes();
		}

	}

	public void attackArmy(Army def)
	{
		List<UNode> trasa = Army.selected.getAlgorithm ().GenerateRoute (getNode (), def.getNode ());
		
        Army.selected.getUArmy().GetComponent<ArmyMovement>().setRoute(trasa);
	}

	public Node getNode()
	{
		return currentNode;
	}
	public void setNode(Node node)
	{
		currentNode = node;
        try {
			uArmy.node = node.getUnityNode ();
		} catch (System.NullReferenceException) {
			try {
				uArmy.node = null;
			} catch (Exception ex) {
				
			}
		}
	}

	public bool getIsActive()
	{
		return isActive;
	}
	public void setIsActive(bool boolean)
	{
		isActive = boolean;
	}

	public void setSpeed(int i)
	{
		iMove = i;
		uArmy.UpdateMovementDisplay ();
	}
	public int getSpeed()
	{
		return iMove;
	}

	public void setPlayer(int i)
	{
		iPlayerOwner = i;
	}
	public int getPlayer()
	{
		return iPlayerOwner;
	}

	public bool getIsItsTurn()
	{
		return isItsTurn;
	}
	public void setIsItsTurn(bool boolean)
	{
		isItsTurn = boolean;
	}

	public Algorithm getAlgorithm()
	{
		return movingAlgorithm;
	}

	public UArmy getUArmy()
	{
		return uArmy;
	}

	public List<Unit> getUnits()
	{
		List<Unit> units = new List<Unit> ();
		foreach(UUnit un in this.units)
		{
			units.Add(un.unit);
		}
		return units;
	}

	public void addUnit(Unit u)
	{
		units.Add (u.unityUnit);
		u.setPlayer (getPlayer ());
		u.owner = this.uArmy;
		u.armyModule.addUnit (this);
	}
	public void removeUnit(Unit u)
	{
		units.Remove(u.unityUnit);
		u.armyModule.removeUnit (this);
	}

	public int getOwner()
	{
		return iPlayerOwner;
	}
	public void setOwner(int i)
	{
		iPlayerOwner = i;
	}

	public int getGlory()
	{
		int glory = 0;
		foreach(UUnit un in units)
		{
			glory += un.unit.getGlory();
		}
		return glory;
	}

	public void setCanAttack(bool b)
	{
		canAttack = b;
	}
	public bool getCanAttack()
	{
		return canAttack;
	}
	public void addMovementModifier(Modifier mod)
	{
		movingAlgorithm.addMovementModifier (mod);
	}
	public void removeMovementModifier(Modifier mod)
	{
		movingAlgorithm.removeMovementModifier (mod);
	}
	public void checkForMovementModifier(TerrainType type)
	{
		movingAlgorithm.checkForMovementModifier (type);
	}
}
