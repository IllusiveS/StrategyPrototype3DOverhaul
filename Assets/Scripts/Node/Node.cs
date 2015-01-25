using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Node
{

    public UNode node;

    public NodeEntrance entrance;
    public NodeExit exit;

    public Army army = null;

    public int NeighboursNumber;

    public static Node Selected;

    public bool bWasVisited;
    public bool bIsActivated;

    public int iCost;
    public int iMoveLeft;

    public List<Node> Neighbours;

    public Node prevNode;

    public NodeCost costCalculator;

    public Status nodeStatus;

    public enum Status
    {
        ATTACKABLE,
        PASSABLE,
        ENTERABLE,
        NOTHING
    }

    public Node(UNode node)
    {
        AllTheNodes.AccessAllNodeList().Add(this);
        this.node = node;

        entrance = new NodeEntrance();
        exit = new NodeExit();
    }

    public void SelectNode(Node selected, Algorithm algorytm)
    {
        if (selected.getActive())
        {
            DestinateNode(selected, algorytm);
            return;
        }
        Node.Selected = selected;
        algorytm.GenerateGrid(this, 3);
    }

    public void DestinateNode(Node selected, Algorithm algorytm)
    {
        List<UNode> trasa = algorytm.GenerateRoute(Selected, selected);

        foreach (Node nod in AllTheNodes.AccessAllNodeList())
        {
            nod.setActive(Status.NOTHING);
        }
        foreach (UNode nod in trasa)
        {
            nod.setActive(Status.ENTERABLE);
        }
    }

    public void Enter(Army army)
    {
        entrance.Enter(this, army);
    }
    public void Leave(Army army)
    {
        exit.Leave(this, army);
    }

    public Army getArmy()
    {
        return army;
    }
    public int getCost()
    {
        return iCost;
    }
    public Node getPrev()
    {
        return prevNode;
    }
    public List<Node> getNeighbours()
    {
        return Neighbours;
    }
    public bool getVisited()
    {
        return bWasVisited;
    }
    public bool getActive()
    {
        return bIsActivated;
    }
    public int getMoveLeft()
    {
        return iMoveLeft;
    }
    public UNode getUnityNode()
    {
        return node;
    }

    public void setUnityNode(UNode n)
    {
        node = n;
    }

    public void setCost(int i)
    {
        iCost = i;
    }
    public void setPrev(Node node)
    {
        prevNode = node;
    }
    public void setNeighbours(List<Node> list)
    {
        Neighbours = list;
        NeighboursNumber = list.Count;
    }
    public void setVisited(bool b)
    {
        bWasVisited = b;
    }
    public void setActive(Status status)
    {
        node.setActive(status);
        this.nodeStatus = status;
    }
    public void setMoveLeft(int i)
    {
        iMoveLeft = i;
    }
    public void setArmy(Army army)
	{
		this.army = army;

		if(army == null)
			getUnityNode().army = null;
		else
		{
			army.setNode(this);
			getUnityNode().army = army.uArmy;
		}

        
	}

    public bool isReachable()
    {
        return bIsActivated;
    }
    public bool IsAttackable(Algorithm alg, Node prev)
    {
        if (getArmy() != null)
        {
            if (getArmy().getPlayer() != alg.armyOwner.getPlayer() && prev.bIsActivated)
            {
                if (alg.armyOwner.getCanAttack())
                    return true;
                else
                    return false;
            }
        }
        return false;
    }
    public bool IsPassable(Algorithm alg, Node prev)
    {
        if (getArmy() != null)
        {
            if (getArmy().getPlayer() == alg.armyOwner.getPlayer())
            {
                return true;
            }
        }
        return false;
    }
    public bool IsEnterable(Algorithm alg, Node prev)
    {
        if (getUnityNode().army == null)
            return true;
        else
            return false;
    }
}
