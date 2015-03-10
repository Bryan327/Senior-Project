using UnityEngine;
using System.Collections;

public class CameraMoveToPos : MonoBehaviour {

	void Start () {
		Camera.main.orthographicSize = 5;
	}

	void moveCameraToPos(Vector3 toPos, float zoom, float zoomPercent, float percent) {
		Vector3 currentPos = Camera.main.transform.localPosition;
		float currentZoom = Camera.main.orthographicSize;
		Vector3 destinationPos = toPos - currentPos;
		float destinationZoom = (zoom - currentZoom);

		destinationPos = Vector3.Scale (destinationPos, new Vector3 (1, 1, 0));

		Camera.main.transform.localPosition += (percent * destinationPos);
		Camera.main.orthographicSize += (zoomPercent * destinationZoom);
	}

	// Update is called once per frame
	void Update () {
		GameObject target = GameObject.Find ("EnemyObject1");
		moveCameraToPos (target.transform.localPosition, 4, .1f, .05f);
	}
}
