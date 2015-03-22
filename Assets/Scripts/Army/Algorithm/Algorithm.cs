using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedInspector;

[System.Serializable, AdvancedInspector]
public class Algorithm{

	public UArmy armyOwner;

	[Inspect, SerializeField]
	protected List<Modifier> MovementModifiers = new List<Modifier>();

	public Algorithm()
	{

	}
	public Algorithm(Army army)
	{
		setArmyOwner (army);
	}

	public void setArmyOwner(Army army)
	{
		armyOwner = army.uArmy;
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
		if (end.IsEnterable(this, start) && testViability(start, end, i))
		{
			end.setPrev(start);
			end.setMoveLeft(i - end.getCost(this));
			end.setActive(Node.Status.ENTERABLE);
			end.setVisited(true);
			return end;
		}
		else
        if (end.IsAttackable(this, start) && testViability(start, end, i))
        {
            end.setPrev(start);
            end.setActive(Node.Status.ATTACKABLE);
			end.setMoveLeft(i - end.getCost(this));
        }
        else
        if (end.IsPassable(this, start) && testViability(start, end, i))
        {
            end.setPrev(start);
            end.setActive(Node.Status.PASSABLE);
			end.setMoveLeft(i - end.getCost(this));
            end.setVisited(true);
            return end;
        }

        return null;
		
	}

	public bool testViability(Node start, Node end, int i)
	{
		return end.getCost (this) <= i && end.getMoveLeft() < i - end.getCost(this);
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
		//trasa.RemoveAt (0);
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
        selected.setActive(Node.Status.ENTERABLE);
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
    public void DestinateNode(Army army, Node end)
    {
        List<UNode> trasa = GenerateRoute(army.getNode(), end);

        foreach (Node nod in AllTheNodes.AccessAllNodeList())
        {
            nod.setActive(Node.Status.NOTHING);
        }
        foreach (UNode nod in trasa)
        {
            nod.setActive(Node.Status.ENTERABLE);
        }
    }
	public void addMovementModifier(Modifier mod)
	{
		MovementModifiers.Add (mod);
	}
	public void removeMovementModifier(Modifier mod)
	{
		MovementModifiers.Remove (mod);
	}
	public int checkForMovementModifier(TerrainType type)
	{
		int modifier = -1;
		foreach(Modifier mod in MovementModifiers)
		{
			if((mod.terrainType & type) == mod.terrainType)
			{
				if(modifier < mod.modifiedSpeed)
					modifier = mod.modifiedSpeed;
			}
		}
		return modifier;
	}
}
