using UnityEngine;
using AdvancedInspector;
using System.Collections;
using System.Collections.Generic;

[AdvancedInspector]
public class RecruitmentDisplay : MonoBehaviour {

	public static RecruitmentDisplay display;

	protected Player player;
	protected Node node;

	// Use this for initialization
	void Start () {
		if(display != null)
			Destroy(display.gameObject);
		display = this;
	}
	
	// Update is called once per frame
	void Update () {
		UnitDisplayer[] displayers = GetComponentsInChildren<UnitDisplayer> ();
		List<UnitDisplayer> displayersList = new List<UnitDisplayer> ();
		List<UUnit> units = new List<UUnit>();
		try {
			units = node.possibleRecruitments (player.PlayerLeader);
		} catch (System.Exception ex) {
	
		}

		foreach(UnitDisplayer disp in displayers)
		{
			displayersList.Add(disp);
		}
		for(int i = 0; i < displayersList.Count; i++)
		{
			try {
				displayersList[i].unitToDisplay = units[i];
			} catch (System.Exception ex) {
				
			}
		}
	}

	void OnDestroy()
	{
		display = null;
	}

	public Player recruitingPlayer
	{
		set
		{
			player = value;
		}
	}
	public Node recrutimentNode
	{
		set
		{
			this.node = value;
		}
	}

}
