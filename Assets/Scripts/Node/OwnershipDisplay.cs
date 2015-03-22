using UnityEngine;
using System.Collections;
using Zenject;

public class OwnershipDisplay : MonoBehaviour {

	[Inject]
	GameControl control;

	protected Node node;

	protected MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
		node = GetComponentInParent<UNode> ().node;
		meshRenderer = GetComponentInChildren<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		bool state = false;
		int owner = node.getOwner ();
		Color color = Color.white;

		if(owner == -1)
		{
			color = Color.white;
			state = true;
		}
		else if(owner >= 0)
		{
			color = control.getPlayer(owner).playerColor;
			state = true;
		}
		foreach(Transform trans in transform)
		{
			trans.gameObject.SetActive(state);
		}
		meshRenderer.material.color = color;
	}
}
