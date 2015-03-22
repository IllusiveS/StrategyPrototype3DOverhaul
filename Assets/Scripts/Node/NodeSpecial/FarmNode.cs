using UnityEngine;
using System.Collections;
using AdvancedInspector;

[AdvancedInspector]
public class FarmNode : ResuorceNode{

	[Inspect, SerializeField]
	protected int foodAmmount;
	
	public override int getFoodGain (Player player)
	{
		return foodAmmount;
	}

	public override void gatherResources (Player player)
	{
		player.addFood (foodAmmount);
	}
}
