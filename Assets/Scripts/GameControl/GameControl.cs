using UnityEngine;
using System.Collections;
using Zenject;
using System.Collections.Generic;
using AdvancedInspector;

[AdvancedInspector]
public class GameControl : MonoBehaviour, ITurnSubject {

	private bool started = false;

	public static int winner;

	[Inspect, SerializeField]
	public List<Player> playersList = new List<Player>();

	public void Attach(ITurnObserver obs)
	{
		players.Add (obs);
	}
	public void Detach(ITurnObserver obs)
	{
		players.Remove (obs);
	}
	
	public void Notify(int turn)
	{
		foreach(ITurnObserver obs in playersList)
		{
			obs.Update(turn);
		}
	}

	void Awake()
	{

	}
	public Player getPlayer(int i)
	{
		return playersList [i];
	}
	public Player getCurrentPlayer()
	{
		return getPlayer (iTurn % MAX_PLAYERS);
	}
	void Start()
	{
		for(int i = 0; i < MAX_PLAYERS; i++)
		{
			getPlayer(i).playerColor = GetComponent<PlayerTextureSelection>().playerColors[i];
		}
	}

	public static int MAX_PLAYERS = 2;

	public int iTurn = 0;
	public int gameTurn = 1;
	[Inspect]
	public int maxTurns;
	public int iPlayers;

	public List<ITurnObserver> players = new List<ITurnObserver> ();

	//Przycisk tury
	void OnGUI() {
		if(!started)
		{
			Notify (iTurn);
			started = true;
		}
	}

	public void endGame()
	{
		if(getPlayer(0).getPoints() > getPlayer(1).getPoints())
		{
			winner = 0;
		}
		else
			winner = 1;

		//Application.LoadLevel ("EndGame");
	}

	public void passTurn ()
	{
		iTurn++;
		if (iTurn % MAX_PLAYERS == 0)
			gameTurn++;
		if (gameTurn > maxTurns) {
			endGame ();
		}
		Notify (iTurn);
		try {
			Army.selected.selectArmy (null);
			CNode.trasa.Clear ();
		}
		catch (System.NullReferenceException) {
		}
	}

	public class Factory : GameObjectFactory<GameControl>
	{
	}
}
