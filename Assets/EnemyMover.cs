using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

	public Vector2 direction;
	private Rigidbody2D rb2d;
	private SpriteRenderer sr;
	public float speed;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.AddForce (speed * direction);
		sr = GetComponent<SpriteRenderer> ();
	}


//	void OnCollisionEnter2D(Collision2D col) {
//		sr.flipX = !sr.flipX;
//		sr.flipY = !sr.flipY;
//	}
}
