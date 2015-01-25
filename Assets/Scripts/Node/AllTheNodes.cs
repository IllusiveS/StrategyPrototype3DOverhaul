using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllTheNodes
{
	private static AllTheNodes Singleton = null;

	AllTheNodes()
	{
		allTheNodes = new List<Node>();
		allTheNodes.Clear ();
	}

	List<Node> allTheNodes;

	public static List<Node> AccessAllNodeList()
	{
		if (Singleton == null) 
		{
			Singleton = new AllTheNodes();
		}
		return Singleton.allTheNodes;
	}
}

