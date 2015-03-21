using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour 
{
	private float _targetX = 0;
	private float _cameraX = 0;
	private bool _cameraIsMoving;

	void Start ()
	{
		//Camera.main.orthographicSize = 5;
		//StartCoroutine (moveCamera ());
	}

	public IEnumerator moveCameraToPos(Vector3 toPos, float zoom, float zoomPercent, float percent)
	{
		this._cameraIsMoving = true;

		Vector3 currentPos, destinationPos;
		float currentZoom, destinationZoom;
		//why were you constantly creating new variables in this loop?
		while (this._cameraIsMoving)
		{
			currentPos = Camera.main.transform.localPosition;
			currentZoom = Camera.main.orthographicSize;
			destinationPos = toPos - currentPos;
			destinationZoom = (zoom - currentZoom);
			
			destinationPos = Vector2.Scale (destinationPos, new Vector2 (1, 1));
			Debug.Log ("X: " + destinationPos.x + ", Y: " + destinationPos.y);
			
			Camera.main.transform.localPosition += (percent * destinationPos);
			this._cameraX = Camera.main.transform.localPosition.x;
			Camera.main.orthographicSize += (zoomPercent * destinationZoom);

			if (Camera.main.transform.localPosition.x <= (toPos.x + .05f) && Camera.main.transform.localPosition.x >= (toPos.x - .05f) && Camera.main.transform.localPosition.y <= (toPos.y + .05f) && Camera.main.transform.localPosition.y >= (toPos.y - .05f)) 
			{
				Camera.main.transform.localPosition.Set(toPos.x, toPos.y, -10f);
				this._cameraIsMoving = false;
			}
			yield return null;
		}
		this._cameraX = Camera.main.transform.localPosition.x;
	}

	// Update is called once per frame
	void Update() 
	{
		this.checkInput();
	}

	public void checkInput() 
	{
		//can probably be replaced with a switch just not sure what to switch on, Input.GetKeyDown(KeyCode.Alpha1?
		if (Input.GetKeyDown(KeyCode.Alpha1) && !this._cameraIsMoving) 
			this.MoveToLocation("Location1Object", 8, 0.1f, 0.1f);
		
		if (Input.GetKeyDown(KeyCode.Alpha2) && !this._cameraIsMoving) 
			this.MoveToLocation("Location2Object", 8, 0.1f, 0.1f);

		if (Input.GetKeyDown(KeyCode.Alpha3) && !this._cameraIsMoving) 
			this.MoveToLocation("Location3Object", 8, 0.1f, 0.1f);

		if (Input.GetKeyDown(KeyCode.Alpha4) && !this._cameraIsMoving) 
			this.MoveToLocation("Location4Object", 8, 0.1f, 0.1f);

		if (Input.GetKeyDown(KeyCode.Alpha5) && !this._cameraIsMoving) 
			this.MoveToLocation("Location5Object", 8, 0.1f, 0.1f);

		if (Input.GetKeyDown(KeyCode.Alpha6) && !this._cameraIsMoving) 
			this.MoveToLocation("KeepObject", 12, 0.1f, 0.1f);
	}

	private void MoveToLocation(string locationName, float x, float y, float z)
	{
		if (!this._cameraIsMoving) 
		{
			Vector3 target = GameObject.Find (locationName).transform.localPosition;
			target = Vector3.Scale(target, new Vector3(1, 1, 0));
			StartCoroutine (moveCameraToPos (target, x, y, z));
		}
	}
}