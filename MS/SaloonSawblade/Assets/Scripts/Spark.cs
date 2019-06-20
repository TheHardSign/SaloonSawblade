using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour {

	public Vector2 dir;

	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		Destroy(gameObject, Random.Range(0.1f, 0.4f));
	}
	
	void Update() {
		rb.velocity = dir;
	}
}
