using UnityEngine;
using System.Collections;

public class MovementStatus : MonoBehaviour {

	public Sprite movement;
	public Sprite endMovement;
	public Sprite attack;

	private SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setMovement()
	{
		if(renderer.sprite == endMovement)
			return;
		renderer.enabled = true;
		renderer.sprite = movement;
	}
	public void setEndMovement()
	{
		renderer.enabled = true;
		renderer.sprite = endMovement;
	}
	public void setAttack()
	{
		renderer.enabled = true;
		renderer.sprite = attack;
	}
	public void reset()
	{
		renderer.enabled = false;
	}

}
