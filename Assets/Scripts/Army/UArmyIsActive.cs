using UnityEngine;
using System.Collections;

public class UArmyIsActive : MonoBehaviour {

	Army army;

	Vector3 up;
	Vector3 down;

	float t = 0;

	bool directionDown = true;

	public bool isActive;

	// Use this for initialization
	void Start () {
		army = GetComponent<UArmy> ().army;

		up = transform.position;
		down = transform.position;

		up = new Vector3 (up.x, up.y + 0.25f, up.z);
		down = new Vector3 (down.x, down.y - 0.25f, down.z);
	}
	
	// Update is called once per frame
	void Update () {
		isActive = army.getIsActive ();
	}
}
