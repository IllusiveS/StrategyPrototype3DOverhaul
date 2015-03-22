using UnityEngine;
using System.Collections;

public class ArmySelectionCanvasScript : MonoBehaviour {

	void Update () {
		if (Army.selected == null)
			Destroy(gameObject);
	}
}
