using UnityEngine;
using System.Collections;

public class CharacterHandler : MonoBehaviour 
{
	//can probably just use List, but a list of what?
	//also why static?
	private ArrayList _enemies = new ArrayList ();
	private ArrayList _players = new ArrayList ();
	private ArrayList _cards = new ArrayList();
	private SpriteRenderer _rend;
	private BoxCollider2D _col;
	
	//shouldn't this need an access level? public maybe?
	void Awake() 
	{ //are enemy objects even being used yet?
		this.GenerateObject ("EnemyObject", "EnemyA", -6f, 2.65f);

		this.GenerateObject ("EnemyObject", "EnemyB", -2f, 2.65f);

		this.GenerateObject ("EnemyObject", "EnemyC", 2f, 2.65f);

		this.GenerateObject ("EnemyObject", "EnemyD", 6f, 2.65f);

		this.GenerateObject ("PlayerObject", "PlayerA", 0f, -2.65f);

		float x = -6f;

		for (int i = 0; i < 5; i++) 
		{
			this.GenerateObject ("Card", "CardTemplate", x, -5f);
			x += 3f;
		}
	}

	void Start() {}
	
	// Update is called once per frame
	void Update() {}

	void doCardAnim() 
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
		for (int i = 0; i < this._cards.Count; i++) 
		{
			GameObject card = (GameObject) this._cards[i];
			if (hit != null && hit.collider != null) 
			{
				if (hit.collider.gameObject == card) 
					moveObject (card, new Vector2(card.transform.localPosition.x, -4.35f), 0.1f);
				else 
					moveObject (card, new Vector2(card.transform.localPosition.x, -5), 0.1f);
			}
			else 
				moveObject (card, new Vector2(card.transform.localPosition.x, -5), 0.1f);
		}
	}

	void moveObject(GameObject obj, Vector3 toPos, float percent)
	{
		Vector3 resultant = toPos - obj.transform.localPosition;

		obj.transform.localPosition += resultant * percent;
	}

	private void GenerateObject(string objectType,string objectName, float x, float y) 
	{
		GameObject temp = new GameObject (objectName);
		this._rend = temp.AddComponent<SpriteRenderer> ();
		this._col = temp.AddComponent<BoxCollider2D> ();
		temp.GetComponent<SpriteRenderer> ().sprite = Resources.Load (objectName, typeof(Sprite))as Sprite;
		temp.GetComponent<BoxCollider2D>().size = temp.GetComponent<SpriteRenderer>().sprite.bounds.size;
		temp.transform.localPosition = new Vector2 (x, y);
		temp.tag = objectType;
		this._enemies.Add (temp);
	}
}