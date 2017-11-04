using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float maxSpeed = 20;
	public float movementForce = 100;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
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
		}

		if (other.gameObject.CompareTag ("Enemy")) {
			gameObject.SetActive (false);
		}
	}

}
