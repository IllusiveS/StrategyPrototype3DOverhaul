using UnityEngine;
using System.Collections;

public class DisplayPlayerStatus : MonoBehaviour {

	protected Player player;

	protected DisplayPlayerPoints points;
	protected DisplayFood food;
	protected DisplayMoney money;
	protected DisplayPlayerColor color;

	// Use this for initialization
	void Start () {
		points = GetComponentInChildren<DisplayPlayerPoints> ();
		food = GetComponentInChildren<DisplayFood> ();
		color = GetComponentInChildren<DisplayPlayerColor> ();
	}
	
	// Update is called once per frame
	void Update () {
		points.displayPlayerPoints (player);
		food.displayPlayerFood (player);
		color.displayPlayer (player);
	}

	public void setPlayer (Player player)
	{
		this.player = player;
	}
}
