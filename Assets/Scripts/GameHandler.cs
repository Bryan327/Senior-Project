using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameHandler : MonoBehaviour {
	private bool _canInteract = true;
	//private int _numberOfPlayers; what is this even used for?
	private int _currentPlayer;//needs renaming
	private Player[] _players;
	private Canvas _gui;
	private Location[] _locations;

	public GameObject[] locationPrefabs;
	//no more static!!!

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		this._currentPlayer = 0;
		this._canInteract = true;
		this._locations = new Location[6];
		this._players = new Player[4];

		GameObject instance = Instantiate (locationPrefabs [0], new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		this._locations [0] = new Location (instance);
		instance = Instantiate (locationPrefabs [1], new Vector3 (-10, 3, 0), Quaternion.identity) as GameObject;
		this._locations [1] = new Location (instance);
		instance = Instantiate (locationPrefabs [2], new Vector3 (0, 8, 0), Quaternion.identity) as GameObject;
		this._locations [2] = new Location (instance);
		instance = Instantiate (locationPrefabs [3], new Vector3 (10, 3, 0), Quaternion.identity) as GameObject;
		this._locations [3] = new Location (instance);
		instance = Instantiate (locationPrefabs [4], new Vector3 (-5, -8, 0), Quaternion.identity) as GameObject;
		this._locations [4] = new Location (instance);
		instance = Instantiate (locationPrefabs [5], new Vector3 (5, -8, 0), Quaternion.identity) as GameObject;
		this._locations [5] = new Location (instance);

		for (int i = 0; i < _players.Length; i++) 
			this._players [i] = new Player (this._locations [i].loc, this._locations [i], i + 1);
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine(checkForMoveInput ());
		this._gui.transform.FindChild ("Text").GetComponent<Text> ().text = "Current Turn: " + (this._currentPlayer+1);
	}

	IEnumerator checkForMoveInput() {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
			for (int i = 0; i < 6; i++) {
				if (hit != null & hit.collider != null) {
					if (hit.collider.gameObject == this._locations[i].loc && this._canInteract && this._players[this._currentPlayer].currentLocation != this._locations[i]) {
						this._canInteract = false;
						this._players[this._currentPlayer].currentLocation.setSlotToFree (_players[this._currentPlayer].slotNumber);
						this._players[this._currentPlayer].currentLocation = this._locations[i];
						yield return StartCoroutine (movePlayer (this._locations[i], .1f));
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
		this._players[this._currentPlayer].destinationReached = false;

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
		Vector3 dest;
		while (!_players[this._currentPlayer].destinationReached) {
			dest = targetSlot.transform.position - this._players[this._currentPlayer].g.transform.localPosition;
			dest = Vector3.Scale (dest, new Vector3 (1, 1, 0));

			this._players[this._currentPlayer].g.transform.position = Vector3.Lerp (this._players[this._currentPlayer].g.transform.position, new Vector3(targetSlot.transform.position.x,targetSlot.transform.position.y, -1.0f), .1f);

			//this probably needs to be shortened
			if (this._players[this._currentPlayer].g.transform.localPosition.x <= (targetSlot.transform.position.x + .05f) && _players[this._currentPlayer].g.transform.localPosition.x >= (targetSlot.transform.position.x - .05f) && this._players[this._currentPlayer].g.transform.localPosition.y <= (targetSlot.transform.position.y + .05f) && this._players[this._currentPlayer].g.transform.localPosition.y >= (targetSlot.transform.position.y - .05f)) {
				this._players[this._currentPlayer].g.transform.localPosition.Set(targetSlot.transform.position.x, targetSlot.transform.position.y, -10f);
				this._players[this._currentPlayer].destinationReached = true;
				this._canInteract = true;
			}
			yield return null;
		}
		incrementCurrentPlayer();
	}

	public void incrementCurrentPlayer() {//this may be an issue
		if (this._currentPlayer == 3)
			this._currentPlayer = 0;
		else
			this._currentPlayer++;
	}	
}