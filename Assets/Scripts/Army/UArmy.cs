using UnityEngine;
using System.Collections;

public class UArmy : MonoBehaviour {

	public Army army;

	public int iPlayer;
	public int iSpeed;

	public UNode node;

	void Awake()
	{
		army = new Army (iPlayer, iSpeed, this);
	}

	// Use this for initialization
	void Start () {
		army.attachToPlayer ();

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
	}

	public void UpdateMovementDisplay()
	{

	}

	// Update is called once per frame
	void Update () {
		iSpeed = army.getSpeed ();
	}

	void OnDestroy()
	{
		army.getNode ().Leave (null);
		//node.node.Leave (null);
		army.detachFromPlayer ();
	}
}
