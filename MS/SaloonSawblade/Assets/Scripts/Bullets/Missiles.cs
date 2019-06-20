﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour {

	public Vector2 dir;

	private Rigidbody2D rb;
	private Rigidbody2D player;

	public GameObject spark;
	private GameObject[] sparks = new GameObject[5];

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag != "Enemy" && col.gameObject.tag != "Sawblade" || col.gameObject.tag == "DamagingObj")
		{
			Destroy(gameObject);
			Destroying();
		}
	}

	void Start() {
		player = GameObject.FindWithTag("Sawblade").GetComponent<Rigidbody2D>();
		for(int i = 0; i < 5; i++)
			sparks[i] = spark;
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update() {
		rb.velocity = dir / dir.magnitude * 7f;
		dir = player.position - rb.position;
	}

	void Destroying() {
		for(int i = 0; i < 5; i++)
		{
			sparks[i].transform.position = transform.position;
			sparks[i].GetComponent<Spark>().dir = RotateVector(-dir / dir.magnitude * Random.Range(5, 8), Random.Range(-90, 90));
			Instantiate(sparks[i]);
		}
	}

	public Vector2 RotateVector(Vector2 v, float angle)
	{
    	float radian = angle*Mathf.Deg2Rad;
    	float _x = v.x*Mathf.Cos(radian) - v.y*Mathf.Sin(radian);
    	float _y = v.x*Mathf.Sin(radian) + v.y*Mathf.Cos(radian);
    	return new Vector2(_x,_y);
	} 
}
