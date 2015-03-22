using UnityEngine;
using System.Collections;
using Zenject;
using AdvancedInspector;

[AdvancedInspector]
public class UArmy : MonoBehaviour {

	[Inject]
	public GameControl control;

	[Inspect]
	public Army army;

	public UNode node;

	void Awake()
	{

	}

	// Use this for initialization
	void Start () {
		army.movingAlgorithm.armyOwner = this;

		//gameObject.AddComponent<UArmyIsActive> ();

		try
		{
			node = Physics.RaycastAll(transform.position, new Vector3(0, -1.0f, 0), 1.0f, 1 << 8)[0].collider.gameObject.GetComponent<UNode>();
			army.setNode (node.node);
		}
		catch (System.IndexOutOfRangeException)
		{

		}
		//GetComponentInChildren<DisplayArmyMovement> ().army = army;

		//GetComponentInChildren<DisplayPlayerSprite> ().owner = army;

		foreach(UUnit un in GetComponentsInChildren<UUnit>())
		{
			army.addUnit(un.unit);
		}
		army.uArmy = this;
		army.attachToPlayer ();

		//army.setUnits ();
	}

	public void UpdateMovementDisplay()
	{

	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
	{
		try {
			army.getNode ().Leave (null);
		} catch (System.Exception ex) {

		}
		//node.node.Leave (null);
		army.detachFromPlayer ();
	}
}
