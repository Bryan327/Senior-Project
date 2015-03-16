using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {
	public float targetX = 0;
	public float cameraX = 0;
	public bool cameraIsMoving;

	void Start () {
		//Camera.main.orthographicSize = 5;
		//StartCoroutine (moveCamera ());
	}

	public IEnumerator moveCameraToPos(Vector3 toPos, float zoom, float zoomPercent, float percent) {
		cameraIsMoving = true;
		while (cameraIsMoving) {
			Vector3 currentPos = Camera.main.transform.localPosition;
			float currentZoom = Camera.main.orthographicSize;
			Vector3 destinationPos = toPos - currentPos;
			float destinationZoom = (zoom - currentZoom);
			
			destinationPos = Vector2.Scale (destinationPos, new Vector2 (1, 1));
			Debug.Log ("X: " + destinationPos.x + ", Y: " + destinationPos.y);
			
			Camera.main.transform.localPosition += (percent * destinationPos);
			cameraX = Camera.main.transform.localPosition.x;
			Camera.main.orthographicSize += (zoomPercent * destinationZoom);

			if (Camera.main.transform.localPosition.x <= (toPos.x + .05f) && Camera.main.transform.localPosition.x >= (toPos.x - .05f) && Camera.main.transform.localPosition.y <= (toPos.y + .05f) && Camera.main.transform.localPosition.y >= (toPos.y - .05f)) {
				Camera.main.transform.localPosition.Set(toPos.x, toPos.y, -10f);
				cameraIsMoving = false;
			}
			yield return null;
		}
		cameraX = Camera.main.transform.localPosition.x;
	}

	// Update is called once per frame
	void Update () {
		checkInput ();
	}

	public void moveLocation1() {
		if (!cameraIsMoving) {
			Vector3 target = GameObject.Find ("Location1Object").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 8, 0.1f, 0.1f));
		}
	}

	public void moveLocation2() {
		if (!cameraIsMoving) {
			Vector3 target = GameObject.Find ("Location2Object").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 8, 0.1f, 0.1f));
		}

	}

	public void moveLocation3() {
		if (!cameraIsMoving) {
			Vector3 target = GameObject.Find ("Location3Object").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 8, 0.1f, 0.1f));
		}

	}

	public void moveLocation4() {
		if (!cameraIsMoving) {
			Vector3 target = GameObject.Find ("Location4Object").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 8, 0.1f, 0.1f));
		}

	}

	public void moveLocation5() {
		if (!cameraIsMoving) {
			Vector3 target = GameObject.Find ("Location5Object").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 8, 0.1f, 0.1f));
		}

	}

	public void moveKeep () {
		if (!cameraIsMoving) {
			Vector3 target = GameObject.Find ("KeepObject").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 12, 0.1f, 0.1f));
		}

	}

	public void checkInput() {
		if (Input.GetKeyDown(KeyCode.Alpha1) && !cameraIsMoving) {
			Vector3 target = GameObject.Find ("Location1Object").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 8, 0.1f, 0.1f));
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && !cameraIsMoving) {
			Vector3 target = GameObject.Find ("Location2Object").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 8, 0.1f, 0.1f));
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) && !cameraIsMoving) {
			Vector3 target = GameObject.Find ("Location3Object").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 8, 0.1f, 0.1f));
		}
		if (Input.GetKeyDown(KeyCode.Alpha4) && !cameraIsMoving) {
			Vector3 target = GameObject.Find ("Location4Object").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 8, 0.1f, 0.1f));
		}
		if (Input.GetKeyDown(KeyCode.Alpha5) && !cameraIsMoving) {
			Vector3 target = GameObject.Find ("Location5Object").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 8, 0.1f, 0.1f));
		}
		if (Input.GetKeyDown(KeyCode.Alpha6) && !cameraIsMoving) {
			Vector3 target = GameObject.Find ("KeepObject").transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, 12, 0.1f, 0.1f));
		}
	}
}
