using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHandler : MonoBehaviour {
	public static bool canInteract = true;
	public static int numberOfPlayers;
	public static int currentPlayer;
	public Player[] players;
	public GameObject[] locationPrefabs;
	public Canvas gui;
	public Location[] locations;

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		numberOfPlayers = 4;
		currentPlayer = 0;
		canInteract = true;
		locations = new Location[6];
		players = new Player[4];

		//gui.transform.GetChild("Text").GetComponent<Text> ().text = "Current Turn: " + currentPlayer;

		GameObject instance = Instantiate (locationPrefabs [0], new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		locations [0] = new Location (instance);
		instance = Instantiate (locationPrefabs [1], new Vector3 (-10, 3, 0), Quaternion.identity) as GameObject;
		locations [1] = new Location (instance);
		instance = Instantiate (locationPrefabs [2], new Vector3 (0, 8, 0), Quaternion.identity) as GameObject;
		locations [2] = new Location (instance);
		instance = Instantiate (locationPrefabs [3], new Vector3 (10, 3, 0), Quaternion.identity) as GameObject;
		locations [3] = new Location (instance);
		instance = Instantiate (locationPrefabs [4], new Vector3 (-5, -8, 0), Quaternion.identity) as GameObject;
		locations [4] = new Location (instance);
		instance = Instantiate (locationPrefabs [5], new Vector3 (5, -8, 0), Quaternion.identity) as GameObject;
		locations [5] = new Location (instance);

		players [0] = new Player (locations [0].loc, locations [0], 1);
		players [1] = new Player (locations [0].loc, locations [0], 2);
		players [2] = new Player (locations [0].loc, locations [0], 3);
		players [3] = new Player (locations [0].loc, locations [0], 4);


	}
	// Update is called once per frame
	void Update () {
		StartCoroutine(checkForMoveInput ());
		gui.transform.FindChild ("Text").GetComponent<Text> ().text = "Current Turn: " + (currentPlayer+1);
	}

	IEnumerator checkForMoveInput() {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
			for (int i = 0; i < 6; i++) {
				if (hit != null & hit.collider != null) {
					if (hit.collider.gameObject == locations[i].loc && canInteract && players[currentPlayer].currentLocation != locations[i]) {
						canInteract = false;
						players[currentPlayer].currentLocation.setSlotToFree (players[currentPlayer].slotNumber);
						players[currentPlayer].currentLocation = locations[i];
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
		players[currentPlayer].destinationReached = false;

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

		while (!players[currentPlayer].destinationReached) {
			Vector3 dest = targetSlot.transform.position - players[currentPlayer].g.transform.localPosition;
			
			dest = Vector3.Scale (dest, new Vector3 (1, 1, 0));

			//players[currentPlayer].g.transform.localPosition += (percent * dest);

			players[currentPlayer].g.transform.position = Vector3.Lerp (players[currentPlayer].g.transform.position, new Vector3(targetSlot.transform.position.x,targetSlot.transform.position.y, -1.0f), .1f);

			if (players[currentPlayer].g.transform.localPosition.x <= (targetSlot.transform.position.x + .05f) && players[currentPlayer].g.transform.localPosition.x >= (targetSlot.transform.position.x - .05f) && players[currentPlayer].g.transform.localPosition.y <= (targetSlot.transform.position.y + .05f) && players[currentPlayer].g.transform.localPosition.y >= (targetSlot.transform.position.y - .05f)) {
				players[currentPlayer].g.transform.localPosition.Set(targetSlot.transform.position.x, targetSlot.transform.position.y, -10f);
				players[currentPlayer].destinationReached = true;
				canInteract = true;
			}
			yield return null;
		}

		incrementCurrentPlayer ();
	}

	public void incrementCurrentPlayer() {
		if (currentPlayer == 3) {
			currentPlayer = 0;
		} else {
			currentPlayer++;
		}


	}
	
}
