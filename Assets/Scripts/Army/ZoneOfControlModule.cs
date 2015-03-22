using System;
using UnityEngine;
using AdvancedInspector;
using System.Collections.Generic;

[System.Serializable, AdvancedInspector]
public class ZoneOfControlModule
{
	[Inspect]
	public int range;

	protected List<Node> controlledNodes = new List<Node>();

	public void updateZOC(Army army)
	{
		removeZoneOfControl (army);
		createZoneOfControl (army);

		updateZoneOfControl (army);
	}

	void removeZoneOfControl (Army army)
	{
		foreach (Node nod in controlledNodes) {
			nod.despreadInfluence (army);
		}
		controlledNodes.Clear ();
	}

	void createZoneOfControl (Army army)
	{
		List<Node> queue = new List<Node> ();
		List<Node> newQueue = new List<Node> ();
		controlledNodes.Add (army.getNode ());
		queue.Add (army.getNode ());
		for (int i = 0; i < range; i++) {
			foreach (Node neigh in queue) {
				foreach(Node nod in neigh.getNeighbours())
				{
					if(nod == null)
						continue;
					if (controlledNodes.Find (x => x == nod) == null) {
						controlledNodes.Add (nod);
						newQueue.Add(nod);
					}
				}
			}
			queue = newQueue;
		}
	}

	void updateZoneOfControl (Army army)
	{
		foreach (Node nod in controlledNodes) {
			nod.spreadInfluence (army);
		}
	}
}

