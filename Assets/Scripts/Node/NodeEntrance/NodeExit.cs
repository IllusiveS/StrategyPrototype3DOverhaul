using System;

public class NodeExit
{
	public virtual void Leave(Node node, Army army)
	{
		node.setArmy (null);
		army.setNode (null);
	}
}

