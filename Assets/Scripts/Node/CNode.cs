using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Zenject;
using UnityEngine.EventSystems;

public class CNode : MonoBehaviour {

	[Inject]
	protected RecruitmentDisplay recruitment;
	[Inject]
	protected GameControl control;

	public Node node;

    public static List<UNode> trasa = new List<UNode>();

	void Start () {
		this.node = GetComponent<UNode> ().node;
	}
	
	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		if(Army.selected != null && Army.selected != node.army)
		{
            if (node.nodeStatus == Node.Status.FINAL)
            {
				resetRoute();
                Army.selected.getUArmy().GetComponent<ArmyMovement>().setRoute(trasa);
				trasa.Clear();
            }
            else if (node.nodeStatus == Node.Status.ENTERABLE || node.nodeStatus == Node.Status.ROUTE)
            {
                resetRoute();
                setRoute();
            }
		}else if (AnyUnitsForRecruitment ())
		{
			recruitment.gameObject.SetActive(true);
			recruitment.recrutimentNode = node;
			recruitment.recruitingPlayer = control.getCurrentPlayer();
		}
	}

	bool AnyUnitsForRecruitment ()
	{
		bool returnValue = false;

		try {
			if (node.possibleRecruitments (control.getCurrentPlayer ().PlayerLeader).Count > 0)
				returnValue = true;
		} catch (System.Exception ex) {
	
		}

		return returnValue;
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(1))
		{
			recruitment.gameObject.SetActive(false);
		}
	}
    public void setRoute()
    {
		trasa.Clear ();
        trasa = Army.selected.getAlgorithm().GenerateRoute(null, node);
        foreach (UNode uNode in trasa)
        {
            Node nod = uNode.node;
            nod.setActive(Node.Status.ROUTE);
        }
        trasa[trasa.Count - 1].node.setActive(Node.Status.FINAL);
    }
    public void resetRoute()
    {
        try {
			foreach (UNode uNode in trasa) {
				Node nod = uNode.node;
				nod.setActive (Node.Status.ENTERABLE);
			}
			if (trasa [trasa.Count - 1].army != null && trasa [trasa.Count - 1].army.army.getPlayer () != Army.selected.getPlayer ()) {
				resetRouteAttack ();
				return;
			}
		} catch (System.Exception ex) {

		}
		//trasa.Clear ();
    }
    public void resetRouteAttack()
    {
        foreach (UNode uNode in trasa)
        {
            Node nod = uNode.node;
            nod.setActive(Node.Status.ENTERABLE);
        }
        trasa[trasa.Count - 1].node.setActive(Node.Status.ATTACKABLE);
    }
}
