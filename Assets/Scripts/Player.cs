using UnityEngine;
using System.Collections;

public class Player {

	public string name;
	public GameObject g;
	public CircleCollider2D col;
	public SpriteRenderer rend;
	public bool destinationReached;

	public Player(GameObject start) {
		g = new GameObject ("Player");
		col = g.AddComponent<CircleCollider2D> ();
		rend = g.AddComponent<SpriteRenderer> ();

		g.GetComponent<SpriteRenderer>().sprite = Resources.Load ("Player1Sprite", typeof(Sprite)) as Sprite;
		g.GetComponent<CircleCollider2D> ().radius = g.GetComponent<SpriteRenderer> ().bounds.size.x / 2;

		destinationReached = true;

		g.transform.localPosition = start.transform.Find ("Slot 1").gameObject.transform.localPosition + new Vector3(0, 0, -1);

		//String parameter for new GameObject should be a GUID
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


}
