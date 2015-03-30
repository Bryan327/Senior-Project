using UnityEngine;
using System.Collections;

public class Player 
{
	private CircleCollider2D _col;
	private SpriteRenderer _rend;

	public GameObject g;
	public bool destinationReached;
	public Location currentLocation;
	public int slotNumber;

	public Player(GameObject start, Location loc, int playerNumber) 
	{
		g = new GameObject ("Player");
		this._col = g.AddComponent<CircleCollider2D> ();
		this._rend = g.AddComponent<SpriteRenderer> ();

		this.GetPosition(start, playerNumber);

		g.GetComponent<CircleCollider2D>().radius = g.GetComponent<SpriteRenderer> ().bounds.size.x / 2;

		destinationReached = true;
		currentLocation = loc;

		//String parameter for new GameObject should be a GUID
	}

	// Use this for initialization
	void Start() {}
	
	// Update is called once per frame
	void Update() {}

	private void GetPosition(GameObject start,int playerNumber) 
	{ //not exactly sure what this should be called
		g.GetComponent<SpriteRenderer>().sprite = Resources.Load ("Player" + playerNumber + "Sprite", typeof(Sprite)) as Sprite;
		g.transform.localPosition = start.transform.Find ("Slot " + playerNumber.ToString()).gameObject.transform.localPosition + new Vector3(0, 0, -1);
		slotNumber = playerNumber - 1;
	}
}