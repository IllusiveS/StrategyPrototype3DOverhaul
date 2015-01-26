using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArmyMovement : MonoBehaviour {

	private class UNodeList : List<UNode>{};

	UNodeList trasa = new UNodeList ();

	Army movingArmy;

	public Vector3 start;
	public Vector3 end;

	public UNode startNode;
	public UNode endNode;

	public float progress = 1.1f;

	public float speed;

	bool moving = false;

	public void Start()
	{
		movingArmy = GetComponent<UArmy> ().army;
	}

	public void setRoute(List<UNode> route)
	{
		moving = true;
		trasa.AddRange (route);
        setNewTarget();
		progress = 2.0f;
	}
		
	void FixedUpdate () {
		if(moving)
		{
			Move ();
		}
	}

	void Move()
	{
        Vector3 vek = end - start;
        vek.Normalize();
        vek *= 0.05f;
        GetComponent<CharacterController>().Move(vek);


        if(Vector3.Distance(end, transform.position) < 0.1f)
        {
            Vector3 change = new Vector3(end.x, transform.position.y, end.z);
            transform.position = change;
            setNewTarget();
        }
	}

	void setNewTarget()
	{
		start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		startNode = movingArmy.getNode ().node;
		try
		{
            end = new Vector3(trasa[0].transform.position.x, transform.position.y, trasa[0].transform.position.z);
			endNode = trasa[0];
			trasa.RemoveAt (0);
		}catch (System.ArgumentOutOfRangeException)
		{
			finishMove();
			return;
		}
		endNode.node.Enter(movingArmy);
		startNode.node.Leave(movingArmy);
		movingArmy.setNode(endNode.node);
	}

	void finishMove()
	{
		GetComponent<UArmy> ().army.setIsActive (false);
		GetComponent<UArmy> ().army.getAlgorithm ().ResetAllNodes ();
		endNode = null;
		startNode = null;
		moving = false;
		//Army.selected.selectArmy (null);
		Army.selected = null;
	}
	void finishAttackMove()
	{
		UArmy unityArmy = movingArmy.getUArmy ();
		UNode closestNode;
		closestNode = endNode.node.prevNode.getUnityNode();
		Vector3 newPlace = new Vector3 (closestNode.transform.position.x, closestNode.transform.position.y, -0.5f);
		start = newPlace;
		unityArmy.transform.position = newPlace;

		unityArmy.army.setNode (endNode.node.prevNode.getUnityNode().node);
		closestNode.node.army = movingArmy;

		unityArmy.GetComponent<CombatInitiator> ().pressTheAttack (endNode.army.army);

		finishMove ();
	}
}
