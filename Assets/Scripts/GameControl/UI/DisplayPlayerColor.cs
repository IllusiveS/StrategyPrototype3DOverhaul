using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Zenject;

public class DisplayPlayerColor : MonoBehaviour {

	Image image;

	Player player;
	
	void Start()
	{
		image = GetComponentInChildren<Image> ();
	}
	void Update()
	{
		image.color = player.playerColor;
	}
	public void displayPlayer(Player pla)
	{
		player = pla;
	}
}
