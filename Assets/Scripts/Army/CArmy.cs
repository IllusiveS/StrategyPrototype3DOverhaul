using UnityEngine;
using System.Collections;

public class CArmy : MonoBehaviour {

	public Army army;

	// Use this for initialization
	void Start () {
		army = GetComponent<UArmy> ().army;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1))
			army.selectArmy(null);
	}

	void OnMouseDown()
	{
		try
		{
			if(Army.selected.getPlayer() != army.getPlayer())
			{
				if(army.getNode().isReachable())
				{
					Army.selected.attackArmy(army);
					Army.selected.setCanAttack(false);
					return;
				}
			}
		}
		catch (System.NullReferenceException)
		{

		}
		if(Army.selected == army)
		{

		}

		army.selectArmy (army);
		return;
	}
}
