using UnityEngine;
using System.Collections;
using AdvancedInspector;

[AdvancedInspector]
public class LetThemRun : MonoBehaviour {

	protected Player owner;

	[Inspect, SerializeField]
	protected string name;

	void Start()
	{
		owner = GetComponent<Player> ();
	}

	public void letThemRun(UCombat combat, Army atk, Army def)
	{
		int points = 0;
		Army ownerArmy = null;
		Army otherArmy = null;
		if(atk.Player == owner)
		{
			ownerArmy = atk;
			otherArmy = def;
		}
		else
		{
			ownerArmy = def;
			otherArmy = atk;
		}

		if(combat.getWinningSide() == ownerArmy)
		{
			points = otherArmy.getUnits().Count;
		}
		if (points != 0)
			owner.addPoints (points, name);
	}

}
