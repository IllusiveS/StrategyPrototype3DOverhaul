using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CUnitCombat : MonoBehaviour, IPointerClickHandler {

    UnitCombat unit;

    public static UnitCombat selected;

    void Start()
    {
        UUnit uUnit = GetComponentInParent<UnitDisplayer>().unitToDisplay;

        try {
			unit = uUnit.unit.combatModule;
			unit.setCombatSituation(UCombat.getSingleton().situation);
		} catch (System.Exception ex) {
			enabled = false;
		}

        //UCombat.getSingleton().Notify(UCombat.getSingleton().currentPlayer);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selected = null;
            UCombat.getSingleton().Notify(UCombat.getSingleton().currentPlayer);
            UCombat.getSingleton().checkAttackable(null);
        }
		if(selected != null)
        	selected.setIsSelectable(true);
    }

    public void Update(int turn)
    {
        //if (turn == gameObject.GetComponent<UUnit>().unit.getPlayer())
        //{
        //    if (unit.getAttacks() > 0)
        //    {
        //        selectable = true;
        //    }
        //    else
        //    {
        //        selectable = false;
        //    }
        //}
        //else
        //{
        //    selectable = false;
        //}

        //if (selected == this)
        //{
        //    selectable = true;
        //}

        //if (used)
        //{
        //    GetComponent<SpriteRenderer>().sprite = GetComponent<UUnit>().unit.desaturated;
        //}
        //else
        //{
        //    GetComponent<SpriteRenderer>().sprite = GetComponent<UUnit>().unit.sprite;
        //}
        //selectableView.UpdateDisplay();
    }

    public void checkPossibleAttacks()
    {
        UCombat.getSingleton().Notify(5);
        UCombat.getSingleton().checkAttackable(selected);
    }

    void OnDestroy()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (unit.getIsSelectable())
        {
            if (selected == unit)
            {
                unit.setAttacks(unit.getAttacks() - 1);
                selected = null;
                UCombat.getSingleton().changePlayer();
                return;
            }
            selected = unit;
            checkPossibleAttacks();
        }
        if (unit.getIsAttackable())
        {
			selected.attack(unit);

            selected = null;

            UCombat.getSingleton().CheckDeaths();
            UCombat.getSingleton().changePlayer();
        }
    }
}
