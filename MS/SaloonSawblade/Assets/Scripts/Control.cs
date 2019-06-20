using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

	private Vector3 move = new Vector3();
	private Rigidbody2D rb;

	public GameObject spark;
	private GameObject[] sparks = new GameObject[17];

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		for(int i = 0; i < 17; i++)
			sparks[i] = spark;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Enemy")
			Destroy(col.gameObject);
		Sparks(col);
	}

	void OnCollisionStay2D(Collision2D col) {
		Sparks(col);
	}
	
	void FixedUpdate () {
		move.x = Input.GetAxisRaw("Horizontal") * 8;
		move.y = Input.GetAxisRaw("Vertical") * 8;
	}
	void Update () {
		rb.velocity = move;
	}

	void Sparks(Collision2D col) {
		for(int i = 0; i < 17; i++)
		{
			Vector2 cont = col.contacts[0].point;
			Vector2 sparksDir = cont - rb.position;
			sparks[i].transform.position = cont;
			sparks[i].GetComponent<Spark>().dir = RotateVector(sparksDir * Random.Range(5, 8), Random.Range(90, 120));
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
