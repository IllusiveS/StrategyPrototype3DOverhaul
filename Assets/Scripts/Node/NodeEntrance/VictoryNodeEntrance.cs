using System;

public class VictoryNodeEntrance : NodeEntrance
{
	public override int Enter(Node node, Army army)
	{
		if(base.Enter (node, army) == 0)
			node.getUnityNode ().GetComponent<UVictoryPoint> ().setOwner (army.getPlayer ());
		return 0;
	}
}