using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Zenject;

public class UCombat : MonoBehaviour, ITurnSubject {

	[Inject]
	GameControl control;

	public Sprite selectableSprite;
	public Sprite attackableSprite;

	public static UCombat singleton;

	public static UCombat getSingleton()
	{
		return singleton;
	}

	public ICombat combat;
	public ICombatSituation situation;

	public UArmy Attackers;
	public UArmy Defenders;

	public int currentPlayer;

	public List<ITurnObserver> units = new List<ITurnObserver> ();

	public int numberOfUnits;

	UCombatStart start;
	
	// Use this for initialization
	void Start () {
		singleton = this;
		GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceCamera;
		gainPointsDelegate += DeclareWinner;
	}

	// Update is called once per frame
	void Update () {
		numberOfUnits = units.Count;
	}

	public void setUpCombat(Army atk, Army def)
	{
		start = GetComponent<UCombatStart> ();

		Combat com = new Combat ();
		combat = com;
		situation = com;
		combat.setUp (this, atk, def);

		Attackers = atk.getUArmy ();
		Defenders = def.getUArmy ();

		currentPlayer = Attackers.army.getPlayer ();

		ArmyDisplayer[] displayers = GetComponentsInChildren<ArmyDisplayer> ();
		
		displayers [0].armyToDisplay = Attackers;
		displayers [1].armyToDisplay = Defenders;
		
		FormationOwner[] formations = GetComponentsInChildren<FormationOwner> ();
		
		formations [1].playerOwner = Attackers.army.getPlayer ();
		formations [0].playerOwner = Defenders.army.getPlayer ();

		foreach(Unit un in Attackers.army.getUnits())
		{
            un.combatModule.setXCoord(-1);
            un.combatModule.setYCoord(-1);
			Attach(un.combatModule);
		}
		foreach(Unit un in Defenders.army.getUnits())
		{
            un.combatModule.setXCoord(-1);
            un.combatModule.setYCoord(-1);
			Attach(un.combatModule);
		}
		start.setUp (Attackers, Defenders, units);

		DisplayPointsFill[] fills = GetComponentsInChildren<DisplayPointsFill> ();
		fills [0].displayArmyPoints (Attackers.army);
		fills [1].displayArmyPoints (Defenders.army);

		DisplayPointsNumber[] numbers = GetComponentsInChildren<DisplayPointsNumber> ();
		numbers [0].displayArmyInfo(Attackers.army);
		numbers [1].displayArmyInfo(Defenders.army);

		atk.Player.OnCombatBegin.Invoke (this, atk, def);
		def.Player.OnCombatBegin.Invoke (this, atk, def);
	}

	public void startCombat()
	{
		foreach(FormationPosition disp in GetComponentsInChildren<FormationPosition>())
        {
            disp.gameObject.AddComponent<CUnitCombat>();
        }
		Notify (currentPlayer);
	}

	///
	///ITURNSUBJECT
	///
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
	public void checkAttackable(UnitCombat attacker)
	{
		List<UnitCombat> unitsInFight = new List<UnitCombat> ();

		foreach(Unit un in Attackers.army.getUnits())
		{
			unitsInFight.Add(un.combatModule);
		}
		foreach(Unit un in Defenders.army.getUnits())
		{
			unitsInFight.Add(un.combatModule);
		}

		foreach(UnitCombat un in unitsInFight)
		{
			if(CUnitCombat.selected.canAttack(un))
				un.setIsAttackable(true);
			else
				un.setIsAttackable(false);
		}
	}

	public void changePlayer()
	{
		UArmy nextPlayer;

		if (currentPlayer == Attackers.army.getPlayer())
		{
			nextPlayer = Defenders;
		}else
		{
			nextPlayer = Attackers;
		}
		if(IsThereAWinner())
		{
			EndCombat();
			return;
		}
		if(AllUnitsHaveMoved())
		{
			EndCombat();
			return;
		}
		if(NextPlayerHaveMoved(nextPlayer))
		{
			Notify(currentPlayer);
		}else
		{
			currentPlayer = nextPlayer.army.getPlayer();
			Notify(currentPlayer);
		}
	}

