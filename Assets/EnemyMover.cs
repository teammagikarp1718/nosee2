﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

	public Vector2 direction;
	private Rigidbody2D rb2d;
	public float speed;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.AddForce (speed * direction);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
