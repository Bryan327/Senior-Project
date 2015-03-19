using UnityEngine;
using System.Collections;

public class Player {
	public int health;
	public int location;
	public int playerNumber;
	public float positionOffset;

	public const int KEEP = 6;
	public const int LOCATION1 = 1;
	public const int LOCATION2 = 2;
	public const int LOCATION3 = 3;
	public const int LOCATION4 = 4;
	public const int LOCATION5 = 5;
	
	public GameObject go;
	public SpriteRenderer rend;
	public CircleCollider2D col;

	public Player(int loc, int playerNum, float posOffset) {
		health = 10;
		location = loc;
		positionOffset = posOffset;
		playerNumber = playerNum;
		go = new GameObject ("PlayerObject");
		rend = go.AddComponent<SpriteRenderer> ();
		col = go.AddComponent<CircleCollider2D> ();
		switch (playerNum) {
		case 1:
			go.GetComponent<SpriteRenderer>().sprite = Resources.Load ("Player1Sprite", typeof(Sprite)) as Sprite;
			break;
		case 2:
			go.GetComponent<SpriteRenderer>().sprite = Resources.Load ("Player2Sprite", typeof(Sprite)) as Sprite;
			break;
		case 3:
			go.GetComponent<SpriteRenderer>().sprite = Resources.Load ("Player3Sprite", typeof(Sprite)) as Sprite;
			break;
		case 4:
			go.GetComponent<SpriteRenderer>().sprite = Resources.Load ("Player4Sprite", typeof(Sprite)) as Sprite;
			break;
		}
		go.GetComponent<CircleCollider2D> ().radius = go.GetComponent<SpriteRenderer> ().sprite.bounds.size.x/2;

		this.setPlayerLocation (location);
	}

	public void setPlayerLocation(int loc) {
		switch (loc) {
		case KEEP:
			go.transform.localPosition = GameObject.Find ("KeepObject").transform.localPosition + new Vector3(this.positionOffset, -1, 0);
			break;
		case LOCATION1:
			go.transform.localPosition = GameObject.Find ("Location1Object").transform.localPosition + new Vector3(this.positionOffset, -1, 0);
			break;
		case LOCATION2:
			go.transform.localPosition = GameObject.Find ("Location2Object").transform.localPosition + new Vector3(this.positionOffset, -1, 0);
			break;
		case LOCATION3:
			go.transform.localPosition = GameObject.Find ("Location3Object").transform.localPosition + new Vector3(this.positionOffset, -1, 0);
			break;
		case LOCATION4:
			go.transform.localPosition = GameObject.Find ("Location4Object").transform.localPosition + new Vector3(this.positionOffset, -1, 0);
			break;
		case LOCATION5:
			go.transform.localPosition = GameObject.Find ("Location5Object").transform.localPosition + new Vector3(this.positionOffset, -1, 0);
			break;
			
		}
	}

	public void moveToPos(Vector3 toPos) {
		go.transform.localPosition = toPos;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
