using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedInspector;

public class ArmyMovement : MonoBehaviour {

	List<UNode> trasa = new List<UNode> ();

	Army movingArmy;

	public Vector3 start;
	public Vector3 end;

	public UNode startNode;
	public UNode endNode;

	public float progress = 1.1f;

	public float speed;

	public bool moving = false;

	public void Start()
	{
		movingArmy = GetComponent<UArmy> ().army;
	}

	public void setRoute(List<UNode> route)
	{
		moving = true;
		trasa.Clear ();
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
        try
        {
            start = new Vector3(trasa[0].transform.position.x, transform.position.y, trasa[0].transform.position.z);
            startNode = trasa[0];
            if (trasa[1].army != null && trasa[1].army.army.getPlayer() != GetComponent<UArmy>().army.getPlayer())
            {
                finishAttackMove();
                return;
            }
            else
            {
                end = new Vector3(trasa[1].transform.position.x, transform.position.y, trasa[1].transform.position.z);
                endNode = trasa[1];
            }
        }
        catch (System.ArgumentOutOfRangeException)
        {
            finishMove();
            return;
        }
        endNode.node.Enter(movingArmy);
        startNode.node.Leave(movingArmy);
        movingArmy.setNode(endNode.node);
        trasa.RemoveAt(0);
	}

	void finishMove()
	{
		GetComponent<UArmy> ().army.setIsActive (false);
		GetComponent<UArmy> ().army.getAlgorithm ().ResetAllNodes ();
		endNode = null;
		startNode = null;
		moving = false;
		try {
			Army.selected.selectArmy (null);
		} catch (System.Exception ex) {
	
		}
	}
	void finishAttackMove()
	{

        moving = false;

		GetComponent<UArmy> ().GetComponent<CombatInitiator> ().pressTheAttack (trasa[1].node.army);

		finishMove ();
	}
}
