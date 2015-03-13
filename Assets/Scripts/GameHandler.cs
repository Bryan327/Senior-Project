using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour {
	public static bool canAdvanceState = true;
	public static int gameState;
	public const int CARD_SELECT = 0;
	public const int TARGET_SELECT = 1;
	public const int CARD_USE = 2;
	// Use this for initialization
	void Start () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		gameState = CARD_SELECT;
	}
	
	// Update is called once per frame
	void Update () {
		if (canAdvanceState) {
			switch(gameState) {
			case CARD_SELECT:
				if (true) {

				}
				break;

			case TARGET_SELECT:

				break;

			case CARD_USE:
				break;
			}
		}
	}
}
