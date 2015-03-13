using UnityEngine;
using System.Collections;

public class CharacterHandler : MonoBehaviour {

	public static ArrayList enemies = new ArrayList ();
	public static ArrayList players = new ArrayList ();
	public static ArrayList cards = new ArrayList();
	public SpriteRenderer rend;
	public BoxCollider2D col;

	void Awake() {
		GameObject temp = new GameObject ("EnemyObject");
		rend = temp.AddComponent<SpriteRenderer> ();
		col = temp.AddComponent<BoxCollider2D> ();
		temp.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("EnemyA", typeof(Sprite))as Sprite;
		temp.GetComponent<BoxCollider2D>().size = temp.GetComponent<SpriteRenderer>().sprite.bounds.size;
		temp.transform.localPosition = new Vector2 (-6f, 2.65f);
		enemies.Add (temp);

		temp = new GameObject ("EnemyObject");
		rend = temp.AddComponent<SpriteRenderer> ();
		col = temp.AddComponent<BoxCollider2D> ();
		temp.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("EnemyB", typeof(Sprite))as Sprite;
		temp.GetComponent<BoxCollider2D>().size = temp.GetComponent<SpriteRenderer>().sprite.bounds.size;
		temp.transform.localPosition = new Vector2 (-2f, 2.65f);
		enemies.Add (temp);

		temp = new GameObject ("EnemyObject");
		rend = temp.AddComponent<SpriteRenderer> ();
		col = temp.AddComponent<BoxCollider2D> ();
		temp.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("EnemyC", typeof(Sprite))as Sprite;
		temp.GetComponent<BoxCollider2D>().size = temp.GetComponent<SpriteRenderer>().sprite.bounds.size;
		temp.transform.localPosition = new Vector2 (2f, 2.65f);
		enemies.Add (temp);

		temp = new GameObject ("EnemyObject");
		rend = temp.AddComponent<SpriteRenderer> ();
		col = temp.AddComponent<BoxCollider2D> ();
		temp.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("EnemyD", typeof(Sprite))as Sprite;
		temp.GetComponent<BoxCollider2D>().size = temp.GetComponent<SpriteRenderer>().sprite.bounds.size;
		temp.transform.localPosition = new Vector2 (6f, 2.65f);
		enemies.Add (temp);

		temp = new GameObject ("PlayerObject");
		rend = temp.AddComponent<SpriteRenderer> ();
		col = temp.AddComponent<BoxCollider2D> ();
		temp.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("PlayerA", typeof(Sprite))as Sprite;
		temp.GetComponent<BoxCollider2D>().size = temp.GetComponent<SpriteRenderer>().sprite.bounds.size;
		temp.transform.localPosition = new Vector2 (0f, -2.65f);
		players.Add (temp);

		float x = -6f;
		float y = -5f;

		for (int i = 0; i < 5; i++) {
			temp = new GameObject("Card");
			rend = temp.AddComponent <SpriteRenderer>();
			col = temp.AddComponent<BoxCollider2D> ();
			temp.GetComponent<SpriteRenderer>().sprite = Resources.Load ("CardTemplate", typeof(Sprite)) as Sprite;
			temp.GetComponent<BoxCollider2D>().size = temp.GetComponent<SpriteRenderer>().sprite.bounds.size;
			temp.transform.localPosition = new Vector2(x, y);
			temp.tag = "Card";
			cards.Add(temp);

			x += 3f;
		}
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameHandler.gameState == GameHandler.CARD_SELECT) {
			doCardAnim ();
		}
	}

	void doCardAnim() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
		for (int i = 0; i < cards.Count; i++) {
			GameObject card = (GameObject) cards[i];
			if (hit != null && hit.collider != null) {
				if(hit.collider.gameObject == card) {
					moveObject (card, new Vector2(card.transform.localPosition.x, -4.35f), 0.1f);
				}
				else {
					moveObject (card, new Vector2(card.transform.localPosition.x, -5), 0.1f);
				}
			}
			else {
				moveObject (card, new Vector2(card.transform.localPosition.x, -5), 0.1f);
			}
		}
	}

	void moveObject(GameObject obj, Vector3 toPos, float percent) {
		Vector3 resultant = toPos - obj.transform.localPosition;

		obj.transform.localPosition += resultant * percent;
	}
}
