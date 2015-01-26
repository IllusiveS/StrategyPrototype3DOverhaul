using UnityEngine;
using System.Collections;

public class MovementStatus : MonoBehaviour {

	public Sprite possibleMovement;
	public Sprite endMovement;
    public Sprite route;
	public Sprite attack;

	private SpriteRenderer renderer;

    private Node node;

	// Use this for initialization
	void Start () {
        node = GetComponentInParent<UNode>().node;
		renderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
        switch (node.nodeStatus)
        {
            case Node.Status.ATTACKABLE:
                setAttack();
                break;
            case Node.Status.ENTERABLE:
                setMovement();
                break;
            case Node.Status.PASSABLE:
                setMovement();
                break;
            case Node.Status.FINAL:
                setEndMovement();
                break;
            case Node.Status.ROUTE:
                setRoute();
                break;
            case Node.Status.NOTHING:
                reset();
                break;
        }
	}

	public void setMovement()
	{
		renderer.enabled = true;
		renderer.sprite = possibleMovement;
	}
	public void setEndMovement()
	{
		renderer.enabled = true;
		renderer.sprite = endMovement;
	}
    public void setRoute()
    {
        renderer.enabled = true;
        renderer.sprite = route;
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
