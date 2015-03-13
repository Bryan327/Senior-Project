using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {
	public int currentEnemy = 0;
	public bool cameraIsMoving;

	void Start () {
		Camera.main.orthographicSize = 5;
		StartCoroutine (moveCamera ());
	}

	IEnumerator moveCameraToPos(Vector3 toPos, float zoom, float zoomPercent, float percent) {
		cameraIsMoving = true;
		while (cameraIsMoving) {
			Vector3 currentPos = Camera.main.transform.localPosition;
			float currentZoom = Camera.main.orthographicSize;
			Vector3 destinationPos = toPos - currentPos;
			float destinationZoom = (zoom - currentZoom);
			
			destinationPos = Vector2.Scale (destinationPos, new Vector2 (1, 1));
			
			Camera.main.transform.localPosition += (percent * destinationPos);
			Camera.main.orthographicSize += (zoomPercent * destinationZoom);

			if (Camera.main.transform.localPosition.x <= (toPos.x + .1f) && Camera.main.transform.localPosition.x >= (toPos.x - .1f) && Camera.main.transform.localPosition.y <= (toPos.y + .1f) && Camera.main.transform.localPosition.y <= (toPos.y - .1f)) {
				cameraIsMoving = false;
			}
			yield return null;
		}
	}

	// Update is called once per frame
	void Update () {
		//moveCamera ();
	}

	IEnumerator moveCamera() {
		GameObject target = (GameObject) CharacterHandler.enemies[0];
		StartCoroutine (moveCameraToPos (target.transform.localPosition, 4, .1f, .05f));
		yield return new WaitForSeconds (2.0f);
		target = (GameObject) CharacterHandler.enemies[1];
		StartCoroutine (moveCameraToPos (target.transform.localPosition, 4, .1f, .05f));
		yield return new WaitForSeconds (2.0f);
		target = (GameObject) CharacterHandler.enemies[2];
		StartCoroutine (moveCameraToPos (target.transform.localPosition, 4, .1f, .05f));
		yield return new WaitForSeconds (2.0f);
		target = (GameObject) CharacterHandler.enemies[3];
		StartCoroutine (moveCameraToPos (target.transform.localPosition, 4, .1f, .05f));
		yield return new WaitForSeconds (2.0f);
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
