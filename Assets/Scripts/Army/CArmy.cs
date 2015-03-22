using UnityEngine;
using System.Collections;
using AdvancedInspector;
using UnityEngine.EventSystems;

[AdvancedInspector]
public class CArmy : MonoBehaviour {

	public Army army;

    [Inspect]
    public GameObject armyDisplayerCanvasTemplate;

    private GameObject armyDisplayerCanvas;

	// Use this for initialization
	void Start () {
		army = GetComponent<UArmy> ().army;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1))
        {
            army.selectArmy(null);
            hideUnits();
        }
		if (Army.selected != army)
		{
			hideUnits();
		}
	}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		try
		{
			if(Army.selected.getPlayer() != army.getPlayer())
			{
                if(army.getNode().nodeStatus == Node.Status.ATTACKABLE)
				{
                    army.getNode().node.GetComponent<CNode>().setRoute();
					return;
				}
				if(army.getNode().nodeStatus == Node.Status.FINAL)
				{
					Army.selected.attackArmy(army);
					Army.selected.setCanAttack(false);
					Army.selected.selectArmy(null);
					return;
				}
			}
		}
		catch (System.NullReferenceException)
		{

		}

		army.selectArmy (army);
        displayUnits();
		return;
	}
    public void displayUnits()
    {
        armyDisplayerCanvas = Instantiate(armyDisplayerCanvasTemplate) as GameObject;
        armyDisplayerCanvas.GetComponentInChildren<ArmyDisplayer>().armyToDisplay = army.uArmy;
    }
    public void hideUnits()
    {
        try
        {
        	Destroy(armyDisplayerCanvas.gameObject);
        }
        catch (System.Exception ex)
        {
        	
        }
    }
}
