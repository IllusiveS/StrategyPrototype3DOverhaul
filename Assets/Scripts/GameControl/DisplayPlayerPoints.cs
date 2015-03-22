using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayPlayerPoints : MonoBehaviour {

	protected Player player;
	protected Text text;

	public void Start()
	{
		text = GetComponentInChildren<Text> ();
	}

	public void displayPlayerPoints(Player player)
	{
		text.text = player.getPoints ().ToString ();
	}
}
