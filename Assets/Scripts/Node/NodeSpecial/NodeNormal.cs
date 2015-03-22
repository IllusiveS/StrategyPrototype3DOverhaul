using System;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

[System.Serializable]
public class NodeNormal : ComponentMonoBehaviour
{
    public virtual int Enter(Node node, Army army)
    {
		army.setSpeed(army.getSpeed() - node.getCost(army));

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
    public virtual void Leave(Node node, Army army)
    {
        node.setArmy(null);
        army.setNode(null);
    }

    public virtual int getOwner()
    {
        return -10;
    }
}

