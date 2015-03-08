using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelSlideIn : MonoBehaviour {
	Vector2 destination = new Vector2(-495, -2);
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		move (destination, 0.01f);
		Debug.Log ("Stuff " + GetComponent<RectTransform>().localPosition.x);
		Debug.Log (destination.x);

	}

	void move(Vector2 destination, float percent) {
		Vector2 pos = GetComponent<RectTransform> ().localPosition;
		Vector2 vec = destination - pos;
		GetComponent<RectTransform> ().localPosition = vec * percent;
	}
}