	public bool NextPlayerHaveMoved(UArmy nextPlayer)
	{
		bool allMoved = true;
		foreach(Unit un in nextPlayer.army.getUnits())
		{
			if (un.combatModule.getAttacks() > 0)
				allMoved = false;
		}
		return allMoved;
	}
	public bool AllUnitsHaveMoved()
	{
		List<UUnit> units = new List<UUnit> ();

		bool allMoved = true;

		foreach(Unit un in Attackers.army.getUnits())
		{
			units.Add(un.unityUnit);
		}
		foreach(Unit un in Defenders.army.getUnits())
		{
			units.Add(un.unityUnit);
		}
		foreach(UUnit un in units)
		{
			if (un.unit.combatModule.getAttacks() > 0)
				allMoved = false;
		}

		return allMoved;
	}

	public bool IsThereAWinner()
	{
		List<UUnit> units = new List<UUnit> ();
		
		bool allMoved = false;
		
		if (Attackers.army.getUnits().Count == 0)
		{
			allMoved = true;
		}
		if(Defenders.army.getUnits().Count == 0)
		{
			allMoved = true;
		}

		return allMoved;
	}

	public void EndCombat()
	{
		int attackerGlory = 0;
		int defenderGlory = 0;

		Attackers.army.Player.OnCombatEnd.Invoke (this, Attackers.army, Defenders.army);
		Defenders.army.Player.OnCombatEnd.Invoke (this, Attackers.army, Defenders.army);

		foreach(Unit un in Attackers.army.getUnits())
		{
			attackerGlory += un.getGlory();
		}

		foreach(Unit un in Defenders.army.getUnits())
		{
			defenderGlory += un.getGlory();
		}

		if(attackerGlory > defenderGlory)
		{
			DeclareWinner(Attackers, Defenders, attackerGlory - defenderGlory);
		}
		else
		{
			DeclareWinner(Defenders, Attackers, defenderGlory - attackerGlory);
		}

		if (Attackers.army.getUnits().Count == 0)
		{
			Destroy (Attackers.gameObject);
		}
		if(Defenders.army.getUnits().Count == 0)
		{
			Destroy (Defenders.gameObject);
		}

		Destroy (gameObject);
	}

	public Army getWinningSide()
	{
		int attackerGlory = 0;
		int defenderGlory = 0;

		foreach(Unit un in Attackers.army.getUnits())
		{
			attackerGlory += un.getGlory();
		}
		
		foreach(Unit un in Defenders.army.getUnits())
		{
			defenderGlory += un.getGlory();
		}
		
		if(attackerGlory > defenderGlory)
		{
			return Attackers.army;
		}
		else
			return Defenders.army;
	}

	public delegate void gainPoints(UArmy winner, UArmy loser, int points);

	public gainPoints gainPointsDelegate = null;

	protected void DeclareWinner(UArmy winner, UArmy loser, int points)
	{
		winner.army.Player.addPoints (winner.army.getGlory () - loser.army.getGlory (), "Battle glory");
		winner.army.Player.addPoints (2, "Battle victory");
	}

	public void CheckDeaths()
	{
		List<UUnit> dupa = new List<UUnit> ();

		foreach(Unit un in Attackers.army.getUnits())
		{
			dupa.Add(un.unityUnit);
		}
		
		foreach(Unit un in Defenders.army.getUnits())
		{
			dupa.Add(un.unityUnit);
		}

		foreach(UUnit un in dupa)
		{
			if (un.unit.Die())
			{
				UCombat.getSingleton().Detach(un.unit.combatModule);
				un.unit.owner.army.removeUnit(un.unit);
				Destroy(un.gameObject);
			}
			//un.GetComponent<UCombatUnitModule>().attackable = false;
		}
	}
	public int getGlory()
	{
		int glory = 0;

		foreach(Unit un in Attackers.army.getUnits())
		{
			glory += un.getGlory();
		}
		foreach(Unit un in Defenders.army.getUnits())
		{
			glory += un.getGlory();
		}

		return glory;
	}
	void OnDestroy()
	{
		singleton = null;
	}
}
