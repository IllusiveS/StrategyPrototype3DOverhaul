using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class NodeStatusText : MonoBehaviour {

	private Node node;
	private Text text;

	// Use this for initialization
	void Start () {
		node = GetComponentInParent<UNode> ().node;
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = node.getCost ().ToString ();
	}
}
