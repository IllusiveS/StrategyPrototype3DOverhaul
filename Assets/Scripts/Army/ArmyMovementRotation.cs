using UnityEngine;
using System.Collections;

public class ArmyMovementRotation : MonoBehaviour {

	protected ArmyMovement movement;

	// Use this for initialization
	void Start () {
		movement = GetComponentInParent<ArmyMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(movement.moving)
			transform.LookAt(movement.end, new Vector3(0, 1, 0));
	}
}
