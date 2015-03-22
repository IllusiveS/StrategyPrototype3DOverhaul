using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RecruitmentPossibility : MonoBehaviour, IPointerClickHandler {

	private UUnit unit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<UnitDisplayer> ().unitToDisplay = unit;
	}

	public UUnit Unit {
		set {
			unit = value;
		}
	}

	#region IPointerClickHandler implementation

	public void OnPointerClick (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion
}
