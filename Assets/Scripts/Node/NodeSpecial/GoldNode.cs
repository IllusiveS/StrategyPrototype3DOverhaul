using UnityEngine;
using System.Collections;
using AdvancedInspector;

[AdvancedInspector]
public class GoldNode : ResuorceNode{
	
	[Inspect, SerializeField]
	protected int moneyAmmount;

	public override int getMoneyGain (Player player)
	{
		return moneyAmmount;
	}

	public override void gatherResources (Player player)
	{
		player.addMoney (moneyAmmount);
	}
}

