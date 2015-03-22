using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DisplayPlayerStatuses : MonoBehaviour {

	protected List<Player> players = new List<Player>();
	protected DisplayPlayerStatus[] statuses;

	// Use this for initialization
	void Start () {
		statuses = GetComponentsInChildren<DisplayPlayerStatus> ();
		players = GetComponentInParent<GameControl> ().playersList;
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < players.Count; i++)
		{
			statuses[i].setPlayer(players[i]);
		}
	}
}
