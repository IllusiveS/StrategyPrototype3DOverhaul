using UnityEngine;
using System.Collections;

public class MovementStatus : MonoBehaviour {

	public Sprite possibleMovement;
	public Sprite endMovement;
    public Sprite route;
	public Sprite attack;
	public Sprite pass;

	private SpriteRenderer rendererR;

	private Node node;

	// UrendererRfor initialization
	void Start () {
        node = GetComponentInParent<UNode>().node;
		rendererR = GetComponent<SpriteRenderer> ();
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
                setPassable();
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
		rendererR.enabled = true;
		rendererR.sprite = possibleMovement;
	}
	public void setEndMovement()
	{
		rendererR.enabled = true;
		rendererR.sprite = endMovement;
	}
    public void setRoute()
    {
        rendererR.enabled = true;
        rendererR.sprite = route;
    }
	public void setAttack()
	{
		rendererR.enabled = true;
		rendererR.sprite = attack;
	}
	public void reset()
	{
		rendererR.enabled = false;
	}

	void setPassable ()
	{
		rendererR.enabled = true;
		rendererR.sprite = pass;
	}
}
