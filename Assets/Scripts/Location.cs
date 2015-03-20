using UnityEngine;
using System.Collections;

public class Location {

	public GameObject loc;
	public bool[] slotIsFree;

	public Location(GameObject obj) {
		loc = obj;
		slotIsFree = new bool[4];

		for (int i = 0; i < 4; i++) {
			slotIsFree[i] = true;
		}
	}

	public void setSlotToUsed(int i) {
		slotIsFree [i] = false;
	}

	public void setSlotToFree(int i) {
		slotIsFree [i] = true;
	}

	public int getFirstFreeSlot() {
		int slot = 0;
		for (int i = 0; i < 4; i++) {
			if (slotIsFree[i] == true) {
				slot = i;
				break;
			}
		}
		Debug.Log ("Slot: " + slot);
		return slot;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
