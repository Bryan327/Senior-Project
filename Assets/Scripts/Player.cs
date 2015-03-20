using UnityEngine;
using System.Collections;

public class Player {

	public string name;
	public GameObject g;
	public CircleCollider2D col;
	public SpriteRenderer rend;
	public bool destinationReached;
	public Location currentLocation;
	public int slotNumber;

	public Player(GameObject start, Location loc, int playerNumber) {
		g = new GameObject ("Player");
		col = g.AddComponent<CircleCollider2D> ();
		rend = g.AddComponent<SpriteRenderer> ();

		switch (playerNumber) {
		case 1: 
			g.GetComponent<SpriteRenderer>().sprite = Resources.Load ("Player1Sprite", typeof(Sprite)) as Sprite;
			g.transform.localPosition = start.transform.Find ("Slot 1").gameObject.transform.localPosition + new Vector3(0, 0, -1);
			slotNumber = 0;
			break;
		case 2:
			g.GetComponent<SpriteRenderer>().sprite = Resources.Load ("Player2Sprite", typeof(Sprite)) as Sprite;
			g.transform.localPosition = start.transform.Find ("Slot 2").gameObject.transform.localPosition + new Vector3(0, 0, -1);
			slotNumber = 1;
			break;
		case 3:
			g.GetComponent<SpriteRenderer>().sprite = Resources.Load ("Player3Sprite", typeof(Sprite)) as Sprite;
			g.transform.localPosition = start.transform.Find ("Slot 3").gameObject.transform.localPosition + new Vector3(0, 0, -1);
			slotNumber = 2;
			break;
		case 4:
			g.GetComponent<SpriteRenderer>().sprite = Resources.Load ("Player4Sprite", typeof(Sprite)) as Sprite;
			g.transform.localPosition = start.transform.Find ("Slot 4").gameObject.transform.localPosition + new Vector3(0, 0, -1);
			slotNumber = 3;
			break;
		}

		g.GetComponent<CircleCollider2D> ().radius = g.GetComponent<SpriteRenderer> ().bounds.size.x / 2;

		destinationReached = true;
		currentLocation = loc;

		//String parameter for new GameObject should be a GUID
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


}
