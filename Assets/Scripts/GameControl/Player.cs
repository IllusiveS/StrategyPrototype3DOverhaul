using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using AdvancedInspector;
using Zenject;

[AdvancedInspector, Serializable]
public class Player : MonoBehaviour, ITurnObserver, ITurnSubject, IVictoryPointsSubject
{

	[System.Serializable]
	public class CombatEvent : UnityEvent <UCombat, Army, Army> {}

	[Inspect]
	public CombatEvent OnCombatBegin;
	[Inspect]
	public CombatEvent OnCombatEnd;

	[Inspect, SerializeField]
	protected string name;

	public string Name {
		get {
			return name;
		}
	}

	[Inspect, SerializeField]
	private int PlayerNumber;
	private int currentPlayer;

	[Inspect, SerializeField]
	protected Leader leader;

	public Color playerColor;

	protected int Glory = 0;

	public delegate void addPointsToPlayer(int points, string reason, Player player);

	[SerializeField]
	protected addPointsToPlayer addPointsDelegate = null;

	public void addPointsToPlayerDelegate(addPointsToPlayer del)
	{
		addPointsDelegate += del;
	}
	public void removePointsToPlayerDelegate(addPointsToPlayer del)
	{
		addPointsDelegate -= del;
	}

	[Inspect]
	private List<ITurnObserver> armies = new List<ITurnObserver>();
	private List<IVictoryPointsObserver> victoryPlaces = new List<IVictoryPointsObserver> ();
	private List<IResuorceSource> resourceNodes = new List<IResuorceSource> ();

	[Inspect, SerializeField]
	protected int food;
	[Inspect, SerializeField]
	protected int money;

	public Player (int i)
	{
		PlayerNumber = i;
	}
	public Player()
	{
		addPointsDelegate += addVictoryPoints;
	}

	public void addPoints(int points, string reason)
	{
		addPointsDelegate (points, reason, this);
	}
	protected void addVictoryPoints(int points, string reason, Player player)
	{
		Glory += points;
	}

	public int getPlayerNumber()
	{
		return PlayerNumber;
	}

	public void Attach(ITurnObserver obs)
	{
		armies.Add (obs);
	}
	public void Detach(ITurnObserver obs)
	{
		armies.Remove (obs);
	}
	
	public void Notify(int turn)
	{
		foreach(ITurnObserver obs in armies)
		{
			obs.Update(turn);
		}
	}
	

	void ITurnObserver.Update (int turn)
	{
		Notify (turn);
		currentPlayer = turn;
	}

	public void Attach(IVictoryPointsObserver obs)
	{
		victoryPlaces.Add (obs);
	}

	public void Detach(IVictoryPointsObserver obs)
	{
		victoryPlaces.Remove (obs);
	}

	public int getPoints()
	{
		int points = 0;

		foreach(IVictoryPointsObserver obs in victoryPlaces)
		{
			points += obs.getPoints(this);
		}

		points += Glory;

		return points;
	}
	public string ColorToHex()
	{
		Color32 color = this.playerColor;
		string hex = color.r.ToString("X2").ToLower() + color.g.ToString("X2").ToLower() + color.b.ToString("X2").ToLower() + "ff";
		return hex;
	}
	public void addFood (int resourceAmmount)
	{
		food += resourceAmmount;
	}
	public void addMoney(int resourceAmmount)
	{
		money += resourceAmmount;
	}
	public void Attach(IResuorceSource source)
	{
		resourceNodes.Add (source);
	}
	public void Detach(IResuorceSource source)
	{
		resourceNodes.Remove (source);
	}
	public int Food {
		get { return food; }
	}
	public int Money{
		get { return money; }
	}
	public int FoodGain
	{
		get
		{
			int ammount = 0;
			foreach(IResuorceSource res in resourceNodes)
			{
				ammount += res.getFoodGain(this);
			}
			ammount -= UsedFood(armies.Count);
			return ammount;
		}
	}
	protected int UsedFood(int ammount)
	{
		if (ammount <= 0)
				return 0;
		if (ammount <= 1)
				return 1;
		return UsedFood (ammount - 1) + UsedFood (ammount - 2);
	}
	public int MoneyGain
	{
		get
		{
			int ammount = 0;
			foreach(IResuorceSource res in resourceNodes)
			{
				ammount += res.getMoneyGain(this);
			}
			return ammount;
		}
	}
	public void gatherResources()
	{
		foreach(IResuorceSource res in resourceNodes)
		{
			res.gatherResources(this);
		}
	}

	public Leader PlayerLeader
	{
		get
		{
			return leader;
		}
	}
}
