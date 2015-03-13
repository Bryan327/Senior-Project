using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {
	public int currentEnemy = 0;
	public bool cameraIsMoving;

	void Start () {
		Camera.main.orthographicSize = 5;
	}

	void moveCameraToPos(Vector2 toPos, float zoom, float zoomPercent, float percent) {
		Vector2 currentPos = Camera.main.transform.localPosition;
		float currentZoom = Camera.main.orthographicSize;
		Vector2 destinationPos = toPos - currentPos;
		float destinationZoom = (zoom - currentZoom);
			
		destinationPos = Vector2.Scale (destinationPos, new Vector2 (1, 1));
			
		Camera.main.transform.localPosition += (percent * destinationPos);
		Camera.main.orthographicSize += (zoomPercent * destinationZoom);
	}

	// Update is called once per frame
	void Update () {
		//moveCamera ();
	}

	void moveCamera() {
		GameObject target = (GameObject) CharacterHandler.enemies[0];
		moveCameraToPos (target.transform.localPosition, 4, .1f, .05f);
		wait (400);
		target = (GameObject) CharacterHandler.enemies[1];
		moveCameraToPos (target.transform.localPosition, 4, .1f, .05f);
		wait (400);
		target = (GameObject) CharacterHandler.enemies[2];
		moveCameraToPos (target.transform.localPosition, 4, .1f, .05f);
		wait (400);
		target = (GameObject) CharacterHandler.enemies[3];
		moveCameraToPos (target.transform.localPosition, 4, .1f, .05f);
	}

	void wait(float time) {
		bool canAdvance = false;
		float timeElapsed = 0;
		while (!canAdvance) {
			if (timeElapsed >= time) {
				canAdvance = true;
			}
			else {
				timeElapsed += Time.deltaTime;
			}
		}
	}

}
