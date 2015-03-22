using UnityEngine;
using System.Reflection;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class FormationPosition : MonoBehaviour {

	int formationOwner;

	public bool formationFirstRow;

	public int x;
	public int y;

	// Use this for initialization
	void Start () {
		formationOwner = GetComponentInParent<FormationOwner> ().playerOwner;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
