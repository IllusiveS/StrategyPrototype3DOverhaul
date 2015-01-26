using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UNode : MonoBehaviour {

	public TileType tileType;

	public float halfSize;

	public List<UNode> neighbours = new List<UNode>();

	public Node node;

	public int AllNodes;

	public UArmy army;

	public int cost;

	public int moveLeft;

	private MovementStatus movementStatus;


	void Awake()
	{
		node = new Node (this);
		node.costCalculator = getTileType ();
	}

	void Start () {
		movementStatus = GetComponentInChildren<MovementStatus> ();

		node.iCost = cost;

		for(int i = 0; i < 4; i++) 
		{
			Transform trans = GetComponent<Transform>();

            float Xcoord = Mathf.Cos(i * 90 * Mathf.Deg2Rad);
            float YCoord = Mathf.Sin(i * 90 * Mathf.Deg2Rad);

            Vector3 start = new Vector3(trans.position.x + (halfSize * Xcoord), trans.position.y, trans.position.z + (halfSize * YCoord));

			int terrainLayer = 1 << 8;

			try
			{
				UNode PotentialNeighbour = Physics.OverlapSphere(start, 0.2f, terrainLayer)[0].GetComponent<UNode>();
				neighbours.Add(PotentialNeighbour);
			}
			catch (System.IndexOutOfRangeException)
			{
                neighbours.Add(null);
			}
		}
		List<Node> nods = new List<Node> ();
		foreach (UNode nod in neighbours) 
		{
            try
            {
                nods.Add(nod.node);
            }
            catch (System.NullReferenceException)
            {
                nods.Add(null);
            }
		}
		
		node.setNeighbours (nods);

		try
		{
            Vector3 vek = new Vector3(transform.position.x, 1.0f, transform.position.z);
            army = Physics.RaycastAll(transform.position, new Vector3(0, 1.0f, 0), 1.0f, 1 << 9)[0].collider.gameObject.GetComponent<UArmy>();
            Vector3 change = new Vector3(transform.position.x, army.transform.position.y, transform.position.z);
            army.transform.position = change;
            army.army.setNode(node);
            army.node = this;
			node.army = army.army;
		}
		catch (System.IndexOutOfRangeException)
		{
			
		}
	}

	void Update()
	{
		moveLeft = node.iMoveLeft;
	}

	public void setActive(Node.Status status)
	{
       
	}

	NodeCost getTileType()
	{
		NodeCost costCalc = null;

		return costCalc;
	}

	public enum TileType
	{
		plain,
		road,
		city,
		forest
	}

}
