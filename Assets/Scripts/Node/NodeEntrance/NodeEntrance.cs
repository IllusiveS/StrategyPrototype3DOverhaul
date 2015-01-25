using System;

public class NodeEntrance
{
	public virtual int Enter(Node node, Army army)
	{
		army.setSpeed (army.getSpeed () - node.getCost());
		
		if (node.getArmy() == null)
		{
			node.setArmy(army);
			army.setNode(node.getUnityNode().node);
		}
		else
		{
			return -1;
		}
		return 0;
	}
}

