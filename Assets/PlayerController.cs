using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float maxSpeed = 20;
	public float movementForce = 100;
	public float startx = 0;
	public float starty = 0;
	private int count;
	public Text countText;
	public Text winText;
	public GameObject[] enemies;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		gameObject.transform.position = new Vector3(startx,starty,0);
		count = 0;
		countText.text = "Count: " + count.ToString () + " / 9";
		winText.text = "";


		for (int i = 0; i < enemies.Length; i++) {
			Physics2D.IgnoreCollision (enemies[i].GetComponent<Collider2D> (), GetComponent<Collider2D> ());
		}

		for (int i = 0; i < enemies.Length; i++) {
			for (int j = 0; j < enemies.Length; j++) {
				if (i != j) {
					Physics2D.IgnoreCollision (enemies [i].GetComponent<Collider2D> (), enemies [j].GetComponent<Collider2D> ());
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 move = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));

		rb2d.velocity += move * movementForce;

		float mag = rb2d.velocity.magnitude;

		if (mag > maxSpeed) {
			rb2d.velocity = maxSpeed * rb2d.velocity.normalized;
		}
	}
		
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			int tempCount = count / 2;
			countText.text = "Count: " + tempCount.ToString () + " / 9";

			if (tempCount >= 1) {
				winText.text = "You Win!";
			}
		}

		if (other.gameObject.CompareTag ("Enemy")) {
			//gameObject.SetActive (false);
			gameObject.transform.position = new Vector3(startx,starty,0);
		}
	}
}
