using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Algorithm{

	public Army armyOwner;

	public AlgorithmCost roads;
	public AlgorithmCost plains;
	public AlgorithmCost forests;
	public AlgorithmCost cities;

	public int getRoadCost()
	{
		try
		{
			return roads.getCost();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
	public int getPlainsCost()
	{
		try
		{
			return plains.getCost();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
	public int getForestCost()
	{
		try
		{
			return forests.getCost();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}
	public int getCityCost()
	{
		try
		{
			return cities.getCost();
		}
		catch (System.NullReferenceException)
		{
			return -1;
		}
	}

	public void setRoadCost(AlgorithmCost cost)
	{
		roads = cost;
	}
	public void setPlainsCost(AlgorithmCost cost)
	{
		plains = cost;
	}
	public void setForestCost(AlgorithmCost cost)
	{
		forests = cost;
	}
	public void setCityCost(AlgorithmCost cost)
	{
		cities = cost;
	}

	public Algorithm()
	{
		roads = null;
		plains = null;
		forests = null;
		cities = null;
	}

	public void setArmyOwner(Army army)
	{
		armyOwner = army;
	}

	public void GenerateGrid(Node selected, int i)
	{
		ResetAllNodes ();
		SetStarting (selected, i);
		List<Node> nodes = new List<Node> ();
		nodes.Add (selected);
		IterateNodes (nodes);
	}

	public Node TryNode(Node start, Node end, int i)
	{
        if (end == null) { return null; }
        if (end.IsAttackable(this, start) && testViability(start, end, i))
        {
            end.setPrev(start);
            end.setActive(Node.Status.ATTACKABLE);
            end.setMoveLeft(i - end.getCost());
        }
        else
        if (end.IsEnterable(this, start) && testViability(start, end, i))
        {
            end.setPrev(start);
            end.setMoveLeft(i - end.getCost());
            end.setActive(Node.Status.ENTERABLE);
            end.setVisited(true);
            return end;
        }
        else
        if (end.IsPassable(this, start) && testViability(start, end, i))
        {
            end.setPrev(start);
            end.setActive(Node.Status.PASSABLE);
            end.setMoveLeft(i - end.getCost());
            end.setVisited(true);
            return end;
        }

        return null;
		
	}

	public bool testViability(Node start, Node end, int i)
	{
		return end.getCost () <= i && end.getMoveLeft() < i - end.getCost();
	}

	public List<UNode> GenerateRoute(Node start, Node end)
	{
		List<UNode> trasa = new List<UNode> ();
		trasa.Clear ();

		Node testedNode = end;

		do
		{
			trasa.Add(testedNode.getUnityNode());
			testedNode = testedNode.getPrev();
		}while (testedNode != null);
		trasa.Reverse ();
		trasa.RemoveAt(0);
		return trasa;

	}

	public void ResetAllNodes()
	{
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Terrain"))
		{
			Node node = obj.GetComponent<UNode>().node;
			node.setActive(Node.Status.NOTHING);
			node.setVisited(false);
			node.setPrev(null);
			node.setMoveLeft(-1);
		}
	}
	public void SetStarting(Node selected, int i)
	{
		selected.setVisited (true);
        selected.setActive(Node.Status.NOTHING);
		selected.setPrev (null);
		selected.setMoveLeft (i);
	}
	public void IterateNodes(List<Node> nodes)
	{
		do {
			List<Node> neighs = nodes[0].getNeighbours();
			for(int i = 0; i < 4; i++)
			{
				Node NodeNeigh;
				try {
					NodeNeigh = neighs[i];
				} catch (System.NullReferenceException) {
					continue;
				}
				if(NodeNeigh == null) {continue;}
				Node next = TryNode (nodes[0], NodeNeigh, nodes[0].getMoveLeft ());
				if (next != null) 
				{
					nodes.Add (next);
                    next.setVisited(true);
				}
			}
			nodes.RemoveAt(0);
		} while(nodes.Count > 0);
	}
}
