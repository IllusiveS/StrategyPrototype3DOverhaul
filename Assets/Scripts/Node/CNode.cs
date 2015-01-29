using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CNode : MonoBehaviour {

	public Node node;

    private static List<UNode> trasa = new List<UNode>();

	void Start () {
		this.node = GetComponent<UNode> ().node;
	}
	
	void OnMouseDown()
	{
		if(Army.selected != null && Army.selected != node.army)
		{
            if (node.nodeStatus == Node.Status.FINAL)
            {
                Army.selected.getUArmy().GetComponent<ArmyMovement>().setRoute(trasa);
                resetRoute();
            }
            if (node.nodeStatus == Node.Status.ENTERABLE || node.nodeStatus == Node.Status.ROUTE)
            {
                resetRoute();
                trasa = Army.selected.getAlgorithm().GenerateRoute(null, node);
                setRoute();
            }
		}
	}
    private void setRoute()
    {
        foreach (UNode uNode in trasa)
        {
            Node nod = uNode.node;
            nod.setActive(Node.Status.ROUTE);
        }
        trasa[trasa.Count - 1].node.setActive(Node.Status.FINAL);
    }
    private void resetRoute()
    {
        foreach(UNode uNode in trasa)
        {
            Node nod = uNode.node;
			nod.setActive(Node.Status.ENTERABLE);
        }
    }
}
