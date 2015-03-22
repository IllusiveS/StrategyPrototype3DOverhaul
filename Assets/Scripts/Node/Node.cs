using System;
using UnityEngine;
using AdvancedInspector;
using System.Collections.Generic;

[System.Serializable, AdvancedInspector]
public class Node
{
    public string nodeClass;

    public UNode node;

	[Inspect, CreateDerived, SerializeField]
	protected NodeNormal nodeSpecial;

    [Inspect]
    public Army army = null;

    public int NeighboursNumber;

    public static Node Selected;

    public bool bWasVisited;
    public bool bIsActivated;

    [Inspect]
    public int iCost;
    [Inspect]
    public int iMoveLeft;

    public List<Node> Neighbours;

    public Node prevNode;

    public NodeCost costCalculator;
    [Inspect]
    public Status nodeStatus = Status.NOTHING;

	[Inspect]
	[Enum(true)]
	public TerrainType terrainType;

	[Inspect, SerializeField]
	protected nodeZOC zoneOfControl;
	[Inspect, SerializeField]
	protected nodeRecruitment recruit = new nodeRecruitment();

    public enum Status
    {
		FINAL,
        ROUTE,
        ATTACKABLE,
        PASSABLE,
        ENTERABLE,
        NOTHING
    }

    public Node(UNode node)
    {
        AllTheNodes.AccessAllNodeList().Add(this);
        this.node = node;
        setActive(Status.NOTHING);
    }
	public Node()
	{
		AllTheNodes.AccessAllNodeList().Add(this);
		setActive(Status.NOTHING);
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
        nodeSpecial.Enter(this, army);
		army.controlTheZone ();
    }
    public void Leave(Army army)
    {
        nodeSpecial.Leave(this, army);
    }

    public Army getArmy()
    {
		try {
			if (getUnityNode ().army == null)
				return null;
			else
				return getUnityNode ().army.army;
		} catch (Exception ex) {
			return null;
		}
    }
	public int getCost()
	{
		return iCost;
	}
    public int getCost(Army army)
    {
		return getCost (army.getAlgorithm ());
    }
	public int getCost(Algorithm algo)
	{
		int cost = -1;
		cost = algo.checkForMovementModifier (terrainType);
		if (cost == -1)
			cost = iCost;

		if(!zoneOfControl.isFriendly(algo.armyOwner.army))
			cost += 1;

		return cost;
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
        try
        {
            node.setActive(status);
        }
        catch (System.Exception)
        {
        }
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
		{
            army = null;
			getUnityNode().army = null;
		}	
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
            if (getArmy().getPlayer() != alg.armyOwner.army.getPlayer() && prev.nodeStatus == Status.ENTERABLE)
            {
                if (alg.armyOwner.army.getCanAttack())
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
            if (getArmy().getPlayer() == alg.armyOwner.army.getPlayer())
            {
                return true;
            }
        }
        return false;
    }
    public bool IsEnterable(Algorithm alg, Node prev)
    {
        if (getArmy() == null)
            return true;
        else
            return false;
	}

	public int getOwner ()
	{
		return nodeSpecial.getOwner ();
	}

	public void spreadInfluence(Army army)
	{
		zoneOfControl.spreadInfluence (army);
	}
	public void despreadInfluence(Army army)
	{
		zoneOfControl.despreadInfluence (army);
	}
	public List<UUnit> possibleRecruitments(Leader leader)
	{
		return recruit.possibleRecruitments (leader);
	}
}
