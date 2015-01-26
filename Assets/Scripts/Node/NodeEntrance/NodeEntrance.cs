using System;

public class NodeEntrance
{
	public virtual int Enter(Node node, Army army)
	{
		army.setSpeed (army.getSpeed () - node.getCost());
		
		if (node.getArmy() == null)
		{
			node.setArmy(army);
			node.getUnityNode().army = army.getUArmy();
			army.setNode(node);
		}
		else
		{
			return -1;
		}
		return 0;
	}
}

