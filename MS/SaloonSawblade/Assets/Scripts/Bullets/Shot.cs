using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	public Vector2 dir;

	private Rigidbody2D rb;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag != "Enemy" && col.gameObject.tag != "Sawblade" && col.gameObject.tag != "DamagingObj")
			Destroy(gameObject);
	}

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		Destroy(gameObject, Random.Range(0.5f, 0.8f));
	}
	
	void Update() {
		rb.velocity = dir;
	}
}
