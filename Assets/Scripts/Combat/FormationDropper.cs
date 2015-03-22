using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FormationDropper : MonoBehaviour, IDropHandler {

	UCombatStart combatController;
    FormationPosition position;

	int formationOwner;

	void Start()
	{
        position = GetComponent<FormationPosition>();
		formationOwner = GetComponentInParent<FormationOwner> ().playerOwner;
	}

	public void OnDrop(PointerEventData data)
	{
		try {
			UUnit unitToDisplay = GetDropUnit (data);
			if (unitToDisplay != null) {
				if (unitToDisplay.unit.getPlayer () == formationOwner) {
					GetComponentInParent<UnitDisplayer> ().unitToDisplay = unitToDisplay;
					unitToDisplay.unit.setXCoord (position.x);
					unitToDisplay.unit.setYCoord (position.y);
					combatController.PlaceUnit ();
					Destroy (data.pointerDrag.GetComponent<CombatBeginUnitDrag> ().m_DraggingIcon);
					data.pointerDrag.transform.parent.gameObject.SetActive (false);
					Destroy (this);
				}
			}
		} catch (System.Exception ex) {
	
		}
	}

	private UUnit GetDropUnit(PointerEventData data)
	{
		GameObject originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;

		UnitDisplayer unit = originalObj.GetComponentInParent<UnitDisplayer>();
		if (unit == null)
			return null;

		CombatBeginUnitDrag dragInitiator = unit.GetComponentInChildren<CombatBeginUnitDrag> ();
		if(dragInitiator == null)
			return null;
		if(dragInitiator.m_DraggingIcon == null)
			return null;
		
		return unit.unitToDisplay;
	}
	public void setCombatController(UCombatStart combat)
	{
		combatController = combat;
	}
}
