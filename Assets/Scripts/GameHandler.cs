using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour {
	public static bool canAdvanceState = true;
	public static int numberOfPlayers;
	public static int currentPlayer;
	public Player p;
	public GameObject[] locationPrefabs;
	public const int KEEP = 6;

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		numberOfPlayers = 1;
		p = new Player ();

		GameObject instance = Instantiate (locationPrefabs[0], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		instance = Instantiate (locationPrefabs[1], new Vector3(-10, 3, 0), Quaternion.identity) as GameObject;
		instance = Instantiate (locationPrefabs[2], new Vector3(0, 8, 0), Quaternion.identity) as GameObject;
		instance = Instantiate (locationPrefabs[3], new Vector3(10, 3, 0), Quaternion.identity) as GameObject;
		instance = Instantiate (locationPrefabs[4], new Vector3(-5, -8, 0), Quaternion.identity) as GameObject;
		instance = Instantiate (locationPrefabs[5], new Vector3(5, -8, 0), Quaternion.identity) as GameObject;


	}

//	public void moveToLocation1() {
//		for (int i = 0; i < players.Length; i++) {
//			players[i].moveToPos (GameObject.Find ("Location1Object").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
//		}
//	}
//	public void moveToLocation2() {
//		for (int i = 0; i < players.Length; i++) {
//			players[i].moveToPos (GameObject.Find ("Location2Object").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
//		}
//	}
//	public void moveToLocation3() {
//		for (int i = 0; i < players.Length; i++) {
//			players[i].moveToPos (GameObject.Find ("Location3Object").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
//		}
//	}
//	public void moveToLocation4() {
//		for (int i = 0; i < players.Length; i++) {
//			players[i].moveToPos (GameObject.Find ("Location4Object").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
//		}
//	}
//	public void moveToLocation5() {
//		for (int i = 0; i < players.Length; i++) {
//			players[i].moveToPos (GameObject.Find ("Location5Object").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
//		}
//	}
//	public void moveToKeep() {
//		for (int i = 0; i < players.Length; i++) {
//			players[i].moveToPos (GameObject.Find ("KeepObject").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
//		}
//	}

	// Update is called once per frame
	void Update () {
		StartCoroutine(checkForMoveInput ());
	}

	IEnumerator checkForMoveInput() {
		if (Input.GetMouseButtonDown (0)) {
			//Debug.Log ("Mouse is down");
			GameObject[] loc = GameObject.FindGameObjectsWithTag ("Location");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
			foreach (var l in loc) {
				if (hit != null & hit.collider != null) {
					if (hit.collider.gameObject == l) {
						p.g.transform.localPosition = l.transform.localPosition;
					}
				}
			}
		}
		yield return null;
	}
}
