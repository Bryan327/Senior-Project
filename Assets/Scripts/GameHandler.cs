using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour {
	public static bool canInteract = true;
	public static int numberOfPlayers;
	public static int currentPlayer;
	public Player p;
	public GameObject[] locationPrefabs;
	public Location[] locations;

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		numberOfPlayers = 1;
		canInteract = true;
		locations = new Location[6];

		GameObject instance = Instantiate (locationPrefabs[0], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		locations [0] = new Location(instance);
		instance = Instantiate (locationPrefabs[1], new Vector3(-10, 3, 0), Quaternion.identity) as GameObject;
		locations [1] = new Location(instance);
		instance = Instantiate (locationPrefabs[2], new Vector3(0, 8, 0), Quaternion.identity) as GameObject;
		locations [2] = new Location(instance);
		instance = Instantiate (locationPrefabs[3], new Vector3(10, 3, 0), Quaternion.identity) as GameObject;
		locations [3] = new Location(instance);
		instance = Instantiate (locationPrefabs[4], new Vector3(-5, -8, 0), Quaternion.identity) as GameObject;
		locations [4] = new Location(instance);
		instance = Instantiate (locationPrefabs[5], new Vector3(5, -8, 0), Quaternion.identity) as GameObject;
		locations [5] = new Location(instance);

		p = new Player (locations[0].loc);
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine(checkForMoveInput ());
	}

	IEnumerator checkForMoveInput() {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Mouse is down");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
			for (int i = 0; i < 6; i++) {
				if (hit != null & hit.collider != null) {
					Debug.Log ("hit: " + hit.collider.gameObject + ", loc: " + locations[i].loc);
					if (hit.collider.gameObject == locations[i].loc && canInteract) {
						canInteract = false;
						yield return StartCoroutine (movePlayer (locations[i], .1f));
					}
				}
			}
		}
		yield return null;
	}
	IEnumerator movePlayer(Location l, float percent) {
		int firstSlot = l.getFirstFreeSlot ();
		l.setSlotToUsed (firstSlot);
		GameObject targetSlot = l.loc.transform.Find ("Slot 1").gameObject;
		p.destinationReached = false;

		switch (firstSlot) {
		case 0:
			targetSlot = l.loc.transform.Find ("Slot 1").gameObject;
			break;
		case 1:
			targetSlot = l.loc.transform.Find ("Slot 2").gameObject;
			break;
		case 2:
			targetSlot = l.loc.transform.Find ("Slot 3").gameObject;
			break;
		case 3:
			targetSlot = l.loc.transform.Find ("Slot 4").gameObject;
			break;
		}

		Debug.Log ("Moving");

		while (!p.destinationReached) {
			Vector3 dest = targetSlot.transform.position - p.g.transform.localPosition;

			Debug.Log ("target: " + targetSlot.transform.position.ToString () + ", current: " + p.g.transform.localPosition.ToString ());
			
			dest = Vector3.Scale (dest, new Vector3 (1, 1, 0));

			p.g.transform.localPosition += (percent * dest);

			if (p.g.transform.localPosition.x <= (targetSlot.transform.position.x + .05f) && p.g.transform.localPosition.x >= (targetSlot.transform.position.x - .05f) && p.g.transform.localPosition.y <= (targetSlot.transform.position.y + .05f) && p.g.transform.localPosition.y >= (targetSlot.transform.position.y - .05f)) {
				p.g.transform.localPosition.Set(targetSlot.transform.position.x, targetSlot.transform.position.y, -10f);
				p.destinationReached = true;
				canInteract = true;
				Debug.Log ("Has stopped moving");
			}
			yield return null;
		}
	}
	
}
