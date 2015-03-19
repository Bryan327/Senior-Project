using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour {
	public static bool canAdvanceState = true;
	public static int numberOfPlayers;
	public static int currentPlayer;
	public Player[] players;
	public const int KEEP = 6;
	public const int LOCATION1 = 1;
	public const int LOCATION2 = 2;
	public const int LOCATION3 = 3;
	public const int LOCATION4 = 4;
	public const int LOCATION5 = 5;

	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		numberOfPlayers = 4;
		players = new Player[numberOfPlayers];
		currentPlayer = 1;
		float offset = GameObject.Find ("KeepObject").GetComponent<SpriteRenderer>().bounds.size.x;

		for (int i = 0; i < numberOfPlayers; i++) {
			players[i] = new Player(KEEP, i + 1, offset);
			offset += 1f;
		}

	}

	public void moveToLocation1() {
		for (int i = 0; i < players.Length; i++) {
			players[i].moveToPos (GameObject.Find ("Location1Object").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
		}
	}
	public void moveToLocation2() {
		for (int i = 0; i < players.Length; i++) {
			players[i].moveToPos (GameObject.Find ("Location2Object").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
		}
	}
	public void moveToLocation3() {
		for (int i = 0; i < players.Length; i++) {
			players[i].moveToPos (GameObject.Find ("Location3Object").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
		}
	}
	public void moveToLocation4() {
		for (int i = 0; i < players.Length; i++) {
			players[i].moveToPos (GameObject.Find ("Location4Object").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
		}
	}
	public void moveToLocation5() {
		for (int i = 0; i < players.Length; i++) {
			players[i].moveToPos (GameObject.Find ("Location5Object").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
		}
	}
	public void moveToKeep() {
		for (int i = 0; i < players.Length; i++) {
			players[i].moveToPos (GameObject.Find ("KeepObject").transform.localPosition + new Vector3(players[i].positionOffset, -1, 0));
		}
	}

	// Update is called once per frame
	void Update () {

	}

}
