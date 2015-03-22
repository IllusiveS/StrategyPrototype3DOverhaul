using UnityEngine;
using System.Collections;
using AdvancedInspector;

[AdvancedInspector]
public class CombatInitiator : MonoBehaviour {

    [Inspect]
	public GameObject Combat;

	public Army army;

	public void Start()
	{
		army = GetComponent<UArmy>().army;
	}

	public void pressTheAttack(Army def)
	{
		GameObject goCombat = Instantiate(Combat) as GameObject;

		UCombat combat = goCombat.GetComponent<UCombat> ();
		combat.setUpCombat (army, def);
	}
}
